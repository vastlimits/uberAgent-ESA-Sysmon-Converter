using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using vl.Core.Domain.Activity;
using vl.Core.Domain.Extensions;

namespace vl.Sysmon.Converter.Domain.Activity;

public class SysmonActivityMonitoringRule : ActivityMonitoringRule
{
   public static ActivityMonitoringRule Create<T>(List<T> sysmonGroupActivities, string eventName, EventType eventType) where T : ISysmonEventFilteringRuleGroup
   {
      if (sysmonGroupActivities == null || sysmonGroupActivities.Count == 0)
         return new ActivityMonitoringRule();

      sysmonGroupActivities = sysmonGroupActivities.Where(c => c.Items is { Length: > 0 }).ToList();
      if (sysmonGroupActivities.Count == 0)
         return new ActivityMonitoringRule();

      try
      {
         if (!Versioning.IsSupportedByCurrentVersion(Globals.Options.UAVersion, eventType))
         {
            Log.Warning("{0} is not supported in uberAgent version: {1}", eventName, Globals.Options.UAVersion);
            return new ActivityMonitoringRule();
         }

         Log.Information("Converting rules for {0}..", eventName);
         var includeQueries = new List<string>();
         var excludeQueries = new List<string>();
         var activityName = sysmonGroupActivities[0].GetType().Name;

         var activityConverterSettings = new SysmonActivityMonitoringRule
         {
            Id = Guid.NewGuid(),
            EventType = eventType,
         };

         // Start always with include first then exclude
         foreach (var rule in sysmonGroupActivities.OrderByDescending(c => c.onmatch))
         {
            if (rule.onmatch == null)
            {
               Log.Error("Failure to convert rules for {0} - \"onmatch\" not set.", eventName);
               continue;
            }
            var onMatch = rule.onmatch.ToLower();
            if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
               continue;

            if (rule.Items == null || rule.Items.Length == 0)
               continue;

            activityConverterSettings.Name = rule.name;
            activityConverterSettings.Tag = rule.name;

            var conditions = ConvertEntity.ParseRule(eventType, rule).ToList();
            var mainGroupRelation = rule.groupRelation;

            if (conditions.Count == 0)
               continue;

            var removedUnsupported = conditions.RemoveAll(c => !c.IsSupportedByCurrentUberAgentVersion);
            if (removedUnsupported > 0 && !string.Equals(mainGroupRelation, "or", StringComparison.OrdinalIgnoreCase))
            {
               Log.Warning("Found {0} unsupported rules in {1}, the entire rule is ignored due to logical concatenation <and> or default field semantics.", removedUnsupported, eventName);
               continue;
            }

            if (removedUnsupported > 0)
               Log.Warning("Found {0} unsupported rules in {1}, only the unsupported rules have been removed, due to logical concatenation <or>.", removedUnsupported, eventName);

            if (conditions.Count == 0)
               continue;

            if (activityName.EndsWith("RegistryEvent"))
            {
               var hive = Hive.All;

               var canSpecifyHive = conditions.All(c => c.Condition.Equals("is") || c.Condition.Equals("begin with"));
               if (canSpecifyHive)
               {
                  var hives = conditions.Where(c => c.Condition.Equals("is") || c.Condition.Equals("begin with"))
                     .Select(c => c.Value.Split(@"\").FirstOrDefault()?.ToLower())
                     .Distinct()
                     .Where(c => !string.IsNullOrEmpty(c))
                     .ToArray();

                  if (hives.Length == 1)
                     hive = hives.First().FromString();
               }

               activityConverterSettings.Hive = hive;
            }

            var convertedQuery = ConvertEntity.Convert(conditions.ToArray(), mainGroupRelation);
            if (string.IsNullOrEmpty(convertedQuery))
              continue;

            if (onMatch.Equals(Constants.SysmonExcludeOnMatchString))
              excludeQueries.Add(convertedQuery);
            else
              includeQueries.Add(convertedQuery);
         }

         if (includeQueries.Count == 0 && excludeQueries.Count == 0)
            return new ActivityMonitoringRule();

         activityConverterSettings.Query = CombineIncludeExcludeQueries(includeQueries, excludeQueries);
         activityConverterSettings.Id = CreateDeterministicRuleId(activityConverterSettings);

         Log.Information("Converted {converted}/{rules} rules.", includeQueries.Count + excludeQueries.Count, sysmonGroupActivities.Count);
         return activityConverterSettings;
      }
      catch (Exception ex)
      {
         Log.Error(ex, "Failure to convert rules for {0}.", eventName);
      }

      return new ActivityMonitoringRule();
   }

   private static string CombineIncludeExcludeQueries(IReadOnlyCollection<string> includeQueries, IReadOnlyCollection<string> excludeQueries)
   {
      var includeQuery = CombineQueries(includeQueries, "or");
      var excludeQuery = CombineQueries(excludeQueries, "or");

      if (string.IsNullOrEmpty(includeQuery))
         return $"not ({excludeQuery})";

      if (string.IsNullOrEmpty(excludeQuery))
         return includeQuery;

      return $"{WrapQuery(includeQuery)} and not ({excludeQuery})";
   }

   private static string CombineQueries(IEnumerable<string> queries, string relation)
   {
      var queryArray = queries.Where(query => !string.IsNullOrWhiteSpace(query)).ToArray();
      if (queryArray.Length == 0)
         return string.Empty;

      if (queryArray.Length == 1)
         return queryArray[0];

      return string.Join($" {relation} ", queryArray.Select(query => $"({query})"));
   }

   private static string WrapQuery(string query)
      => query.Contains(" or ") || query.Contains(" and ") ? $"({query})" : query;

   private static Guid CreateDeterministicRuleId(ActivityMonitoringRule rule)
   {
      var seed = $"{rule.EventType}|{rule.Name}|{rule.Tag}|{rule.Query}";
      var hash = MD5.HashData(Encoding.UTF8.GetBytes(seed));
      return new Guid(hash);
   }
}
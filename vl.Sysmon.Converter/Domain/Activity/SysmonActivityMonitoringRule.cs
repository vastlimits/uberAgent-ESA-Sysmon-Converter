using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
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
            Log.Information("Converting rules for {0}..", eventName);
            var result = new List<string>();

            var activityConverterSettings = new SysmonActivityMonitoringRule
            {
               Id = Guid.NewGuid(),
               EventType = eventType,
            };

            // Start always with include first then exclude
            foreach (var rule in sysmonGroupActivities.OrderByDescending(c => c.onmatch))
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               if (rule.Items == null || rule.Items.Length == 0)
                  continue;

               activityConverterSettings.Name = rule.name;
               activityConverterSettings.Tag = rule.name;

               var conditions = ConvertEntity.ParseRule(rule).ToArray();
               var mainGroupRelation = rule.groupRelation;

               if (conditions.Length == 0)
                  continue;

               result.Add(ConvertEntity.Convert(conditions, mainGroupRelation));
            }

            activityConverterSettings.Query = string.Join(" and ", result);


            Log.Information("Converted {converted}/{rules} rules.", result.Count, sysmonGroupActivities.Count);
            return activityConverterSettings;
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for {eventName}.");
         }

         return new ActivityMonitoringRule();
      }
   }
}

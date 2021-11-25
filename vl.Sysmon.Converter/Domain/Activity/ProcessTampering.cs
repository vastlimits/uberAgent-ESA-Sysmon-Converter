using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class ProcessTampering : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupProcessTampering> processTamperingRules)
      {
         if (processTamperingRules == null || processTamperingRules.Count == 0)
            return NothingToConvert("ProcessTampering");

         processTamperingRules = processTamperingRules.Where(c => c.Items is { Length: > 0 }).ToList();
         if (processTamperingRules.Count == 0)
            return NothingToConvert("ProcessTampering");

         try
         {
            Log.Information("Converting rules for ProcessTampering..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var rule in processTamperingRules)
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               if (rule.Items == null || rule.Items.Length == 0)
                  continue;

               var activityConverterSettings = new SysmonActivityMonitoringRule
               {
                  EventType = EventType.ProcessTamperingEvent,
                  Name = rule.name,
                  Tag = rule.name,
                  Conditions = ParseRule(rule).ToArray(),
                  MainGroupRelation = rule.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, processTamperingRules.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for ProcessTampering.");
         }

         return NothingToConvert("ProcessTampering");
      }
   }
}

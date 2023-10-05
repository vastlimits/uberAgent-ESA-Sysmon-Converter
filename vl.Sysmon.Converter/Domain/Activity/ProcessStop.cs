using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class ProcessStop : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupProcessTerminate> processTerminateRules)
      {
         if (processTerminateRules == null || processTerminateRules.Count == 0)
            return NothingToConvert("ProcessStop");

         processTerminateRules = processTerminateRules.Where(c => c.Items is { Length: > 0 }).ToList();
         if (processTerminateRules.Count == 0)
            return NothingToConvert("ProcessStop");

         try
         {
            Log.Information("Converting rules for ProcessStop..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var rule in processTerminateRules)
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               if (rule.Items == null || rule.Items.Length == 0)
                  continue;

               var activityConverterSettings = new SysmonActivityMonitoringRule
               {
                  EventType = EventType.ProcessStop,
                  Name = rule.name,
                  Tag = rule.name,
                  Conditions = ParseRule(rule).ToArray(),
                  MainGroupRelation = rule.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, processTerminateRules.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for ProcessStop.");
         }

         return NothingToConvert("ProcessStop");
      }
   }
}

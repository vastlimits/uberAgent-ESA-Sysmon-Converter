using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.ActivityMonitoring;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessStartup : Rule
   {
      public static ActivityMonitoringRule[] ConvertRules(
         List<SysmonEventFilteringRuleGroupProcessCreate> processCreateRules)
      {
         if (processCreateRules == null || processCreateRules.Count == 0)
            return new ActivityMonitoringRule[0];
         
         try
         {
            Log.Information("Converting rules for ProcessStartup..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var rule in processCreateRules)
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               var activityConverterSettings = new ActivityMonitoringConverterSettings
               {
                  EventType = EventType.ProcessStart,
                  Name = rule.name,
                  Tag = rule.name,
                  Conditions = ParseRule(rule).ToArray(),
                  MainGroupRelation = rule.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, processCreateRules.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert exclude rules for ProcessStartup.");
         }

         return new ActivityMonitoringRule[0];
      }
   }
}

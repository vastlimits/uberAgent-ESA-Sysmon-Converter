using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.ActivityMonitoring;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class Registry : Rule
   {

      public static ActivityMonitoringRule[] ConvertRules(
         List<SysmonEventFilteringRuleGroupRegistryEvent> registryEvent)
      {
         if (registryEvent == null || registryEvent.Count == 0)
            return new ActivityMonitoringRule[0];

         try
         {
            Log.Information("Converting rules for Registry..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var rule in registryEvent)
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               var activityConverterSettings = new ActivityMonitoringConverterSettings
               {
                  EventType = new []{ EventType.RegKeyCreate, EventType.RegKeyDelete, EventType.RegValueWrite, EventType.RegKeyRename},
                  Name = rule.name,
                  Tag = rule.name,
                  Conditions = ParseRule(rule).ToArray(),
                  MainGroupRelation = rule.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, registryEvent.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for ProcessStartup.");
         }

         return new ActivityMonitoringRule[0];
      }

   }
}

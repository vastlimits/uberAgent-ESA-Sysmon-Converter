using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class ProcessNetwork : ConvertEntity
   {
      public static ActivityMonitoringRule[] ConvertRules(
        List<SysmonEventFilteringRuleGroupNetworkConnect> processNetworkRules)
      {
         if (processNetworkRules == null || processNetworkRules.Count == 0)
            return new ActivityMonitoringRule[0];

         try
         {
            Log.Information("Converting rules for Network..");

            var result = new List<ActivityMonitoringRule>();
            
            foreach (var ruleGroup in processNetworkRules)
            {
               var onMatch = ruleGroup.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               var activityConverterSettings = new SysmonActivityMonitoringRule
               {
                  EventType = EventType.NetConnect,
                  Name = ruleGroup.name,
                  Tag = ruleGroup.name,
                  Conditions = ParseRule(ruleGroup).ToArray(),
                  MainGroupRelation = ruleGroup.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, processNetworkRules.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for NetworkTargetPerformance & NetworkConnectFailure.");
         }

         return new ActivityMonitoringRule[0];
      }
   }
}

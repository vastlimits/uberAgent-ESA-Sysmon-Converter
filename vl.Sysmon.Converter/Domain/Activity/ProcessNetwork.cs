using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class ProcessNetwork : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
        List<SysmonEventFilteringRuleGroupNetworkConnect> processNetworkRules)
      {
         if (processNetworkRules == null || processNetworkRules.Count == 0)
            return NothingToConvert("ProcessNetwork");

         processNetworkRules = processNetworkRules.Where(c => c.Items is { Length: > 0 }).ToList();
         if (processNetworkRules.Count == 0)
            return NothingToConvert("ProcessNetwork");

         try
         {
            Log.Information("Converting rules for ProcessNetwork..");

            var result = new List<ActivityMonitoringRule>();
            
            foreach (var ruleGroup in processNetworkRules)
            {
               var onMatch = ruleGroup.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               var activityConverterSettings = new SysmonActivityMonitoringRule
               {
                  Id = Guid.NewGuid(),
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

         return NothingToConvert("ProcessNetwork");
      }
   }
}

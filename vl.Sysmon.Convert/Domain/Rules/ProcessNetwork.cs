using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain;
using vl.Core.Domain.ActivityMonitoring;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Helpers;
using vl.Sysmon.Convert.Domain.Helpers.Wrappers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessNetwork : Rule
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
            
            foreach (var rule in processNetworkRules)
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               var networkConnectRule = new NetworkConnect
               {
                  groupRelation = rule.groupRelation,
                  onmatch = rule.onmatch
               };

               if (rule.Image != null)
                  networkConnectRule.Items.AddRange(rule.Image);
               if (rule.DestinationHostname != null)
                  networkConnectRule.Items.AddRange(rule.DestinationHostname);
               if (rule.DestinationIp != null)
                  networkConnectRule.Items.AddRange(rule.DestinationIp);
               if (rule.DestinationPort != null)
                  networkConnectRule.Items.AddRange(rule.DestinationPort);

               var activityConverterSettings = new ActivityMonitoringConverterSettings
               {
                  EventType = EventType.NetConnect,
                  Name = rule.name,
                  Tag = rule.name,
                  Conditions = ParseRule(networkConnectRule).ToArray(),
                  MainGroupRelation = rule.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {count} rules.", result.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert exclude rules for NetworkTargetPerformance & NetworkConnectFailure.");
         }

         return new ActivityMonitoringRule[0];
      }
   }
}

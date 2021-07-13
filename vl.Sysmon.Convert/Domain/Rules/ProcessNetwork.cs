using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessNetwork : Rule
   {
      public static EventDataFilter[] ConvertExcludeRules(
        List<SysmonEventFilteringRuleGroupNetworkConnect> processNetworkRules)
      {
         if (processNetworkRules == null || processNetworkRules.Count == 0)
            return new EventDataFilter[0];

         try
         {
            Log.Information("Convert exclude rules for NetworkTargetPerformance & NetworkConnectFailure.");

            var result = new List<EventDataFilter>();
            var action = EventDataFilterAction.Deny;
            var sourcetypes = new List<string>
            {
               MetricNames.ProcessNetworkTargetPerformance,
               MetricNames.ApplicationNetworkConnectFailure
            };

            var rules = new List<object>();
            foreach (var rule in processNetworkRules.Where(rule => rule.onmatch.Equals(Constants.SysmonExcludeOnMatchString)))
            {
               if (rule.Image != null)
                  rules.AddRange(rule.Image);
               
               if (rule.DestinationHostname != null)
                  rules.AddRange(rule.DestinationHostname);
               
               if (rule.DestinationIp != null)
                  rules.AddRange(rule.DestinationIp);

               if (rule.DestinationPort != null)
                  rules.AddRange(rule.DestinationPort);
            }

            foreach (var item in rules)
            {
               var uberAgentMetricField = string.Empty;
               EventDataFilter filter = null;

               switch (item)
               {
                  case SysmonEventFilteringRuleGroupNetworkConnectImage c:
                     // We cannot fully convert this rule because we currently do not have the parent path in this metric.
                     uberAgentMetricField = c.Value.IndexOf('\\') > -1 ? string.Empty : "ProcName";

                     if (string.IsNullOrEmpty(uberAgentMetricField))
                        continue;

                     filter = Convert(new ConverterSettings
                     {
                        Action = action,
                        Field = uberAgentMetricField,
                        Condition = c.condition,
                        Value = c.Value,
                        Sourcetypes = sourcetypes,
                        Comment = Constants.ConversionComment
                     });
                     break;
                  case SysmonEventFilteringRuleGroupNetworkConnectDestinationHostname c:
                     uberAgentMetricField = "NetTargetRemoteName";
                     filter = Convert(new ConverterSettings
                     {
                        Action = action,
                        Field = uberAgentMetricField,
                        Condition = c.condition,
                        Value = c.Value,
                        Sourcetypes = sourcetypes,
                        Comment = Constants.ConversionComment
                     });
                     break;
                  case SysmonEventFilteringRuleGroupNetworkConnectDestinationIp c:
                     uberAgentMetricField = "NetTargetRemoteAddress";
                     filter = Convert(new ConverterSettings
                     {
                        Action = action,
                        Field = uberAgentMetricField,
                        Condition = c.condition,
                        Value = c.Value,
                        Sourcetypes = sourcetypes,
                        Comment = Constants.ConversionComment
                     });
                     break;
                  case SysmonEventFilteringRuleGroupNetworkConnectDestinationPort c:
                     uberAgentMetricField = "NetTargetRemotePort";
                     filter = Convert(new ConverterSettings
                     {
                        Action = action,
                        Field = uberAgentMetricField,
                        Condition = c.condition,
                        Value = c.Value.ToString(),
                        Sourcetypes = sourcetypes,
                        Comment = Constants.ConversionComment
                     });
                     break;
                  default:
                     Log.Warning("ProcessNetwork filter rule not implemented: {item}", item);
                     break;
               }

               if (filter != null)
                  result.Add(filter);
            }

            Log.Information("Converted {count} rules.", result.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert exclude rules for NetworkTargetPerformance & NetworkConnectFailure.");
         }

         return new EventDataFilter[0];
      }
   }
}

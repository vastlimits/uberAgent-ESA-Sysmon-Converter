using System;
using System.Collections.Generic;
using vl.Core.Domain;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessStartup : Rule
   {
      public static EventDataFilter[] ConvertExcludeRules(
         List<SysmonEventFilteringRuleGroupProcessCreate> processCreateRules)
      {
         if (processCreateRules == null || processCreateRules.Count == 0)
            return new EventDataFilter[0];

         try
         {
            Log.Information("Convert exclude rules for ProcessStartup..");

            var result = new List<EventDataFilter>();
            var action = EventDataFilterAction.Deny;
            var sourcetypes = new List<string> { MetricNames.ProcessStartup };

            foreach (var rule in processCreateRules)
            {
               if (!rule.onmatch.Equals(Constants.SysmonExcludeOnMatchString))
                  continue;

               foreach (var item in rule.Items)
               {
                  var uberAgentMetricField = string.Empty;
                  EventDataFilter filter = null;

                  switch (item)
                  {
                     case SysmonEventFilteringRuleGroupProcessCreateImage c:
                        uberAgentMetricField = c.Value.IndexOf('\\') > -1 ? "ProcPath" : "ProcName";
                        filter = Convert(new ConverterSettings
                        {
                           Action = action, Field = uberAgentMetricField, Condition = c.condition, Value = c.Value,
                           Sourcetypes = sourcetypes, Comment = Constants.ConversionComment
                        });
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateCommandLine c:
                        uberAgentMetricField = "ProcCmdline";
                        filter = Convert(new ConverterSettings
                        {
                           Action = action, Field = uberAgentMetricField, Condition = c.condition, Value = c.Value,
                           Sourcetypes = sourcetypes, Comment = Constants.ConversionComment
                        });
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateOriginalFileName c:
                        // We cannot convert this rule because we currently do not read the original name from PE.
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel c:
                        // We cannot convert this rule because we currently do not read the IntegrityLevel of an image.
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateParentImage c:
                        uberAgentMetricField = c.Value.IndexOf('\\') > -1 ? string.Empty : "ProcParentName";

                        // We cannot fully convert this rule because we currently do not have the parent path in this metric.
                        if (string.IsNullOrEmpty(uberAgentMetricField))
                           continue;

                        filter = Convert(new ConverterSettings
                        {
                           Action = action, Field = uberAgentMetricField, Condition = c.condition, Value = c.Value,
                           Sourcetypes = sourcetypes, Comment = Constants.ConversionComment
                        });
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateParentCommandLine c:
                        // We cannot convert this rule because we currently do not have the Parent commandline in this metric.
                        break;
                     default:
                        Log.Warning("ProcessStartup filter rule not implemented: {item}", item);
                        break;
                  }

                  if (filter != null)
                     result.Add(filter);
               }
            }

            Log.Information("Converted {count} rules.", result.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert exclude rules for ProcessStartup.");
         }

         return new EventDataFilter[0];
      }
   }
}

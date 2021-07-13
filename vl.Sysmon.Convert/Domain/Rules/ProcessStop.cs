using System;
using System.Collections.Generic;
using vl.Core.Domain;
using vl.Core.Domain.EventData;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessStop : Rule
   {
      public static EventDataFilter[] ConvertExcludeRules(List<SysmonEventFilteringRuleGroupProcessTerminate> processTerminateRules)
      {
         if (processTerminateRules == null || processTerminateRules.Count == 0)
            return new EventDataFilter[0];

         try
         {
            Log.Information("Convert exclude rules for ProcessStop..");

            var result = new List<EventDataFilter>();
            var action = EventDataFilterAction.Deny;

            foreach (var rule in processTerminateRules)
            {
               if (!rule.onmatch.Equals(Constants.SysmonExcludeOnMatchString))
                  continue;
               
               foreach (var item in rule.Image)
               {
                  var property = string.Empty;
                  EventDataFilter filter = null;

                  switch (item)
                  {
                     case SysmonEventFilteringRuleGroupProcessTerminateImage c:
                        property = "ProcPath";
                        filter = Convert(action, property, c.condition, c.Value, Constants.ConversionComment);
                        break;
                     default:
                        Log.Warning("ProcessStop filter rule not implemented: {item}", rule);
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
            Log.Error(ex, $"Failure to convert exclude rules for ProcessStop.");
         }

         return new EventDataFilter[0];
      }


      public static EventDataFilter Convert(EventDataFilterAction action, string property, string condition, string value, string comment)
      {
         return new()
         {
            Action = action,
            Fields = new List<string>(),
            Sourcetypes = new List<string>
            {
               MetricNames.ProcessStop
            },
            Query = ConvertQuery(property, condition, value),
            Comment = comment
         };
      }

   }
}
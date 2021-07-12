using System;
using System.Collections.Generic;
using vl.Core.Domain;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Extensions;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessStop : Rule
   {
      public static EventDataFilter[] ConvertExcludeRules(Sysmon config)
      {
         var processStopRules = GetExcludeRules(config);
         if (processStopRules == null || processStopRules.Length == 0)
            return new EventDataFilter[0];

         var filters = ConvertExcludeRules(processStopRules);
         if (filters == null || filters.Length == 0)
            return new EventDataFilter[0];

         return filters;
      }

      private static object[] GetExcludeRules(Sysmon config)
      {
         try
         {
            Log.Information("Get exclude rules for ProcessStop..");
            return config.GetExcludeRulesForProcessStop();
         }
         catch (NotImplementedException ex)
         {
            Log.Error(ex, $"A new ProcessStop exclude rule type is present that is not implemented.");
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to get exclude rules for ProcessStop.");
         }

         return null;
      }

      private static EventDataFilter[] ConvertExcludeRules(object[] processStopRules)
      {
         try
         {
            Log.Information("Convert exclude rules for ProcessStop..");

            var result = new List<EventDataFilter>();
            var action = EventDataFilterAction.Deny;

            foreach (var item in processStopRules)
            {
               var property = string.Empty;
               EventDataFilter filter = null;

               switch (item)
               {
                  case SysmonEventFilteringRuleGroupProcessTerminateImage c:
                     property = "Process.Path";
                     filter = Convert(action, property, c.condition, c.Value, Constants.ConversionComment);
                     break;
                  default:
                     Log.Warning("ProcessStop filter rule not implemented: {item}", item);
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
            Log.Error(ex, $"Failure to convert exclude rules for ProcessStop.");
         }

         return null;
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
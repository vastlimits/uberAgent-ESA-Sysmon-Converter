using System;
using System.Collections.Generic;
using vl.Core.Domain;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Extensions;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessStartup : Rule
   {
      public static EventDataFilter[] ConvertExcludeRules(Sysmon config)
      {
         var processStartupRules = GetExcludeRules(config);
         if (processStartupRules == null || processStartupRules.Length == 0)
            return new EventDataFilter[0];

         var filters = ConvertExcludeRules(processStartupRules);
         if (filters == null || filters.Length == 0)
            return new EventDataFilter[0];

         return filters;
      }

      private static object[] GetExcludeRules(Sysmon config)
      {
         try
         {
            Log.Information("Get exclude rules for ProcessStartup..");
            return config.GetExcludeRulesForProcessStartup();
         }
         catch (NotImplementedException ex)
         {
            Log.Error(ex, $"A new DNS exclude rule type is present that is not implemented.");
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to get exclude rules for DNS.");
         }

         return null;
      }

      private static EventDataFilter[] ConvertExcludeRules(object[] processStartupRules)
      {
         try
         {
            Log.Information("Convert exclude rules for ProcessStartup..");

            var result = new List<EventDataFilter>();
            var action = EventDataFilterAction.Deny;

            foreach (var item in processStartupRules)
            {
               var property = string.Empty;
               EventDataFilter filter = null;
               
               switch (item)
               {
                  case SysmonEventFilteringRuleGroupProcessCreateImage c:
                     property = c.Value.IndexOf('\\') > -1 ? "Process.Path" : "Process.Name";
                     filter = Convert(action, property, c.condition, c.Value, Constants.ConversionComment);
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateCommandLine c:
                     property = "Process.CommandLine";
                     filter = Convert(action, property, c.condition, c.Value, Constants.ConversionComment);
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateOriginalFileName c:
                     // We cannot convert this rule because we currently do not read the original name from PE.
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel c:
                     // We cannot convert this rule because we currently do not read the IntegrityLevel of an image.
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateParentImage c:
                     property = c.Value.IndexOf('\\') > -1 ? "Parent.Path" : "Parent.Name";
                     filter = Convert(action, property, c.condition, c.Value, Constants.ConversionComment);
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateParentCommandLine c:
                     property = "Parent.CommandLine";
                     filter = Convert(action, property, c.condition, c.Value, Constants.ConversionComment);
                     break;
                  default:
                     Log.Warning("DNS filter rule not implemented: {item}", item);
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
            Log.Error(ex, $"Failure to convert exclude rules for DNS.");
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
               MetricNames.ProcessStartup
            },
            Query = ConvertQuery(property, condition, value),
            Comment = comment
         };
      }

   }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            foreach (var item in processStartupRules)
            {
               switch (item)
               {
                  case SysmonEventFilteringRuleGroupProcessCreateImage c:
                     var property = c.Value.IndexOf('\\') > -1 ? "Process.Path" : "Process.Name";

                     var filter = Convert(property, c.condition, c.Value, Constants.ConversionComment);
                     result.Add(filter);
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateCommandLine c:
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateOriginalFileName c:
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel c:
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateParentImage c:
                     break;
                  case SysmonEventFilteringRuleGroupProcessCreateParentCommandLine c:
                     break;
                  default:
                     Log.Warning("DNS filter rule not implemented: {item}", item);
                     break;
               }
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

      public static EventDataFilter Convert(string property, string condition, string value, string comment)
      {
         return new()
         {
            Action = EventDataFilterAction.Deny,
            Fields = new List<string>(),
            Sourcetypes = new List<string>
            {
               MetricNames.ProcessStartup
            },
            Query = ConvertQuery(property, condition, value),
            Comment = comment
         };
      }

      private static string ConvertQuery(string property, string condition, string value)
      {
         return condition switch
         {
            "is" => $"{property} == \"{value}\"",

            _ => throw new NotImplementedException()
         };
      }
   }
}
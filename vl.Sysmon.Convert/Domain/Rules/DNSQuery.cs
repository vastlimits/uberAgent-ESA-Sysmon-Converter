using System;
using System.Collections.Generic;
using vl.Core.Domain;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Extensions;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class DNSQuery : Rule
   {
      public static EventDataFilter[] ConvertExcludeRules(Sysmon config)
      {
         var dnsRules = GetExcludeRules(config);
         if (dnsRules == null || dnsRules.Length == 0)
         {
            return new EventDataFilter[0];
         }

         var filters = ConvertExcludeRules(dnsRules);
         if (filters == null || filters.Length == 0)
         {
            return new EventDataFilter[0];
         }

         return filters;
      }

      private static EventDataFilter Convert(SysmonEventFilteringRuleGroupDnsQueryQueryName rule, string comment)
      {
         return new()
         {
            Action = EventDataFilterAction.Deny,
            Fields = new List<string>(),
            Sourcetypes = new List<string>
            {
               MetricNames.ProcessDnsQuery
            },
            Query = ConvertQuery(rule),
            Comment = comment
         };
      }

      private static object[] GetExcludeRules(Sysmon config)
      {
         try
         {
            Log.Information("Get exclude rules for DNS..");
            return config.GetExcludeRulesForDNS();
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

      private static EventDataFilter[] ConvertExcludeRules(object[] dnsRules)
      {
         try
         {
            Log.Information("Convert exclude rules for DNS..");

            var result = new List<EventDataFilter>();
            foreach (var item in dnsRules)
            {
               switch (item)
               {
                  case SysmonEventFilteringRuleGroupDnsQueryImage c:
                     // We cannot convert this rule because we are not able to access the full image path in this sourcetype.
                     break;
                  case SysmonEventFilteringRuleGroupDnsQueryQueryName c:
                  {
                     var filter = Convert(c, Constants.ConversionComment);
                     result.Add(filter);

                     Log.Information("Rule <{query}>", filter.Query);
                     break;
                  }
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

      private static string ConvertQuery(SysmonEventFilteringRuleGroupDnsQueryQueryName rule)
      {
         switch (rule.condition)
         {
            case "begin with":
               return $"istartswith(DnsRequest, \"{rule.Value}\")";
            case "end with":
               return $"iendswith(DnsRequest, \"{rule.Value}\")";
            case "is":
               return $"DnsRequest == \"{rule.Value}\"";
            default:
               throw new NotImplementedException();
         }
      }
   }
}

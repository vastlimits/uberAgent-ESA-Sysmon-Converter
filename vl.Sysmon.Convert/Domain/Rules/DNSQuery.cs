using System;
using System.Collections.Generic;
using vl.Core.Domain;
using vl.Sysmon.Convert.Domain.Extensions;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class DNSQuery : Rule
   {
      public static EventDataFilter[] ConvertExcludeRulesForDNS(Sysmon config)
      {
         var dnsRules = GetExcludeRulesForDNS(config);
         if (dnsRules == null || dnsRules.Length == 0)
         {
            return new EventDataFilter[0];
         }

         var filters = ConvertExcludeRulesForDNS(dnsRules);
         if (filters == null || filters.Length == 0)
         {
            return new EventDataFilter[0];
         }

         return filters;
      }

      private static object[] GetExcludeRulesForDNS(Sysmon config)
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

      private static EventDataFilter[] ConvertExcludeRulesForDNS(object[] dnsRules)
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
                     var filter = c.Convert(Constants.ConversionComment);
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
   }
}
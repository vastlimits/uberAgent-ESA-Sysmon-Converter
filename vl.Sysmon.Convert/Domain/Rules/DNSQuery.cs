using System;
using System.Collections.Generic;
using Serilog;
using vl.Core.Domain;
using vl.Sysmon.Convert.Domain.Extensions;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public static class DNSQuery
   {
      public static object[] GetExcludeRulesForDNS(Sysmon config)
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

      public static EventDataFilter[] ConvertExcludeRulesForDNS(object[] dnsRules)
      {
         try
         {
            Log.Information("Convert exclude rules for DNS..");

            List<EventDataFilter> result = new List<EventDataFilter>();
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
                  }
                     break;
                  default:
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
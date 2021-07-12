using System;
using System.Collections.Generic;
using vl.Core.Domain;
using vl.Core.Domain.EventData;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class DNSQuery : Rule
   {
      public static EventDataFilter[] ConvertExcludeRules(List<SysmonEventFilteringRuleGroupDnsQuery> dnsRules)
      {
         if (dnsRules == null || dnsRules.Count == 0)
            return new EventDataFilter[0];
         
         try
         {
            Log.Information("Convert exclude rules for DNS..");

            var result = new List<EventDataFilter>();
            var action = EventDataFilterAction.Deny;

            foreach (var rule in dnsRules)
            {
               if (!rule.onmatch.Equals(Constants.SysmonExcludeOnMatchString))
                  continue;

               foreach (var item in rule.Items)
               {
                  var property = string.Empty;
                  EventDataFilter filter = null;

                  switch (item)
                  {
                     case SysmonEventFilteringRuleGroupDnsQueryImage c:
                        // We cannot convert this rule because we are not able to access the full image path in this sourcetype.
                        break;
                     case SysmonEventFilteringRuleGroupDnsQueryQueryName c:
                        property = "DnsRequest";

                        filter = Convert(property, c.condition, c.Value, Constants.ConversionComment);
                        break;
                        
                     default:
                        Log.Warning("DNS filter rule not implemented: {item}", item);
                        break;
                  }


                  if (filter == null) 
                     continue;

                  Log.Verbose("Rule <{query}>", filter.Query);
                  result.Add(filter);
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
               MetricNames.ProcessDnsQuery
            },
            Query = ConvertQuery(property, condition, value),
            Comment = comment
         };
      }
   }
}

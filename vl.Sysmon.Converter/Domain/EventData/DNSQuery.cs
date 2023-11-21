using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using vl.Core.Domain.EventData;

namespace vl.Sysmon.Converter.Domain.EventData;

public class DNSQuery
{
   public static IEnumerable<EventDataFilter> ConvertExcludeRules(List<SysmonEventFilteringRuleGroupDnsQuery> dnsRules)
   {
      if (dnsRules == null || dnsRules.Count == 0)
         return Enumerable.Empty<EventDataFilter>();

      try
      {
         Log.Information("Convert exclude rules for DNS..");

         var result = new List<EventDataFilter>();

         foreach (var rule in dnsRules)
         {
            if (!rule.onmatch.Equals(Constants.SysmonExcludeOnMatchString))
               continue;

            result.AddRange(CreateEventFilterData(rule.Items));

         }

         Log.Information("Converted {count} rules.", result.Count);
         return result.ToArray();
      }
      catch (Exception ex)
      {
         Log.Error(ex, $"Failure to convert exclude rules for DNS.");
      }

      return Enumerable.Empty<EventDataFilter>(); ;
   }

   private static IEnumerable<EventDataFilter> CreateEventFilterData(object[] items)
   {
      var uberAgentMetricField = string.Empty;
      EventDataFilter filter = null;
      var sourcetypes = new List<string> {MetricNames.ProcessDnsQuery};
      var retn = new List<EventDataFilter>();
      foreach (var item in items)
      {
         switch (item)
         {
            case SysmonEventFilteringRuleGroupDnsQueryRule c:
               retn.AddRange(CreateEventFilterData(c.Items));
               break;
            case SysmonEventFilteringRuleGroupDnsQueryRuleImage:
            case SysmonEventFilteringRuleGroupDnsQueryImage:
               // We cannot convert this rule because we are not able to access the full image path in this sourcetype.
               break;
            case SysmonEventFilteringRuleGroupDnsQueryRuleQueryName c:
               uberAgentMetricField = MetricFields.DnsRequest;

               filter = ConvertEntity.Convert(new SysmonEventDataFilter
               {
                  Action = EventDataFilterAction.Deny, 
                  Field = uberAgentMetricField, 
                  Condition = c.condition, 
                  Value = c.Value,
                  Sourcetypes = sourcetypes
               });
               break;
            case SysmonEventFilteringRuleGroupDnsQueryQueryName c:
               uberAgentMetricField = MetricFields.DnsRequest;

               filter = ConvertEntity.Convert(new SysmonEventDataFilter
               {
                  Action = EventDataFilterAction.Deny, 
                  Field = uberAgentMetricField, 
                  Condition = c.condition, 
                  Value = c.Value,
                  Sourcetypes = sourcetypes
               });
               break;
            default:
               Log.Warning("DNS filter rule not implemented: {item}", item);
               break;
         }

         if (filter == null)
            continue;

         Log.Verbose("Rule <{query}>", filter.Query);
         retn.Add(filter);
      }
      

      return retn;
   }
}
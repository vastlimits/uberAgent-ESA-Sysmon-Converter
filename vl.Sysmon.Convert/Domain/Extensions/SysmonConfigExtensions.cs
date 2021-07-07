using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain;

namespace vl.Sysmon.Convert.Domain.Extensions
{
    internal static class SysmonConfigExtensions
    {
        const string SysmonExcludeOnMatchString = "exclude";

        internal static object[] GetExcludeRulesForDNS(this Sysmon config)
        {
            var objects = new List<object>();

            var excluded = config.EventFiltering.Items
                .Where(x => x.GetType() == typeof(SysmonEventFilteringRuleGroup))
                .Select(x => x as SysmonEventFilteringRuleGroup)
                .Where(x => x.DnsQuery != null && x.DnsQuery.onmatch == SysmonExcludeOnMatchString)
                .Select(x => x.DnsQuery)
                .ToList();

            foreach (var item in excluded.SelectMany(dnsExcludeGroup => dnsExcludeGroup.Items))
            {
               switch (item)
               {
                  case SysmonEventFilteringRuleGroupDnsQueryImage c:
                     objects.Add(c);
                     break;
                  case SysmonEventFilteringRuleGroupDnsQueryQueryName c:
                     objects.Add(c);
                     break;
                  default:
                     throw new NotImplementedException();
               }
            }

            return objects.ToArray();
        }

        internal static EventDataFilter Convert(this SysmonEventFilteringRuleGroupDnsQueryQueryName rule, string comment)
        {
            return new EventDataFilter()
            {
                Action = EventDataFilterAction.Deny,
                Fields = new List<string>(),
                Sourcetypes = new List<string>()
                {
                    MetricNames.ProcessDnsQuery
                },
                Query = rule.ConvertQuery(),
                Comment = comment
            };
        }

        private static string ConvertQuery(this SysmonEventFilteringRuleGroupDnsQueryQueryName rule)
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

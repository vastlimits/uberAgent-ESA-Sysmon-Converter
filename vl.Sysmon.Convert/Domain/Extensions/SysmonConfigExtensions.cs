using System;
using System.Collections.Generic;
using System.Linq;

namespace vl.Sysmon.Convert.Domain.Extensions
{
   internal static class SysmonConfigExtensions
   {
      internal static object[] GetExcludeRulesForProcessStartup(this Sysmon config)
      {
         var objects = new List<object>();
         var excluded = config.EventFiltering.Items
                              .OfType<SysmonEventFilteringRuleGroup>()
                              .Where(c => c.ProcessCreate?.Items?.Length > 0 && c.ProcessCreate?.onmatch == Constants.SysmonExcludeOnMatchString)
                              .Select(c => c.ProcessCreate)
                              .ToList();

         foreach (var item in excluded.SelectMany(processStartupExcludeGroup => processStartupExcludeGroup.Items))
         {
            switch (item)
            {
               case SysmonEventFilteringRuleGroupProcessCreateImage:
               case SysmonEventFilteringRuleGroupProcessCreateCommandLine:
               case SysmonEventFilteringRuleGroupProcessCreateOriginalFileName:
               case SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel:
               case SysmonEventFilteringRuleGroupProcessCreateParentImage:
               case SysmonEventFilteringRuleGroupProcessCreateParentCommandLine:
                  objects.Add(item);
                  break;
               default:
                  throw new NotImplementedException();
            }
         }

         return objects.ToArray();
      }

      internal static object[] GetExcludeRulesForDNS(this Sysmon config)
      {
         var objects = new List<object>();

         var excluded = config.EventFiltering.Items
                              .OfType<SysmonEventFilteringRuleGroup>()
                              .Where(c => c.DnsQuery?.Items.Length > 0 && c.DnsQuery?.onmatch == Constants.SysmonExcludeOnMatchString)
                              .Select(c => c.DnsQuery)
                              .ToList();

         foreach (var item in excluded.SelectMany(dnsExcludeGroup => dnsExcludeGroup.Items))
         {
            switch (item)
            {
               case SysmonEventFilteringRuleGroupDnsQueryImage:
               case SysmonEventFilteringRuleGroupDnsQueryQueryName:
                  objects.Add(item);
                  break;
               default:
                  throw new NotImplementedException();
            }
         }

         return objects.ToArray();
      }
      
   }
}
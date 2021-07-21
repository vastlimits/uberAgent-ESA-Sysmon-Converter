using System.Collections.Generic;
using System.Linq;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Extensions
{
   internal static class SysmonConfigExtensions
   {
      internal static SysmonEventFilteringRuleListed GetSysmonRulesListed(this Sysmon config)
      {
         var filteringRulesListed = new SysmonEventFilteringRuleListed();
         var filteringRulesListedProperties = filteringRulesListed.GetType().GetProperties();
         var filteringRuleGroups = config.EventFiltering.Items.OfType<SysmonEventFilteringRuleGroup>();

         var properties = typeof(SysmonEventFilteringRuleGroup).GetProperties();

         foreach (var rule in filteringRuleGroups)
         {
            var (currentRuleName, currentRuleValue) = properties.ToDictionary(prop => prop.Name, prop => prop.GetValue(rule, null))
                                                                               .FirstOrDefault(c => c.Value != null);
            var filteringRulesListedProperty = filteringRulesListedProperties
                                               .FirstOrDefault(c => c.Name.Equals(currentRuleName))
                                               ?.GetValue(filteringRulesListed, null);
            
            filteringRulesListedProperty?.GetType().GetMethod("Add")
                                        ?.Invoke(filteringRulesListedProperty, new[] {currentRuleValue});

            if (currentRuleValue == null)
               continue;

            var filteringRuleExtendedProperties = currentRuleValue.GetType().GetProperties();

            var filteringRuleExtendedName = filteringRuleExtendedProperties.FirstOrDefault(c => c.Name.Equals("name"));
            var filteringRuleExtendedGroupRelation =
               filteringRuleExtendedProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"));

            filteringRuleExtendedName?.SetValue(currentRuleValue, rule.name);
            filteringRuleExtendedGroupRelation?.SetValue(currentRuleValue, rule.groupRelation);
         }

         return filteringRulesListed;
      }

      internal static SysmonEventFilteringRuleGroupImageLoad FillItems(this SysmonEventFilteringRuleGroupImageLoad ruleGroup)
      {
         var items = new List<object>();

         if (ruleGroup.Image != null)
            items.Add(ruleGroup.Image);
         if (ruleGroup.ImageLoaded != null)
            items.AddRange(ruleGroup.ImageLoaded);
         if (ruleGroup.Rule != null)
            items.AddRange(ruleGroup.Rule);

         return new SysmonEventFilteringRuleGroupImageLoad
         {
            groupRelation = ruleGroup.groupRelation,
            onmatch = ruleGroup.onmatch,
            Items = items.ToArray()
         };
      }

      internal static SysmonEventFilteringRuleGroupNetworkConnect FillItems(this SysmonEventFilteringRuleGroupNetworkConnect ruleGroup)
      {
         var items = new List<object>();

         if (ruleGroup.Image != null)
            items.AddRange(ruleGroup.Image);
         if (ruleGroup.DestinationHostname != null)
            items.AddRange(ruleGroup.DestinationHostname);
         if (ruleGroup.DestinationIp != null)
            items.AddRange(ruleGroup.DestinationIp);
         if (ruleGroup.DestinationPort != null)
            items.AddRange(ruleGroup.DestinationPort);

         return new SysmonEventFilteringRuleGroupNetworkConnect
         {
            groupRelation = ruleGroup.groupRelation,
            onmatch = ruleGroup.onmatch,
            Items = items.ToArray()
         };
      }
   }
}

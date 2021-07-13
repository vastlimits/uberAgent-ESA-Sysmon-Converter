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
   }
}
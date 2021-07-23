using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.ActivityMonitoring;
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

         filteringRulesListed.ConfigGlobalSettings.HashAlgorithms = GetHashAlgorithms(config);

         return filteringRulesListed;
      }

      private static Hashes[] GetHashAlgorithms(Sysmon config)
      {
         if (string.IsNullOrEmpty(config.HashAlgorithms))
            return new Hashes[0];

         var hashesList = new List<Hashes>();
         var hashes = config.HashAlgorithms.ToLower().Trim().Split(',');
         foreach (var hash in hashes)
         {
            switch (hash)
            {
               case "md5":
                  hashesList.Add(Hashes.MD5);
                  break;
               case "sha1":
                  hashesList.Add(Hashes.SHA1);
                  break;
               case "sha256":
                  hashesList.Add(Hashes.SHA256);
                  break;
               case "imphash":
                  hashesList.Add(Hashes.IMP);
                  break;
            }
         }

         return hashesList.ToArray();
      }

   }
}

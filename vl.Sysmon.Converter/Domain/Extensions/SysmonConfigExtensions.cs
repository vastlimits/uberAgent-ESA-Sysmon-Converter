using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Extensions;

internal static class SysmonConfigExtensions
{
   internal static SysmonEventFilteringRuleListed GetSysmonRules(this Sysmon config, SysmonEventFilteringRuleListed groups)
   {
      if (config?.EventFiltering == null)
         return groups;

      var filteringRulesListedProperties = groups.GetType().GetProperties();

      var sysmonEventFilteringProperties = typeof(SysmonEventFiltering).GetProperties().Where(c => c.Name != "Items").ToArray();
      var eventsWithoutGroup = sysmonEventFilteringProperties.ToDictionary(prop => prop.Name,
         prop => prop.GetValue(config?.EventFiltering, null)).Where(c => c.Value != null).ToArray();

      foreach (var rule in eventsWithoutGroup)
      {
         var filteringRulesListedProperty = filteringRulesListedProperties.FirstOrDefault(c => c.Name.Equals(rule.Key))?.GetValue(groups, null);

         foreach (var ruleObject in ((Array)rule.Value))
         {
            var targetTypeName = $"vl.Sysmon.Converter.Domain.SysmonEventFilteringRuleGroup{rule.Key}";
            var targetType = Type.GetType(targetTypeName);
            var castMethod = targetType?.GetMethod("op_Implicit", new[] { ruleObject.GetType() });

            if (targetType == null || castMethod == null)
               continue;

            var convertedObject = castMethod?.Invoke(null, new[] { ruleObject });
            if (convertedObject == null)
               continue;

            filteringRulesListedProperty?.GetType().GetMethod("Add")?.Invoke(filteringRulesListedProperty, new[] { convertedObject });
         }
      }


      return groups;
   }

   internal static SysmonEventFilteringRuleListed GetSysmonRulesFromGroupListed(this Sysmon config)
   {
      var filteringRulesListed = new SysmonEventFilteringRuleListed();
      var filteringRulesListedProperties = filteringRulesListed.GetType().GetProperties();
      var filteringRuleGroups = config?.EventFiltering?.Items?.OfType<SysmonEventFilteringRuleGroup>();
      if (filteringRuleGroups == null)
         return filteringRulesListed;

      var properties = typeof(SysmonEventFilteringRuleGroup)
         .GetProperties()
         .Where(prop => prop.Name != nameof(SysmonEventFilteringRuleGroup.name) &&
                        prop.Name != nameof(SysmonEventFilteringRuleGroup.groupRelation));

      foreach (var rule in filteringRuleGroups)
      {
         foreach (var property in properties)
         {
            var currentRuleValue = property.GetValue(rule, null);
            if (currentRuleValue == null)
               continue;

            foreach (var eventRule in GetEventRules(currentRuleValue))
            {
               SetRuleGroupMetadata(eventRule, rule);

               var filteringRulesListedProperty = filteringRulesListedProperties
                  .FirstOrDefault(c => c.Name.Equals(property.Name))
                  ?.GetValue(filteringRulesListed, null);

               filteringRulesListedProperty?.GetType().GetMethod("Add")
                  ?.Invoke(filteringRulesListedProperty, new[] { eventRule });
            }
         }
      }

      return filteringRulesListed;
   }

   private static IEnumerable<object> GetEventRules(object value)
   {
      if (value is Array array)
      {
         foreach (var item in array)
         {
            if (item != null)
               yield return item;
         }
      }
      else
      {
         yield return value;
      }
   }

   private static void SetRuleGroupMetadata(object eventRule, SysmonEventFilteringRuleGroup ruleGroup)
   {
      var filteringRuleExtendedProperties = eventRule.GetType().GetProperties();
      var filteringRuleExtendedName = filteringRuleExtendedProperties.FirstOrDefault(c => c.Name.Equals("name"));
      var filteringRuleExtendedGroupRelation =
         filteringRuleExtendedProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"));

      filteringRuleExtendedName?.SetValue(eventRule, ruleGroup.name);
      filteringRuleExtendedGroupRelation?.SetValue(eventRule, ruleGroup.groupRelation);
   }

   private static Hashes[] GetHashAlgorithms(Sysmon config)
   {
      if (string.IsNullOrEmpty(config.HashAlgorithms))
         return Array.Empty<Hashes>();

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
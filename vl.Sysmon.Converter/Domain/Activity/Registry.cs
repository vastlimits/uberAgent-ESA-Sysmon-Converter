using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;
using vl.Core.Domain.Extensions;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class Registry : ConvertEntity
   {

      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupRegistryEvent> registryEvent)
      {
         if (registryEvent == null || registryEvent.Count == 0)
            return NothingToConvert("Registry");

         registryEvent = registryEvent.Where(c => c.Items is { Length: > 0 }).ToList();
         if (registryEvent.Count == 0)
            return NothingToConvert("Registry");

         try
         {
            Log.Information("Converting rules for Registry..");
            var result = new List<ActivityMonitoringRule>();

            // Check in all rule groups if we exclude a rule like SetValue
            var eventTypes = new List<EventType>
            {
               EventType.RegKeyCreate, EventType.RegKeyDelete, EventType.RegValueWrite, EventType.RegKeyRename
            };

            var excludeList = from ruleGroup in registryEvent
                      where ruleGroup.onmatch.Equals(Constants.SysmonExcludeOnMatchString) && ruleGroup.Items != null
                      select ruleGroup.Items.Where(c => c.GetType() ==
                                                        typeof(SysmonEventFilteringRuleGroupRegistryEventEventType))
                                      .ToList()
                      into toExcludeEventTypes
                      from SysmonEventFilteringRuleGroupRegistryEventEventType item in toExcludeEventTypes
                      select item;

            foreach (var item in excludeList)
            {
               switch (item.Value)
               {
                  case "SetValue":
                     eventTypes.Remove(EventType.RegValueWrite);
                     break;
                  case "CreateKey":
                     eventTypes.Remove(EventType.RegKeyCreate);
                     break;
                  case "DeleteKey":
                     eventTypes.Remove(EventType.RegKeyDelete);
                     break;
                  case "RenameKey":
                     eventTypes.Remove(EventType.RegKeyRename);
                     break;
               }
            }

            foreach (var ruleGroup in registryEvent)
            {
               var onMatch = ruleGroup.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               foreach (var eventType in eventTypes)
               {
                  var conditions = ParseRule(ruleGroup).ToArray();
                  var hive = Hive.All;

                  var canSpecifyHive =
                     conditions.All(c => c.Condition.Equals("is") || c.Condition.Equals("begin with"));
                  if (canSpecifyHive)
                  {
                     var hives = conditions.Where(c => c.Condition.Equals("is") || c.Condition.Equals("begin with"))
                                           .Select(c => c.Value.Split(@"\").FirstOrDefault()?.ToLower())
                                           .Distinct()
                                           .Where(c => !string.IsNullOrEmpty(c))
                                           .ToArray();

                     if (hives.Length == 1)
                        hive = hives.First().FromString();
                  }

                  var activityConverterSettings = new SysmonActivityMonitoringRule
                  {
                     EventType = eventType,
                     Name = ruleGroup.name,
                     Tag = ruleGroup.name,
                     Conditions = conditions,
                     MainGroupRelation = ruleGroup.groupRelation,
                     Hive = hive
                  };

                  if (activityConverterSettings.Conditions.Length == 0)
                     continue;

                  result.Add(Convert(activityConverterSettings));
               }
            }

            var convertedCount = eventTypes.Count > 0 ? result.Count / eventTypes.Count : 0;
            Log.Information("Converted {converted}/{rules} rules.", convertedCount, registryEvent.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for Registry.");
         }

         return NothingToConvert("Registry");
      }

   }
}

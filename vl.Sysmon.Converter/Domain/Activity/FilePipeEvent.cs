using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class FilePipeEvent : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupPipeEvent> fileCreateRulesGroup)
      {
         if (fileCreateRulesGroup == null || fileCreateRulesGroup.Count == 0)
            return NothingToConvert("FilePipeEvent");

         fileCreateRulesGroup = fileCreateRulesGroup.Where(c => c.Items is { Length: > 0 }).ToList();
         if (fileCreateRulesGroup.Count == 0)
            return NothingToConvert("FilePipeEvent");

         try
         {
            Log.Information("Converting rules for FilePipeEvent..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var ruleGroup in fileCreateRulesGroup)
            {
               var onMatch = ruleGroup.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               if (ruleGroup.Items == null || ruleGroup.Items.Length == 0)
                  continue;

               var activityConverterSettings = new SysmonActivityMonitoringRule
               {
                  EventType = EventType.FilePipeConnected,
                  Name = ruleGroup.name,
                  Tag = ruleGroup.name,
                  Conditions = ParseRule(ruleGroup).ToArray(),
                  MainGroupRelation = ruleGroup.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               var converted = Convert(activityConverterSettings);

               result.AddRange(new []
               {
                  converted,
                  new ActivityMonitoringRule()
                  {
                     EventType = EventType.FilePipeCreate,
                     Name = converted.Name,
                     Hive = converted.Hive,
                     Query = converted.Query,
                     Tag = converted.Tag,
                  }
               });
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count / 2, fileCreateRulesGroup.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for FileCreateStreamHash.");
         }

         return NothingToConvert("FileCreateStreamHash");
      }
   }
}
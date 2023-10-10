using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class FileCreateTime : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupFileCreateTime> fileCreateTimeRulesGroup)
      {
         if (fileCreateTimeRulesGroup == null || fileCreateTimeRulesGroup.Count == 0)
            return NothingToConvert("FileCreateTime");

         fileCreateTimeRulesGroup = fileCreateTimeRulesGroup.Where(c => c.Items is { Length: > 0 }).ToList();
         if (fileCreateTimeRulesGroup.Count == 0)
            return NothingToConvert("FileCreateTime");

         try
         {
            Log.Information("Converting rules for FileCreateTime..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var ruleGroup in fileCreateTimeRulesGroup)
            {
               var onMatch = ruleGroup.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               if (ruleGroup.Items == null || ruleGroup.Items.Length == 0)
                  continue;

               var activityConverterSettings = new SysmonActivityMonitoringRule
               {
                  Id = Guid.NewGuid(),
                  EventType = EventType.FileChangeCreationTime,
                  Name = ruleGroup.name,
                  Tag = ruleGroup.name,
                  Conditions = ParseRule(ruleGroup).ToArray(),
                  MainGroupRelation = ruleGroup.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, fileCreateTimeRulesGroup.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for FileCreateTime.");
         }

         return NothingToConvert("FileCreateTime");
      }
   }
}
using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class FileRawAccessRead : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupRawAccessRead> fileCreateRulesGroup)
      {
         if (fileCreateRulesGroup == null || fileCreateRulesGroup.Count == 0)
            return NothingToConvert("FileRawAccessRead");

         fileCreateRulesGroup = fileCreateRulesGroup.Where(c => c.Items is { Length: > 0 }).ToList();
         if (fileCreateRulesGroup.Count == 0)
            return NothingToConvert("FileRawAccessRead");

         try
         {
            Log.Information("Converting rules for FileRawAccessRead..");
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
                  Id = Guid.NewGuid(),
                  EventType = EventType.FileRawAccessRead,
                  Name = ruleGroup.name,
                  Tag = ruleGroup.name,
                  Conditions = ParseRule(ruleGroup).ToArray(),
                  MainGroupRelation = ruleGroup.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, fileCreateRulesGroup.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for FileRawAccessRead.");
         }

         return NothingToConvert("FileRawAccessRead");
      }
   }
}

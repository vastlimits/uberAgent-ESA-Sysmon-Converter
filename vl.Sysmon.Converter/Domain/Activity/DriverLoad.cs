using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity;

public class DriverLoad : ConvertEntity
{
   public static IEnumerable<ActivityMonitoringRule> ConvertRules(
      List<SysmonEventFilteringRuleGroupDriverLoad> driverLoadRulesGroup)
   {
      if (driverLoadRulesGroup == null || driverLoadRulesGroup.Count == 0)
         return NothingToConvert("DriverLoad");

      driverLoadRulesGroup = driverLoadRulesGroup.Where(c => c.Items is { Length: > 0 }).ToList();
      if (driverLoadRulesGroup.Count == 0)
         return NothingToConvert("DriverLoad");

      try
      {
         Log.Information("Converting rules for DriverLoad..");
         var result = new List<ActivityMonitoringRule>();

         foreach (var ruleGroup in driverLoadRulesGroup)
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
               EventType = EventType.DriverLoad,
               Name = ruleGroup.name,
               Tag = ruleGroup.name,
               Conditions = ParseRule(ruleGroup).ToArray(),
               MainGroupRelation = ruleGroup.groupRelation
            };

            if (activityConverterSettings.Conditions.Length == 0)
               continue;

            result.Add(Convert(activityConverterSettings));
         }

         Log.Information("Converted {converted}/{rules} rules.", result.Count, driverLoadRulesGroup.Count);
         return result.ToArray();
      }
      catch (Exception ex)
      {
         Log.Error(ex, $"Failure to convert rules for DriverLoad.");
      }

      return NothingToConvert("DriverLoad");
   }
}
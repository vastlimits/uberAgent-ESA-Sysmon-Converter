using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.ActivityMonitoring;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ImageLoad : Rule
   {
      public static ActivityMonitoringRule[] ConvertRules(
         List<SysmonEventFilteringRuleGroupImageLoad> imageLoadRules)
      {
         if (imageLoadRules == null || imageLoadRules.Count == 0)
            return new ActivityMonitoringRule[0];

         try
         {
            Log.Information("Converting rules for ImageLoad..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var rule in imageLoadRules)
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) &&
                   !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               var activityConverterSettings = new ActivityMonitoringConverterSettings
               {
                  EventType = new[] { EventType.ImageLoad },
                  Name = rule.name,
                  Tag = rule.name,
                  Conditions = ParseRule(rule).ToArray(),
                  MainGroupRelation = rule.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, imageLoadRules.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for ImageLoad.");
         }

         return new ActivityMonitoringRule[0];
      }
   }
}
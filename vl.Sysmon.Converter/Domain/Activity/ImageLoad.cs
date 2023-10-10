using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class ImageLoad : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupImageLoad> imageLoadRules)
      {
         if (imageLoadRules == null || imageLoadRules.Count == 0)
            return NothingToConvert("ImageLoad");

         imageLoadRules = imageLoadRules.Where(c => c.Items is { Length: > 0 }).ToList();
         if (imageLoadRules.Count == 0)
            return NothingToConvert("ImageLoad");

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

               if (rule.Items == null || rule.Items.Length == 0)
                  continue;

               var activityConverterSettings = new SysmonActivityMonitoringRule
               {
                  Id = Guid.NewGuid(),
                  EventType = EventType.ImageLoad,
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

         return NothingToConvert("ImageLoad");
      }
   }
}

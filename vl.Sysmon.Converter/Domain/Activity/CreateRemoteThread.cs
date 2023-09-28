using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class CreateRemoteThread : ConvertEntity
   {
      public static IEnumerable<ActivityMonitoringRule> ConvertRules(
         List<SysmonEventFilteringRuleGroupCreateRemoteThread> remoteThreadRules)
      {
         if (remoteThreadRules == null || remoteThreadRules.Count == 0)
            return NothingToConvert("CreateRemoteThread");

         remoteThreadRules = remoteThreadRules.Where(c => c.Items is { Length: > 0 }).ToList();
         if (remoteThreadRules.Count == 0)
            return NothingToConvert("CreateRemoteThread");

         try
         {
            Log.Information("Converting rules for CreateRemoteThread..");
            var result = new List<ActivityMonitoringRule>();

            foreach (var rule in remoteThreadRules)
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
                  EventType = EventType.ProcessCreateRemoteThread,
                  Name = rule.name,
                  Tag = rule.name,
                  Conditions = ParseRule(rule).ToArray(),
                  MainGroupRelation = rule.groupRelation
               };

               if (activityConverterSettings.Conditions.Length == 0)
                  continue;

               result.Add(Convert(activityConverterSettings));
            }

            Log.Information("Converted {converted}/{rules} rules.", result.Count, remoteThreadRules.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert rules for CreateRemoteThread.");
         }

         return NothingToConvert("CreateRemoteThread");
      }
   }
}

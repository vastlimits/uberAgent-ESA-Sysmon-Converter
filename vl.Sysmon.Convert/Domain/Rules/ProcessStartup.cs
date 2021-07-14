using System;
using System.Collections.Generic;
using System.Linq;
using vl.Core.Domain;
using vl.Core.Domain.ActivityMonitoring;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class ProcessStartup : Rule
   {
      public static ActivityMonitoringRule[] ConvertRules(
         List<SysmonEventFilteringRuleGroupProcessCreate> processCreateRules)
      {
         if (processCreateRules == null || processCreateRules.Count == 0)
            return new ActivityMonitoringRule[0];

         try
         {
            Log.Information("Converting rules for ProcessStartup..");

            var result = new List<ActivityMonitoringRule>();
            var eventType = EventType.ProcessStart;
            
            foreach (var rule in processCreateRules)
            {
               var onMatch = rule.onmatch.ToLower();
               if (!onMatch.Equals(Constants.SysmonExcludeOnMatchString) && !onMatch.Equals(Constants.SysmonIncludeOnMatchString))
                  continue;

               var ruleRelation = rule.groupRelation.ToLower();
               var conditions = new List<SysmonCondition>();
               var activityConverterSettings = new ActivityMonitoringConverterSettings
               {
                  EventType = eventType,
                  Name = rule.name,
                  Tag = rule.name,
               };
               
               foreach (var item in rule.Items)
               {
                  var activityMonitoringField = string.Empty;
                  var value = string.Empty;
                  var condition = string.Empty;

                  switch (item)
                  {
                     case SysmonEventFilteringRuleGroupProcessCreateImage c:
                        activityMonitoringField = c.Value.IndexOf('\\') > -1 ? "Process.Path" : "Process.Name";
                        value = c.Value;
                        condition = c.condition;
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateCommandLine c:
                        activityMonitoringField = "Process.CommandLine";

                        var quotes = c.Value.Count(c => c == '"');
                        if (quotes > 2 || !c.Value.TrimEnd().EndsWith('"'))
                           c.Value = c.Value.Trim().Replace("\"", "\\\"");

                        value = c.Value;
                        condition = c.condition;
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateOriginalFileName c:
                        // We cannot convert this rule because we currently do not read the original name from PE.
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel c:
                        // We cannot convert this rule because we currently do not read the IntegrityLevel of an image.
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateParentImage c:
                        activityMonitoringField = c.Value.IndexOf('\\') > -1 ? "Parent.Path" : "Parent.Name";
                        value = c.Value;
                        condition = c.condition;
                        break;
                     case SysmonEventFilteringRuleGroupProcessCreateParentCommandLine c:
                        activityMonitoringField = "Parent.CommandLine";
                        value = c.Value;
                        condition = c.condition;
                        break;
                     default:
                        Log.Warning("ProcessStartup filter rule not implemented: {item}", item);
                        break;
                  }

                  if (string.IsNullOrEmpty(activityMonitoringField) || string.IsNullOrEmpty(condition) || string.IsNullOrEmpty(value))
                     continue;
                  
                  conditions.Add(new SysmonCondition
                  {
                     GroupRelation = ruleRelation,
                     Field = activityMonitoringField,
                     Value = value,
                     Condition = condition,
                     OnMatch = rule.onmatch
                  });
               }

               activityConverterSettings.Conditions = conditions.ToArray();
               var a = Convert(activityConverterSettings);
            }

            Log.Information("Converted {count} rules.", result.Count);
            return result.ToArray();
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to convert exclude rules for ProcessStartup.");
         }

         return new ActivityMonitoringRule[0];
      }
   }
}

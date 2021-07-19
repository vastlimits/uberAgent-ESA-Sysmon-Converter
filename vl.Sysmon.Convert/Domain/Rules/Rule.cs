using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using vl.Core.Domain.ActivityMonitoring;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class Rule
   {
      protected static readonly ILogger Log = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();


      private static string ConvertQuery(string field, string condition, string value)
      {
         return condition switch
         {
            "is" => $"{field} == r\"{value}\"",
            "begin with" => $"istartswith({field}, r\"{value}\")",
            "end with" => $"iendswith({field}, r\"{value}\")",
            "contains" => $"icontains({field}, r\"{value}\")",
            "image" => $"icontains({field}, r\"{value}\")",
            _ => throw new NotImplementedException()
         };
      }

      private static string ConvertQuery(IReadOnlyList<SysmonCondition> conditions, string mainGroupRelation)
      {
         if (conditions == null || conditions.Count == 0)
            return string.Empty;

         var queryBuilder = new StringBuilder("Query = ");
         var exclude = conditions[0].OnMatch.Equals(Constants.SysmonExcludeOnMatchString);
         
         if (exclude)
            queryBuilder.Append("not ");

         var conditionsGrouped = conditions.GroupBy(c => c.RuleId).ToDictionary(c => c.Key, c=> c.ToList());

         for (var groupIndex = 0; groupIndex < conditionsGrouped.Count; groupIndex++)
         {
            var (_, value) = conditionsGrouped.ElementAt(groupIndex);
            var lastGroup = groupIndex + 1 == conditionsGrouped.Count;

            for (var i = 0; i < value.Count; i++)
            {
               var item = value[i];
               var lastValueInGroup = i + 1 == value.Count;
               var groupRelation = lastValueInGroup ? string.Empty : $" {item.GroupRelation} ";
               var query = string.Empty;
               item.Value = item.Value.Replace("%%", "%");

               switch (item.Condition)
               {
                  case "is":
                     query = $"{item.Field} == r\"{item.Value}\"{groupRelation}";
                     break;
                  case "begin with":
                     query = $"istartswith({item.Field}, r\"{item.Value}\"){groupRelation}";
                     break;
                  case "end with":
                     query = $"iendswith({item.Field}, r\"{item.Value}\"){groupRelation}";
                     break;
                  case "image":
                  case "contains":
                     query = $"icontains({item.Field}, r\"{item.Value}\"){groupRelation}";
                     break;
                  case "is not":
                     query = $"{item.Field} != r\"{item.Value}\"{groupRelation}";
                     break;
                  default:
                     Log.Error("Condition: {condition} is not implemented.", item.Condition);
                     throw new NotImplementedException();
               }

               if (string.IsNullOrEmpty(query))
                  continue;

               queryBuilder.Append(i == 0 ? $"({query}" : lastValueInGroup && !lastGroup ? $"{query}) {mainGroupRelation} " : lastValueInGroup && lastGroup ? $"{query})" : $"{query}");
            }
         }

         if (exclude)
            queryBuilder.Append(")");

         return queryBuilder.ToString();
      }

      protected static ActivityMonitoringRule Convert(ActivityMonitoringConverterSettings settings)
      {
         return new()
         {
            EventType = settings.EventType,
            RuleName = settings.Name,
            Tag = settings.Name,
            Query = ConvertQuery(settings.Conditions, settings.MainGroupRelation),
         };
      }

      protected static EventDataFilter Convert(EventFilterConverterSettings settings)
      {
         return new()
         {
            Action = settings.Action,
            Fields = new List<string>(),
            Sourcetypes = settings.Sourcetypes,
            Query = ConvertQuery(settings.Field, settings.Condition, settings.Value),
            Comment = settings.Comment
         };
      }

      protected static IEnumerable<SysmonCondition> ParseRule(object rule)
      {
         var conditions = new List<SysmonCondition>();
         var ruleId = 0;
         if (rule == null)
         {
            Log.Error("Item can't be null!");
            throw new ArgumentNullException(nameof(rule));
         }

         var ruleProperties = rule.GetType().GetProperties();
         var itemsProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Items"))?.GetValue(rule, null);
         var onMatchProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("onmatch"))?.GetValue(rule, null)?.ToString();
         var groupRelationProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"))?.GetValue(rule, null).ToString().ToLower();

         if (itemsProperty == null)
            return conditions;
         
         if (itemsProperty is not IList ruleItems || ruleItems.Count == 0)
            return conditions;

         foreach (var item in ruleItems)
         {
            var ruleItemName = item?.ToString();

            if (item == null || string.IsNullOrEmpty(ruleItemName))
               continue;

            if (ruleItemName.EndsWith("Rule"))
            {
               conditions.AddRange(ParseInnerRule(item, ++ruleId, onMatchProperty));
               continue;
            }

            var baseProperties = CreateSysmonBaseCondition(item);
            if (baseProperties == null)
               continue;

            conditions.Add(new SysmonCondition
            {
               GroupRelation = groupRelationProperty,
               Field = baseProperties.Field,
               Value = baseProperties.Value,
               Condition = baseProperties.Condition,
               OnMatch = onMatchProperty,
               RuleId = 0
            });
         }

         return conditions;
      }

      private static IEnumerable<SysmonCondition> ParseInnerRule(object rule, int ruleId, string onMatch)
      {
         var conditions = new List<SysmonCondition>();
         
         if (rule == null)
         {
            Log.Error("Item can't be null!");
            throw new ArgumentNullException(nameof(rule));
         }

         var ruleProperties = rule.GetType().GetProperties();
         var itemsProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Items"))?.GetValue(rule, null);
         var groupRelationProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"))?.GetValue(rule, null).ToString().ToLower();

         if (itemsProperty == null)
            return conditions;

         if (itemsProperty is not IList ruleItems || ruleItems.Count == 0)
            return conditions;

         foreach (var item in ruleItems)
         {
            var baseCondition = CreateSysmonBaseCondition(item);
            if (baseCondition == null)
               continue;

            conditions.Add(new SysmonCondition
            {
               RuleId = ruleId,
               GroupRelation = groupRelationProperty,
               Field = baseCondition.Field,
               Value = baseCondition.Value,
               Condition = baseCondition.Condition,
               OnMatch = onMatch,
            });
         }

         return conditions;
      }

      private static SysmonConditionBase CreateSysmonBaseCondition(object item)
      {
         if (item == null)
         {
            Log.Error("Item can't be null!");
            throw new ArgumentNullException(nameof(item));
         }

         var itemName = item.ToString();
         if (string.IsNullOrEmpty(itemName))
         {
            Log.Error("ItemName is empty.");
            return new SysmonConditionBase();
         }
         
         var itemProperties = item.GetType().GetProperties();
         var itemValue = itemProperties.FirstOrDefault(c => c.Name.Equals("Value"))?.GetValue(item, null)?.ToString();
         var itemCondition = itemProperties.FirstOrDefault(c => c.Name.Equals("condition"))?.GetValue(item, null)?.ToString();

         if (string.IsNullOrEmpty(itemValue) || string.IsNullOrEmpty(itemCondition))
            return null;

         if (itemName.EndsWith("ParentImage"))
         {
            return new SysmonConditionBase
            {
               Field = itemValue.IndexOf('\\') > -1 ? "Parent.Path" : "Parent.Name",
               Condition = itemCondition,
               Value = itemValue
            };
         }
         if (itemName.EndsWith("Image"))
         {
            return new SysmonConditionBase
            {
               Field = itemValue.IndexOf('\\') > -1 ? "Process.Path" : "Process.Name",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("CommandLine"))
         {
            var quotes = itemValue.Count(c => c == '"');
            if (quotes > 2 || !itemValue.TrimEnd().EndsWith('"'))
               itemValue = itemValue.Trim().Replace("\"", "\\\"");

            if (itemName.EndsWith("ParentCommandLine"))
            {
               return new SysmonConditionBase
               {
                  Field = "Parent.CommandLine",
                  Condition = itemCondition,
                  Value = itemValue
               };
            }
            
            return new SysmonConditionBase
            {
               Field = "Process.CommandLine",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("DestinationPort"))
         {
            return new SysmonConditionBase
            {
               Field = "Net.Target.Port",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("DestinationHostname"))
         {
            return new SysmonConditionBase
            {
               Field = "Net.Target.Name",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("DestinationIp"))
         {
            return new SysmonConditionBase
            {
               Field = "Net.Target.Ip",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("OriginalFileName") || itemName.EndsWith("IntegrityLevel"))
            return null;

         Log.Warning("Filter rule not implemented: {item}", itemName);
         return null;
      }
   }
}

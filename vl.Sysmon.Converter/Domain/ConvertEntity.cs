using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using vl.Core.Domain.Activity;
using vl.Core.Domain.EventData;
using vl.Sysmon.Converter.Domain.Activity;
using vl.Sysmon.Converter.Domain.EventData;

namespace vl.Sysmon.Converter.Domain
{
   public class ConvertEntity
   {
      protected static readonly ILogger Log = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();

      private static readonly List<string> NotSupportedItemCache = new (); 

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

         var queryBuilder = new StringBuilder();
         var exclude = conditions[0].OnMatch.Equals(Constants.SysmonExcludeOnMatchString);
         
         if (exclude)
            queryBuilder.Append("not (");

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
               var stringType = "r";
               item.Value = item.Value.Replace("%%", "%");

               if (item.Value.EndsWith(@"\") && !item.Value.EndsWith(@"\\"))
               {
                  item.Value = item.Value.Replace(@"\", @"\\");
                  stringType = string.Empty;
               }

               switch (item.Condition)
               {
                  case "is":
                     query = $"{item.Field} == {stringType}\"{item.Value}\"{groupRelation}";
                     break;
                  case "begin with":
                     query = $"istartswith({item.Field}, {stringType}\"{item.Value}\"){groupRelation}";
                     break;
                  case "end with":
                     query = $"iendswith({item.Field}, {stringType}\"{item.Value}\"){groupRelation}";
                     break;
                  case "image":
                  case "contains":
                     query = $"icontains({item.Field}, {stringType}\"{item.Value}\"){groupRelation}";
                     break;
                  case "contains all":
                  case "contains any":
                     // Currently there is no uAQL function for contains 'all' or 'any'.
                     bool containsAll = item.Condition.EndsWith("all");
                     var splittedItemCondition = item.Value.Split(';').Select(x => $"{x.Trim()}").ToArray();
                     var relation = containsAll ? " and " : " or ";

                     foreach (var s in splittedItemCondition)
                     {
                        if (s.EndsWith(@"\") && !s.EndsWith(@"\\"))
                        {
                           query = query + $"icontains({item.Field}, \"{s.Replace(@"\", @"\\")}\"){relation}";
                        }
                        else
                        {
                           query = query + $"icontains({item.Field}, {stringType}\"{s}\"){relation}";
                        }
                     }

                     query = query.Remove(query.Length - relation.Length, relation.Length);

                     if (!lastValueInGroup)
                        query += $" {mainGroupRelation} ";

                     break;
                  case "is not":
                     query = $"{item.Field} != {stringType}\"{item.Value}\"{groupRelation}";
                     break;
                  default:
                     Log.Error("Condition: {condition} is not implemented.", item.Condition);
                     throw new NotImplementedException();
               }

               if (string.IsNullOrEmpty(query))
                  continue;

               queryBuilder.Append(i == 0 && !lastValueInGroup ? $"({query}" : lastValueInGroup && !lastGroup ? $"{query}) {mainGroupRelation} " : lastValueInGroup && lastGroup ? $"{query})" : $"{query}");
            }
         }

         if (exclude)
            queryBuilder.Append(")");

         return queryBuilder.ToString();
      }

      protected static ActivityMonitoringRule Convert(SysmonActivityMonitoringRule monitoringRule)
      {
         return new()
         {
            EventType = monitoringRule.EventType,
            Name = monitoringRule.Name,
            Tag = monitoringRule.Name,
            Query = ConvertQuery(monitoringRule.Conditions, monitoringRule.MainGroupRelation),
         };
      }

      protected static EventDataFilter Convert(SysmonEventDataFilter filter)
      {
         return new()
         {
            Action = filter.Action,
            Fields = new List<string>(),
            Sourcetypes = filter.Sourcetypes,
            Query = ConvertQuery(filter.Field, filter.Condition, filter.Value),
            Comment = filter.Comment
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
         var itemsProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Items") || c.Name.Equals("Image"))?.GetValue(rule, null);
         var onMatchProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("onmatch"))?.GetValue(rule, null)?.ToString();
         var groupRelationProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"))?.GetValue(rule, null)?.ToString()?.ToLower();

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
               var innerRuleResult = ParseInnerRule(item, ++ruleId, onMatchProperty)?.ToArray();
               if (innerRuleResult == null || innerRuleResult.Length == 0)
                  continue;

               conditions.AddRange(innerRuleResult);
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

         if (itemsProperty == null || itemsProperty is not IList ruleItems || ruleItems.Count == 0)
         {
            // Check if we have an imageload rule here
            ruleItems = new List<object>();

            var image = ruleProperties.Any(c => c.Name.EndsWith("Image") || c.Name.EndsWith("ImageLoaded"));
            if (!image)
               throw new NotImplementedException(nameof(rule));
            
            var imageProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Image"))?.GetValue(rule, null);
            var imageLoadedProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("ImageLoaded"))?.GetValue(rule, null);
            
            if (imageProperty != null)
               ruleItems.Add(imageProperty);

            if (imageLoadedProperty != null)
               ruleItems.Add(imageLoadedProperty);
         }

         foreach (var item in ruleItems)
         {
            var baseCondition = CreateSysmonBaseCondition(item);
            if (baseCondition == null)
               return null;

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

         // EventType is ignored here because we have already read it before.
         if (itemName.EndsWith("EventType"))
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

         if (itemName.EndsWith("User"))
         {
            return new SysmonConditionBase
            {
               Field = "Process.User",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("ProcessId"))
         {
            if (itemName.EndsWith("ParentProcessId"))
            {
               return new SysmonConditionBase
               {
                  Field = "Parent.Id",
                  Condition = itemCondition,
                  Value = itemValue
               };
            }
            return new SysmonConditionBase
            {
               Field = "Process.Id",
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

         if (itemName.EndsWith("TargetObject"))
         {
            return new SysmonConditionBase
            {
               Field = "Reg.Key.Target",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("ImageLoaded"))
         {
            return new SysmonConditionBase
            {
               Field = itemValue.IndexOf('\\') > -1 ? "Image.Path" : "Image.Name",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("Hashes"))
         {
            if (itemName.EndsWith("ImageLoadHashes"))
            {
               return new SysmonConditionBase
               {
                  Field = "Image.Hashes",
                  Condition = itemCondition,
                  Value = itemValue
               };
            }

            return new SysmonConditionBase
            {
               Field = "Process.Hashes",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("TerminalSessionId"))
         {
            return new SysmonConditionBase
            {
               Field = "Process.SessionId",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("Protocol"))
         {
            return new SysmonConditionBase
            {
               Field = "Net.Target.Protocol",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("Signed"))
         {
            return new SysmonConditionBase
            {
               Field = "Image.IsSigned",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("Signature"))
         {
            return new SysmonConditionBase
            {
               Field = "Image.Signature",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         if (itemName.EndsWith("SignatureStatus"))
         {
            return new SysmonConditionBase
            {
               Field = "Image.SignatureStatus",
               Condition = itemCondition,
               Value = itemValue
            };
         }

         var notSupported = CheckNotSupported(itemName);
         if (notSupported)
            return null;

         Log.Warning("Filter rule not implemented: {item}", itemName);
         return null;
      }

      private static bool CheckNotSupported(string itemName)
      {
         if (NotSupportedItemCache.Contains(itemName))
            return true;

         if (itemName.EndsWith("OriginalFileName") || itemName.EndsWith("IntegrityLevel") || itemName.EndsWith("CurrentDirectory") || itemName.EndsWith("UtcTime") || itemName.EndsWith("Guid") || itemName.EndsWith("LogonId") || itemName.Contains("NetworkConnect") || itemName.EndsWith("Details"))
         {
            Log.Warning("Filter rule currently not supported: {item}", itemName);
            NotSupportedItemCache.Add(itemName);
            return true;
         }

         return false;
      }
   }
}

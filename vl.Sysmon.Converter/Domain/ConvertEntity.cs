using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Serilog;
using vl.Core.Domain.Activity;
using vl.Core.Domain.Attributes;
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
               item.Value = item.Value.Replace("%%", "%");

               if (item.Value.EndsWith(@"\") && !item.Value.EndsWith(@"\\"))
                  item.Value = item.Value.Replace(@"\", @"\\");

               switch (item.Condition)
               {
                  case "is":
                     query = $"{item.Field} == {item.GetValueFormated()}{groupRelation}";
                     break;
                  case "begin with":
                     query = $"istartswith({item.Field}, {item.GetValueFormated()}){groupRelation}";
                     break;
                  case "end with":
                     query = $"iendswith({item.Field}, {item.GetValueFormated()}){groupRelation}";
                     break;
                  case "image":
                  case "contains":
                     query = $"icontains({item.Field}, {item.GetValueFormated()}){groupRelation}";
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
                           query = query + $"icontains({item.Field}, \"{s}\"){relation}";
                        }
                     }

                     query = query.Remove(query.Length - relation.Length, relation.Length);

                     if (!lastValueInGroup)
                        query += $" {mainGroupRelation} ";

                     break;
                  case "is not":
                     query = $"{item.Field} != {item.GetValueFormated()}{groupRelation}";
                     break;
                  case "excludes":
                     query = $"icontains({item.Field}, {item.GetValueFormated()}){groupRelation} == false";
                     break;
                  case "excludes any":
                  case "excludes all":
                     // Currently there is no uAQL function for contains 'all' or 'any'.
                     bool excludesAll = item.Condition.EndsWith("all");
                     splittedItemCondition = item.Value.Split(';').Select(x => $"{x.Trim()}").ToArray();
                     relation = excludesAll ? " and " : " or ";

                     foreach (var s in splittedItemCondition)
                     {
                        if (s.EndsWith(@"\") && !s.EndsWith(@"\\"))
                        {
                           query = query + $"icontains({item.Field}, \"{s.Replace(@"\", @"\\")}\") == false{relation}";
                        }
                        else
                        {
                           query = query + $"icontains({item.Field}, \"{s}\") == false{relation}";
                        }
                     }

                     query = query.Remove(query.Length - relation.Length, relation.Length);

                     if (!lastValueInGroup)
                        query += $" {mainGroupRelation} ";

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
            Hive = monitoringRule.Hive
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
         var itemsProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Items") || c.Name.Equals("Image") || c.Name.Equals("Rule"))?.GetValue(rule, null);
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
               DataType = baseProperties.DataType,
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

            var image = ruleProperties.Any(c => c.Name.EndsWith("Image") || c.Name.EndsWith("ImageLoaded") || c.Name.EndsWith("Signature") || c.Name.EndsWith("SignatureStatus"));
            if (!image)
               throw new NotImplementedException(nameof(rule));
            
            var imageProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Image"))?.GetValue(rule, null);
            var imageLoadedProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("ImageLoaded"))?.GetValue(rule, null);
            var signatureProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Signature"))?.GetValue(rule, null);
            var signatureStatusProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("SignatureStatus"))?.GetValue(rule, null);

            if (imageProperty != null)
               ruleItems.Add(imageProperty);

            if (imageLoadedProperty != null)
               ruleItems.Add(imageLoadedProperty);

            if (signatureProperty != null)
               ruleItems.Add(signatureProperty);

            if (signatureStatusProperty != null)
               ruleItems.Add(signatureStatusProperty);
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

      [TransformFieldPath("ParentImage", "Parent.Name", "Parent.Path", TransformMethod.RemoveTrailingBackslashes)]
      [TransformFieldPath("Image", "Process.Name", "Process.Path", TransformMethod.RemoveTrailingBackslashes)]
      [TransformField("User", "Process.User")]
      [TransformField("ParentProcessId", "Parent.Id", TransformDataType.Int)]
      [TransformField("ProcessId", "Process.Id", TransformDataType.Int)]
      [TransformField("ParentCommandLine", "Parent.CommandLine", TransformMethod.RemoveTrailingBackslashes)]
      [TransformField("CommandLine", "Process.CommandLine", TransformMethod.RemoveTrailingBackslashes)]
      [TransformField("DestinationPort", "Net.Target.Port", TransformDataType.Int)]
      [TransformField("DestinationHostname", "Net.Target.Name")]
      [TransformField("DestinationIp", "Net.Target.Ip")]
      [TransformField("TargetObject", "Reg.Key.Target")]
      [TransformFieldPath("ImageLoaded", "Image.Name", "Image.Path", TransformMethod.RemoveTrailingBackslashes)]
      [TransformField("ImageLoadHashes", "Image.Hashes")]
      [TransformField("Hashes", "Process.Hashes")]
      [TransformField("TerminalSessionId", "Process.SessionId", TransformDataType.Int)]
      [TransformField("Protocol", "Net.Target.Protocol")]
      [TransformField("Signed", "Image.IsSigned")]
      [TransformField("Signature", "Image.Signature")]
      [TransformField("SignatureStatus", "Image.SignatureStatus")]
      [TransformField("NewThreadId", "Thread.Id", TransformDataType.Int)]
      [TransformField("StartAddress", "Thread.StartAddress")]
      [TransformField("StartModule", "Thread.StartModule")]
      [TransformField("StartFunction", "Thread.StartFunction")]
      [FieldNotSupported("OriginalFileName", "uberAgent currently does not support reading the original name from the PE header.")]
      [FieldNotSupported("IntegrityLevel", "uberAgent currently does not support reading the integrity level.")]
      [FieldNotSupported("CurrentDirectory", "uberAgent currently does not support reading the current directory (working directory).")]
      [FieldNotSupported("UtcTime", "uberAgent currently does not export utctime.")]
      [FieldNotSupported("Guid", "uberAgent currently does not export any Guid.")]
      [FieldNotSupported("LogonId", "uberAgent currently does not support reading the logonId.")]
      [FieldNotSupported("Details", "uberAgent currently does not support written registry data.")]
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

         Func<object, SysmonConditionBase> methodAction = CreateSysmonBaseCondition;
         var methodInfo = methodAction.Method;

         // Check not supported fields first
         var notSupportedAttributes = methodInfo.GetCustomAttributes(typeof(FieldNotSupportedAttribute));
         foreach (var attribute in (IEnumerable<FieldNotSupportedAttribute>)notSupportedAttributes)
         {
            if (NotSupportedItemCache.Contains(itemName))
               return null;

            if (itemName.EndsWith(attribute.SourceField))
            {
               Log.Warning(Constants.RuleNotSupportedTemplate, attribute.SourceField, attribute.Reason);
               NotSupportedItemCache.Add(itemName);
               return null;
            }
         }

         // Creating our SysmonCondition
         var attributes = methodInfo.GetCustomAttributes(typeof(TransformFieldBaseAttribute));
         foreach (var attribute in (IEnumerable<TransformFieldBaseAttribute>)attributes)
         {
            if (itemName.EndsWith(attribute.SourceField))
            {
               return new SysmonConditionBase
               {
                  Field = attribute.GetTargetField(itemValue),
                  Condition = itemCondition,
                  Value = attribute.TransformValue(itemValue),
                  DataType = attribute.GetDataType()
               };
            }
         }

         Log.Warning("Filter rule not implemented: {item}", itemName);
         return null;
      }

      protected static ActivityMonitoringRule[] NothingToConvert(string activity)
      {
         Log.Information("Nothing to convert for activity: {0}", activity);
         return Array.Empty<ActivityMonitoringRule>();
      }
   }
}

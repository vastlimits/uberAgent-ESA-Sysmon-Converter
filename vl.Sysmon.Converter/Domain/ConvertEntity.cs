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
   public static class ConvertEntity
   {
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
            queryBuilder.Append("not ");

         var conditionsGrouped = conditions.GroupBy(c => c.RuleId).ToDictionary(c => c.Key, c=> c.ToList());

         for (var groupIndex = 0; groupIndex < conditionsGrouped.Count; groupIndex++)
         {
            var (_, sysmonConditions) = conditionsGrouped.ElementAt(groupIndex);
            var innerRuleRelation = string.Empty;

            // new start of rule converting
            if (groupIndex == 0)
               queryBuilder.Append("((");
            else
            // inner rule converting
               queryBuilder.Append($") {mainGroupRelation} (");

            var sysmonConditionsGroupedByField = sysmonConditions.GroupBy(c => c.Field).ToArray();

            for (var i = 0; i < sysmonConditionsGroupedByField.Length; i++)
            {
               var lastValueInGroupFields = i + 1 == sysmonConditionsGroupedByField.Length;
               var group = sysmonConditionsGroupedByField[i];
               var groupArray = group.ToArray();
               for (var d = 0; d < groupArray.Length; d++)
               {
                  var item = group.ElementAt(d);
                  var lastValueInGroup = d + 1 == groupArray.Length;
                  var groupRelation = lastValueInGroup ? string.Empty : " or ";
                  var query = string.Empty;
                  item.Value = item.Value.Replace("%%", "%");
                  innerRuleRelation = item.GroupRelation;

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
                              query += $"icontains({item.Field}, \"{s.Replace(@"\", @"\\")}\"){relation}";
                           }
                           else
                           {
                              query += $"icontains({item.Field}, \"{s}\"){relation}";
                           }
                        }

                        query = query.Remove(query.Length - relation.Length, relation.Length);

                        if (!lastValueInGroup)
                           query += $" {mainGroupRelation} ";

                        break;
                     case "is not":
                        query = $"{item.Field} != {item.GetValueFormated()}{groupRelation}";
                        break;
                     case "not end with":
                        query = $"iendswith({item.Field}, {item.GetValueFormated()}) == false{groupRelation}";
                        break;
                     case "excludes":
                        query = $"icontains({item.Field}, {item.GetValueFormated()}) == false{groupRelation}";
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
                              query += $"icontains({item.Field}, \"{s.Replace(@"\", @"\\")}\") == false{relation}";
                           }
                           else
                           {
                              query += $"icontains({item.Field}, \"{s}\") == false{relation}";
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
                  
                  queryBuilder.Append($"{query}");
               }

               if (!lastValueInGroupFields)
               {
                  if (groupIndex == 0)
                     queryBuilder.Append($" {mainGroupRelation} ");
                  else
                     queryBuilder.Append($" {innerRuleRelation} ");
               }

            }
         }

         // close rule
         queryBuilder.Append("))");

         return queryBuilder.ToString();
      }

      public static string Convert(SysmonCondition[] conditions, string mainGroupRelation) => ConvertQuery(conditions, mainGroupRelation);

      public static EventDataFilter Convert(SysmonEventDataFilter filter)
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

      public static IEnumerable<SysmonCondition> ParseRule(object rule)
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
         var groupRelationProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"))?.GetValue(rule, null)?.ToString()?.ToLower();

         if (itemsProperty == null)
            return conditions;
         
         if (itemsProperty is not IList<object> ruleItems || ruleItems.Count == 0)
            return conditions;

         var groupedRuleItems = ruleItems.GroupBy(c => c.ToString());

         foreach (var groupOfRules in groupedRuleItems)
         {
            foreach (var item in groupOfRules)
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

         if (itemsProperty is not IList<object> ruleItems || ruleItems.Count == 0)
         {
            // Check if we have an imageload rule here
            ruleItems = new List<object>();

            var hasItems = ruleProperties.Any(c => c.Name.EndsWith("Items"));
            if (!hasItems)
               throw new NotImplementedException(nameof(rule));

            foreach (var item in ruleItems)
            {
               ruleItems.Add(item);
            }
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
               DataType = baseCondition.DataType,
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
      [TransformFieldPath("TargetFilename", "File.Name", "File.Path", TransformMethod.RemoveTrailingBackslashes)]
      [TransformFieldPath("PipeName", "File.Name", "File.Path", TransformMethod.RemoveTrailingBackslashes)]
      [TransformField("IsExecutable", "File.HasExecPermissions")]
      [FieldNotSupported("OriginalFileName", "uberAgent currently does not support reading the original name from the PE header.")]
      [FieldNotSupported("IntegrityLevel", "uberAgent currently does not support reading the integrity level.")]
      [FieldNotSupported("CurrentDirectory", "uberAgent currently does not support reading the current directory (working directory).")]
      [FieldNotSupported("UtcTime", "uberAgent currently does not export utctime.")]
      [FieldNotSupported("Guid", "uberAgent currently does not export any Guid.")]
      [FieldNotSupported("LogonId", "uberAgent currently does not support reading the logonId.")]
      [FieldNotSupported("Details", "uberAgent currently does not support written registry data.")]
      [FieldNotSupported("Contents", "uberAgent currently does not support Contents field.")]
      [FieldNotSupported("Archived", "uberAgent currently does not support Archived field.")]
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

         if (string.IsNullOrEmpty(itemValue))
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
                  Condition = itemCondition ?? "is",
                  Value = attribute.TransformValue(itemValue),
                  DataType = attribute.GetDataType()
               };
            }
         }

         Log.Warning("Filter rule not implemented: {item}", itemName);
         return null;
      }

      public static ActivityMonitoringRule[] NothingToConvert(string activity)
      {
         Log.Information("Nothing to convert for activity: {0}", activity);
         return Array.Empty<ActivityMonitoringRule>();
      }
   }
}

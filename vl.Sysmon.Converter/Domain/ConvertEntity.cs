using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Serilog;
using vl.Core.Domain;
using vl.Core.Domain.Attributes;
using vl.Core.Domain.EventData;
using vl.Sysmon.Converter.Domain.EventData;

namespace vl.Sysmon.Converter.Domain;

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
         queryBuilder.Append("not (");

      var conditionsGrouped = conditions.GroupBy(c => c.RuleId).ToDictionary(c => c.Key, c=> c.ToList());

      for (var groupIndex = 0; groupIndex < conditionsGrouped.Count; groupIndex++)
      {
         var (_, sysmonConditions) = conditionsGrouped.ElementAt(groupIndex);

         if (groupIndex == 0)
            queryBuilder.Append("(");
         else
            queryBuilder.Append($") {mainGroupRelation} (");

         var groupRelation = string.Empty;
         var sysmonConditionsGroupedByField = sysmonConditions.GroupBy(c => c.SysmonOriginalFieldName).ToArray();

         for (var i = 0; i < sysmonConditionsGroupedByField.Length; i++)
         {
            var lastValueInGroupFields = i + 1 == sysmonConditionsGroupedByField.Length;

            var group = sysmonConditionsGroupedByField[i];
            var groupArray = group.ToArray();
            for (var d = 0; d < groupArray.Length; d++)
            {
               var item = group.ElementAt(d);
               var lastValueInGroup = d + 1 == groupArray.Length;

               groupRelation = item.GroupRelation;
               var innerRuleGroupRelation = lastValueInGroup ? string.Empty : $" or ";
               var query = string.Empty;
               item.Value = item.Value.Replace("%%", "%");

               if (item.Value.EndsWith(@"\") && !item.Value.EndsWith(@"\\"))
                  item.Value = item.Value.Replace(@"\", @"\\");

               switch (item.Condition)
               {
                  case "is":
                     query = $"{item.Field} == {item.GetValueFormated()}{innerRuleGroupRelation}";
                     break;
                  case "is any":
                     // Currently there is no uAQL function for contains 'all' or 'any'.
                     var splittedIsItemCondition = item.Value.Split(';').Select(x => $"{x.Trim()}").ToArray();

                     // Start the group with an opening parenthesis
                     query += "(";

                     foreach (var s in splittedIsItemCondition)
                     {
                        if (s.EndsWith(@"\") && !s.EndsWith(@"\\"))
                        {
                           query += $"{item.Field} == \"{s.Replace(@"\", @"\\")}\" or ";
                        }
                        else
                        {
                           query += $"{item.Field} == \"{s}\" or ";
                        }
                     }

                     query = query.Remove(query.Length - 4, 4);

                     // Close the group with a closing parenthesis
                     query += ")";

                     if (!lastValueInGroup)
                        query += $" {mainGroupRelation} ";

                     break;
                  case "begin with":
                     query = $"istartswith({item.Field}, {item.GetValueFormated()}){innerRuleGroupRelation}";
                     break;
                  case "end with":
                     query = $"iendswith({item.Field}, {item.GetValueFormated()}){innerRuleGroupRelation}";
                     break;
                  case "image":
                  case "contains":
                     query = $"icontains({item.Field}, {item.GetValueFormated()}){innerRuleGroupRelation}";
                     break;
                  case "contains all":
                  case "contains any":
                     // Currently there is no uAQL function for contains 'all' or 'any'.
                     bool containsAll = item.Condition.EndsWith("all");
                     var splittedItemCondition = item.Value.Split(';').Select(x => $"{x.Trim()}").ToArray();
                     var relation = containsAll ? " and " : " or ";

                     // Start the group with an opening parenthesis
                     query += "(";

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

                     // Close the group with a closing parenthesis
                     query += ")";

                     if (!lastValueInGroup)
                        query += $" {mainGroupRelation} ";

                     break;
                  case "is not":
                     query = $"{item.Field} != {item.GetValueFormated()}{innerRuleGroupRelation}";
                     break;
                  case "not end with":
                     query = $"iendswith({item.Field}, {item.GetValueFormated()}) == false{innerRuleGroupRelation}";
                     break;
                  case "excludes":
                     query = $"icontains({item.Field}, {item.GetValueFormated()}) == false{innerRuleGroupRelation}";
                     break;
                  case "excludes any":
                  case "excludes all":
                     // Currently there is no uAQL function for contains 'all' or 'any'.
                     bool excludesAll = item.Condition.EndsWith("all");
                     splittedItemCondition = item.Value.Split(';').Select(x => $"{x.Trim()}").ToArray();
                     relation = excludesAll ? " and " : " or ";

                     // Start the group with an opening parenthesis
                     query += "not (";

                     foreach (var s in splittedItemCondition)
                     {
                        if (s.EndsWith(@"\") && !s.EndsWith(@"\\"))
                        {
                           query += $"icontains({item.Field}, \"{s.Replace(@"\", @"\\")}\") {relation}";
                        }
                        else
                        {
                           query += $"icontains({item.Field}, \"{s}\") {relation}";
                        }
                     }

                     query = query.Remove(query.Length - relation.Length, relation.Length);

                     // Close the group with a closing parenthesis
                     query += ")";

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
               queryBuilder.Append($" {groupRelation} ");
            }
         }
      }

      // close rule
      queryBuilder.Append(")");

      // If exclude we need to clode bracket
      if (exclude)
         queryBuilder.Append(")");

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
      var groupRelationProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"))?.GetValue(rule, null)?.ToString()?.ToLower() ?? "or";

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
               var subRuleset = ParseSubRule(item, ++ruleId, onMatchProperty).ToList();
               if (subRuleset.Count == 0)
                  continue;

               var subRuleGroupRelation = subRuleset.FirstOrDefault()?.GroupRelation ?? "or";

               var removedUnsupported = subRuleset.RemoveAll(c => !c.IsSupportedByCurrentUberAgentVersion);
               if (removedUnsupported > 0 && subRuleGroupRelation.Contains("and"))
               {
                  Log.Warning("Found {0} unsupported rules in {1}, the entire rule is ignored due to logical concatenation <and>.", removedUnsupported, ruleItemName);
                  continue;
               }

               if (removedUnsupported > 0 && subRuleGroupRelation.Contains("or"))
               {
                  Log.Warning("Found {0} unsupported rules in {1}, only the unsupported rules have been removed, due to logical concatenation <or>.", removedUnsupported, ruleItemName);
               }

               conditions.AddRange(subRuleset);
               continue;
            }

            var baseProperties = CreateSysmonBaseCondition(item);
            if (baseProperties == null)
               continue;

            conditions.Add(new SysmonCondition
            {
               GroupRelation = groupRelationProperty,
               Field = baseProperties.Field,
               SysmonOriginalFieldName = baseProperties.SysmonOriginalFieldName,
               Value = baseProperties.Value.Replace("\r", string.Empty).Replace("\n", string.Empty).Trim(),
               DataType = baseProperties.DataType,
               Condition = baseProperties.Condition,
               OnMatch = onMatchProperty,
               RuleId = 0
            });
         }
      }

      return conditions;
   }

   private static IEnumerable<SysmonCondition> ParseSubRule(object rule, int ruleId, string onMatch)
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
            return new List<SysmonCondition>();

         conditions.Add(new SysmonCondition
         {
            RuleId = ruleId,
            GroupRelation = groupRelationProperty,
            SysmonOriginalFieldName = baseCondition.SysmonOriginalFieldName,
            Field = baseCondition.Field,
            Value = baseCondition.Value.Replace("\r", string.Empty).Replace("\n", string.Empty).Trim(),
            Condition = baseCondition.Condition,
            OnMatch = onMatch,
            DataType = baseCondition.DataType,
            IsSupportedByCurrentUberAgentVersion = baseCondition.IsSupportedByCurrentUberAgentVersion
         });
      }

      return conditions;
   }

   [TransformFieldPath("ParentImage", "Parent.Name", "Parent.Path", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_6_0)]
   [TransformFieldPath("Image", "Process.Name", "Process.Path", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_6_0)]
   [TransformFieldPath("ImageLoaded", "Image.Name", "Image.Path", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_6_0)]
   [TransformFieldPath("OriginalFileName", "Process.Name", "Process.Name", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_6_0)]
   [TransformField("FileVersion", "Process.AppVersion", UAVersion.UA_VERSION_6_0)]
   [TransformField("User", "Process.User", UAVersion.UA_VERSION_6_0)]
   [TransformField("Company", "Process.Company", UAVersion.UA_VERSION_6_0)]
   [TransformField("ParentProcessId", "Parent.Id", TransformDataType.Int, UAVersion.UA_VERSION_6_0)]
   [TransformField("ProcessId", "Process.Id", TransformDataType.Int, UAVersion.UA_VERSION_6_0)]
   [TransformField("ParentCommandLine", "Parent.CommandLine", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_6_0)]
   [TransformField("CommandLine", "Process.CommandLine", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_6_0)]
   [TransformField("DestinationPort", "Net.Target.Port", TransformDataType.Int, UAVersion.UA_VERSION_6_0)]
   [TransformField("DestinationHostname", "Net.Target.Name", UAVersion.UA_VERSION_6_0)]
   [TransformField("DestinationIp", "Net.Target.Ip", UAVersion.UA_VERSION_6_0)]
   [TransformField("Protocol", "Net.Target.Protocol", UAVersion.UA_VERSION_6_0)]
   [TransformField("TerminalSessionId", "Process.SessionId", TransformDataType.Int, UAVersion.UA_VERSION_6_0)]
   [TransformField("DestinationIp", "Net.Target.Ip", UAVersion.UA_VERSION_6_0)]
   [TransformField("DestinationHostname", "Net.Target.Name", UAVersion.UA_VERSION_6_0)]
   [TransformField("DestinationPort", "Net.Target.Port", UAVersion.UA_VERSION_6_0)]
   [TransformField("NewName", "Reg.Key.Path.New", UAVersion.UA_VERSION_6_0)]
   [TransformField("Signed", "Image.IsSigned", UAVersion.UA_VERSION_6_1)]
   [TransformField("Signature", "Image.Signature", UAVersion.UA_VERSION_6_1)]
   [TransformField("SignatureStatus", "Image.SignatureStatus", UAVersion.UA_VERSION_6_1)]
   [TransformField("TargetObject", "Reg.Key.Target", UAVersion.UA_VERSION_6_2)]
   [TransformField("ImageLoadHashes", "Image.Hashes", UAVersion.UA_VERSION_6_2)]
   [TransformField("Hashes", "Process.Hashes", UAVersion.UA_VERSION_6_2)]
   [TransformField("NewThreadId", "Thread.Id", TransformDataType.Int, UAVersion.UA_VERSION_6_2)]
   [TransformField("StartAddress", "Thread.StartAddress", UAVersion.UA_VERSION_6_2)]
   [TransformField("StartModule", "Thread.StartModule", UAVersion.UA_VERSION_6_2)]
   [TransformField("StartFunction", "Thread.StartFunctionName", UAVersion.UA_VERSION_6_2)]
   [TransformField("TargetImage", "Process.Path", UAVersion.UA_VERSION_6_2)]
   [TransformField("SourceProcessId", "Thread.Parent.Id", UAVersion.UA_VERSION_6_2)]
   [TransformField("TargetProcessId", "Thread.Process.Id", UAVersion.UA_VERSION_6_2)]
   [TransformField("SourceIsIpv6", "Net.Target.IpIsV6", UAVersion.UA_VERSION_6_2)]
   [TransformField("SourceIp", "Net.Source.Ip", UAVersion.UA_VERSION_6_2)]
   [TransformField("SourceHostname", "Net.Source.Name", UAVersion.UA_VERSION_6_2)]
   [TransformField("SourcePort", "Net.Source.Port", UAVersion.UA_VERSION_6_2)]
   [TransformField("SourcePortName", "Net.Source.PortName", UAVersion.UA_VERSION_6_2)]
   [TransformField("DestinationIsIpv6", "Net.Target.IpIsV6", UAVersion.UA_VERSION_6_2)]
   [TransformField("DestinationPortName", "Net.Target.PortName", UAVersion.UA_VERSION_6_2)]
   [TransformFieldPath("TargetFilename", "File.Name", "File.Path", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_7_1)]
   [TransformFieldPath("PipeName", "File.Name", "File.Path", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_7_1)]
   [TransformField("IsExecutable", "File.HasExecPermissions", UAVersion.UA_VERSION_7_1)]
   [TransformField("CreationUtcTime", "File.CreationDate", UAVersion.UA_VERSION_7_1)]
   [TransformField("PreviousCreationUtcTime", "File.PreviousCreationDate", UAVersion.UA_VERSION_7_1)]
   [TransformField("TargetObject", "Reg.TargetObject", UAVersion.UA_VERSION_7_2)]
   [TransformField("Details", "Reg.Value.Data", UAVersion.UA_VERSION_7_2)]

   [FieldNotSupported("IntegrityLevel", "uberAgent currently does not support reading the integrity level.")]
   [FieldNotSupported("CurrentDirectory", "uberAgent currently does not support reading the current directory (working directory).")]
   [FieldNotSupported("UtcTime", "uberAgent currently does not export utctime.")]
   [FieldNotSupported("Guid", "uberAgent currently does not export any Guid.")]
   [FieldNotSupported("LogonId", "uberAgent currently does not support reading the logonId.")]
   [FieldNotSupported("Contents", "uberAgent currently does not support Contents field.")]
   [FieldNotSupported("Archived", "uberAgent currently does not support Archived field.")]
   [FieldNotSupported("SourcePort", "uberAgent currently does not support SourcePort field.")]
   [FieldNotSupported("Product", "uberAgent currently does not support Product field.")]
   [FieldNotSupported("Description", "uberAgent currently does not support Description field.")]
   [FieldNotSupported("LogonGuid", "uberAgent currently does not support LogonGuid field.")]
   [FieldNotSupported("LogonId", "uberAgent currently does not support LogonId field.")]
   [FieldNotSupported("Initiated", "uberAgent currently does not support Initiated field.")]
   [FieldNotSupported("SourceProcessGuid", "uberAgent currently does not support SourceProcessGuid field.")]
   [FieldNotSupported("SourceImage", "uberAgent currently does not support SourceImage field.")]
   [FieldNotSupported("TargetProcessGuid", "uberAgent currently does not support TargetProcessGuid field.")]
   [FieldNotSupported("Device", "uberAgent currently does not support Device field.")]

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
      var fieldAttributes = ((IEnumerable<TransformFieldBaseAttribute>)attributes).Where(c => itemName.EndsWith(c.SourceField)).ToArray();
      if (fieldAttributes.Length > 0)
      {
         TransformFieldBaseAttribute selectedAttribute = null;

         foreach (var attribute in fieldAttributes.OrderByDescending(c => c.SupporteduAVersion))
         {
            if (attribute.IsSupportedByCurrentUberAgentVersion(Globals.Options.UAVersion))
            {
               selectedAttribute = attribute;
               break;
            }

            // This will hold the last attribute in case none are supported.
            selectedAttribute = attribute;
         }

         if (selectedAttribute != null)
         {
            return new SysmonConditionBase
            {
               Field = selectedAttribute.GetTargetField(itemValue),
               SysmonOriginalFieldName = selectedAttribute.SourceField,
               Condition = itemCondition ?? "is",
               Value = selectedAttribute.TransformValue(itemValue).Replace("\r", string.Empty).Replace("\n", string.Empty).Trim(),
               DataType = selectedAttribute.GetDataType(),
               IsSupportedByCurrentUberAgentVersion = selectedAttribute.IsSupportedByCurrentUberAgentVersion(Globals.Options.UAVersion),
            };
         }
      }

      Log.Warning("Filter rule not implemented: {item}", itemName);
      return null;
   }
}
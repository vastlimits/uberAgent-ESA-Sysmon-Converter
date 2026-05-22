using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Serilog;
using vl.Core.Domain;
using vl.Core.Domain.Activity;
using vl.Core.Domain.Attributes;

namespace vl.Sysmon.Converter.Domain;

public static class ConvertEntity
{
   private static string ConvertQuery(IReadOnlyList<SysmonCondition> conditions, string mainGroupRelation)
   {
      if (conditions == null || conditions.Count == 0)
         return string.Empty;

      return BuildRuleExpression(conditions, UaqExpressionFactory.ParseRelation(mainGroupRelation))?.ToQuery() ?? string.Empty;
   }

   public static string Convert(SysmonCondition[] conditions, string mainGroupRelation) => ConvertQuery(conditions, mainGroupRelation);

   private static UaqExpression BuildRuleExpression(IReadOnlyList<SysmonCondition> conditions, UaqRelation? groupRelation)
   {
      var ruleGroups = conditions.GroupBy(c => c.RuleId)
         .Select(c => new
         {
            RuleId = c.Key,
            Conditions = c.ToArray()
         })
         .ToArray();

      if (ruleGroups.Length == 0)
         return null;

      if (ruleGroups.Length == 1 && ruleGroups[0].RuleId == 0)
         return BuildConditionSet(ruleGroups[0].Conditions, groupRelation);

      var expressions = ruleGroups.Select(ruleGroup =>
      {
         var relation = ruleGroup.RuleId == 0
            ? null
            : UaqExpressionFactory.ParseRelation(ruleGroup.Conditions.FirstOrDefault()?.GroupRelation);

         return BuildConditionSet(ruleGroup.Conditions, relation);
      });

      return UaqExpressionFactory.Combine(groupRelation ?? UaqRelation.Or, expressions);
   }

   private static UaqExpression BuildConditionSet(IReadOnlyList<SysmonCondition> conditions, UaqRelation? groupRelation)
   {
      if (groupRelation.HasValue)
         return UaqExpressionFactory.Combine(groupRelation.Value, conditions.Select(CreateConditionExpression));

      var fieldExpressions = conditions.GroupBy(c => c.SysmonOriginalFieldName)
         .Select(BuildDefaultFieldExpression);

      return UaqExpressionFactory.Combine(UaqRelation.And, fieldExpressions);
   }

   private static UaqExpression BuildDefaultFieldExpression(IGrouping<string, SysmonCondition> fieldConditions)
   {
      var positiveExpressions = fieldConditions
         .Where(condition => !IsNegativeCondition(condition.Condition))
         .Select(CreateConditionExpression)
         .ToArray();
      var negativeExpressions = fieldConditions
         .Where(condition => IsNegativeCondition(condition.Condition))
         .Select(CreateConditionExpression)
         .ToArray();

      var fieldParts = new List<UaqExpression>();
      var positiveExpression = UaqExpressionFactory.Combine(UaqRelation.Or, positiveExpressions);
      if (positiveExpression != null)
         fieldParts.Add(positiveExpression);

      var negativeExpression = UaqExpressionFactory.Combine(UaqRelation.And, negativeExpressions);
      if (negativeExpression != null)
         fieldParts.Add(negativeExpression);

      return UaqExpressionFactory.Combine(UaqRelation.And, fieldParts);
   }

   private static UaqExpression CreateConditionExpression(SysmonCondition item)
   {
      var condition = (item.Condition ?? "is").Trim().ToLowerInvariant();
      var normalizedValue = NormalizeSysmonValue(item.Value);
      var values = IsMultiValueCondition(condition)
         ? SplitConditionValues(normalizedValue)
         : string.IsNullOrEmpty(normalizedValue)
            ? []
            : [normalizedValue];

      if (values.Length == 0)
      {
         Log.Warning("Ignoring empty Sysmon condition value for {field}.", item.SysmonOriginalFieldName);
         return null;
      }

      UaqExpression CompareValue(string value)
      {
         var formattedValue = FormatValue(item, value);
         return condition switch
         {
            "is" => new UaqPredicateExpression($"{item.MainField} == {formattedValue}"),
            "image" => new UaqPredicateExpression($"{item.MainField} == {formattedValue}"),
            "is not" => new UaqPredicateExpression($"{item.MainField} != {formattedValue}"),
            "begin with" => new UaqPredicateExpression($"istartswith({item.MainField}, {formattedValue})"),
            "not begin with" => new UaqPredicateExpression($"istartswith({item.MainField}, {formattedValue}) == false"),
            "end with" => new UaqPredicateExpression($"iendswith({item.MainField}, {formattedValue})"),
            "not end with" => new UaqPredicateExpression($"iendswith({item.MainField}, {formattedValue}) == false"),
            "contains" => new UaqPredicateExpression($"icontains({item.MainField}, {formattedValue})"),
            "excludes" => new UaqPredicateExpression($"icontains({item.MainField}, {formattedValue}) == false"),
            "less than" => new UaqPredicateExpression($"{item.MainField} < {formattedValue}"),
            "more than" => new UaqPredicateExpression($"{item.MainField} > {formattedValue}"),
            _ => throw new NotImplementedException()
         };
      }

      return condition switch
      {
         "is any" => UaqExpressionFactory.Combine(UaqRelation.Or, values.Select(value => new UaqPredicateExpression($"{item.MainField} == {FormatValue(item, value)}"))),
         "contains any" => UaqExpressionFactory.Combine(UaqRelation.Or, values.Select(value => new UaqPredicateExpression($"icontains({item.MainField}, {FormatValue(item, value)})"))),
         "contains all" => UaqExpressionFactory.Combine(UaqRelation.And, values.Select(value => new UaqPredicateExpression($"icontains({item.MainField}, {FormatValue(item, value)})"))),
         "excludes any" => new UaqNotExpression(UaqExpressionFactory.Combine(UaqRelation.And, values.Select(value => new UaqPredicateExpression($"icontains({item.MainField}, {FormatValue(item, value)})")))),
         "excludes all" => new UaqNotExpression(UaqExpressionFactory.Combine(UaqRelation.Or, values.Select(value => new UaqPredicateExpression($"icontains({item.MainField}, {FormatValue(item, value)})")))),
         _ => CompareValue(values.Single())
      };
   }

   private static bool IsNegativeCondition(string condition)
   {
      return (condition ?? "is").Trim().ToLowerInvariant() switch
      {
         "is not" => true,
         "not begin with" => true,
         "not end with" => true,
         "excludes" => true,
         "excludes any" => true,
         "excludes all" => true,
         _ => false
      };
   }

   private static bool IsMultiValueCondition(string condition)
   {
      return condition switch
      {
         "is any" => true,
         "contains any" => true,
         "contains all" => true,
         "excludes any" => true,
         "excludes all" => true,
         _ => false
      };
   }

   private static string NormalizeSysmonValue(string value) => (value ?? string.Empty).Replace("%%", "%").Trim();

   private static string[] SplitConditionValues(string value)
      => value.Split(';').Select(c => c.Trim()).Where(c => !string.IsNullOrEmpty(c)).ToArray();

   private static string FormatValue(SysmonConditionBase item, string value)
   {
      return item.DataType switch
      {
         TransformDataType.String => $"\"{EscapeString(value)}\"",
         TransformDataType.Int => value,
         _ => throw new ArgumentOutOfRangeException()
      };
   }

   private static string EscapeString(string value) => value.Replace(@"\", @"\\").Replace("\"", "\\\"");

   public static IEnumerable<SysmonCondition> ParseRule(EventType eventType, object rule)
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
      var groupRelationProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"))?.GetValue(rule, null)?.ToString()?.ToLowerInvariant();

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
               var subRuleset = ParseSubRule(eventType, item, ++ruleId, onMatchProperty).ToList();
               if (subRuleset.Count == 0)
                  continue;

               var subRuleGroupRelation = subRuleset.FirstOrDefault()?.GroupRelation;

               var removedUnsupported = subRuleset.RemoveAll(c => !c.IsSupportedByCurrentUberAgentVersion);
               if (removedUnsupported > 0 && !string.Equals(subRuleGroupRelation, "or", StringComparison.OrdinalIgnoreCase))
               {
                  Log.Warning("Found {0} unsupported rules in {1}, the entire rule is ignored due to logical concatenation <and> or default field semantics.", removedUnsupported, ruleItemName);
                  continue;
               }

               if (removedUnsupported > 0 && string.Equals(subRuleGroupRelation, "or", StringComparison.OrdinalIgnoreCase))
               {
                  Log.Warning("Found {0} unsupported rules in {1}, only the unsupported rules have been removed, due to logical concatenation <or>.", removedUnsupported, ruleItemName);
               }

               conditions.AddRange(subRuleset);
               continue;
            }

            var baseProperties = CreateSysmonBaseCondition(eventType, item);
            if (baseProperties == null)
               continue;

            conditions.Add(new SysmonCondition
            {
               GroupRelation = groupRelationProperty,
               MainField = baseProperties.MainField,
               Fields = baseProperties.Fields,
               SysmonOriginalFieldName = baseProperties.SysmonOriginalFieldName,
               Value = baseProperties.Value.Replace("\r", string.Empty).Replace("\n", string.Empty).Trim(),
               DataType = baseProperties.DataType,
               Condition = baseProperties.Condition,
               OnMatch = onMatchProperty,
               RuleId = 0,
               IsSupportedByCurrentUberAgentVersion = baseProperties.IsSupportedByCurrentUberAgentVersion
            });
         }
      }

      return conditions;
   }

   private static IEnumerable<SysmonCondition> ParseSubRule(EventType eventType, object rule, int ruleId, string onMatch)
   {
      var conditions = new List<SysmonCondition>();

      if (rule == null)
      {
         Log.Error("Item can't be null!");
         throw new ArgumentNullException(nameof(rule));
      }

      var ruleProperties = rule.GetType().GetProperties();
      var itemsProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("Items"))?.GetValue(rule, null);
      var groupRelationProperty = ruleProperties.FirstOrDefault(c => c.Name.Equals("groupRelation"))?.GetValue(rule, null)?.ToString()?.ToLowerInvariant();

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
         var baseCondition = CreateSysmonBaseCondition(eventType, item);
         if (baseCondition == null)
            return new List<SysmonCondition>();

         conditions.Add(new SysmonCondition
         {
            RuleId = ruleId,
            GroupRelation = groupRelationProperty,
            SysmonOriginalFieldName = baseCondition.SysmonOriginalFieldName,
            MainField = baseCondition.MainField,
            Fields = baseCondition.Fields,
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
   [TransformFieldPath("OriginalFileName", ".Name", ".Name", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_6_0)]
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
   [TransformField("SourcePort", "Net.Source.Port", TransformDataType.Int, UAVersion.UA_VERSION_6_2)]
   [TransformField("SourcePortName", "Net.Source.PortName", UAVersion.UA_VERSION_6_2)]
   [TransformField("DestinationIsIpv6", "Net.Target.IpIsV6", UAVersion.UA_VERSION_6_2)]
   [TransformField("DestinationPortName", "Net.Target.PortName", UAVersion.UA_VERSION_6_2)]
   [TransformField("TargetFilename", "File.Path", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_7_1)]
   [TransformFieldPath("PipeName", "File.Name", "File.Path", TransformMethod.RemoveTrailingBackslashes, UAVersion.UA_VERSION_7_1)]
   [TransformField("IsExecutable", "File.HasExecPermissions", UAVersion.UA_VERSION_7_1)]
   [TransformField("CreationUtcTime", "File.CreationDate", UAVersion.UA_VERSION_7_1)]
   [TransformField("PreviousCreationUtcTime", "File.PreviousCreationDate", UAVersion.UA_VERSION_7_1)]
   [TransformField("TargetObject", "Reg.TargetObject", UAVersion.UA_VERSION_7_2)]
   [TransformField("Details", "Reg.Value.Data", UAVersion.UA_VERSION_7_2)]
   [TransformField("QueryName", "Dns.QueryRequest", UAVersion.UA_VERSION_6_1)]
   [TransformField("QueryResults", "Dns.QueryResponse", UAVersion.UA_VERSION_6_1)]

   [FieldNotSupported("QueryStatus", "uberAgent currently does not support QueryStatus field.")]
   [FieldNotSupported("IntegrityLevel", "uberAgent currently does not support reading the integrity level.")]
   [FieldNotSupported("CurrentDirectory", "uberAgent currently does not support reading the current directory (working directory).")]
   [FieldNotSupported("UtcTime", "uberAgent currently does not export utctime.")]
   [FieldNotSupported("Guid", "uberAgent currently does not export any Guid.")]
   [FieldNotSupported("LogonId", "uberAgent currently does not support reading the logonId.")]
   [FieldNotSupported("Contents", "uberAgent currently does not support Contents field.")]
   [FieldNotSupported("Archived", "uberAgent currently does not support Archived field.")]
   [FieldNotSupported("Product", "uberAgent currently does not support Product field.")]
   [FieldNotSupported("Description", "uberAgent currently does not support Description field.")]
   [FieldNotSupported("LogonGuid", "uberAgent currently does not support LogonGuid field.")]
   [FieldNotSupported("Initiated", "uberAgent currently does not support Initiated field.")]
   [FieldNotSupported("SourceProcessGuid", "uberAgent currently does not support SourceProcessGuid field.")]
   [FieldNotSupported("SourceImage", "uberAgent currently does not support SourceImage field.")]
   [FieldNotSupported("TargetProcessGuid", "uberAgent currently does not support TargetProcessGuid field.")]
   [FieldNotSupported("Device", "uberAgent currently does not support Device field.")]

   private static SysmonConditionBase CreateSysmonBaseCondition(EventType eventType, object item)
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
         return null;
      }

      var itemProperties = item.GetType().GetProperties();
      var itemValue = itemProperties.FirstOrDefault(c => c.Name.Equals("Value"))?.GetValue(item, null)?.ToString();
      var itemCondition = itemProperties.FirstOrDefault(c => c.Name.Equals("condition"))?.GetValue(item, null)?.ToString();

      // EventType is ignored here because we have already read it before.
      if (itemName.EndsWith("EventType"))
         return null;

      if (string.IsNullOrWhiteSpace(itemValue))
      {
         Log.Warning("Ignoring empty Sysmon condition value for {field}.", itemName);
         return null;
      }

      Func<EventType, object, SysmonConditionBase> methodAction = CreateSysmonBaseCondition;
      var methodInfo = methodAction.Method;

      // Check not supported fields first
      var notSupportedAttributes = methodInfo.GetCustomAttributes(typeof(FieldNotSupportedAttribute));
      foreach (var attribute in (IEnumerable<FieldNotSupportedAttribute>)notSupportedAttributes)
      {
         if (itemName.EndsWith(attribute.SourceField))
         {
            Log.Warning(Constants.RuleNotSupportedTemplate, attribute.SourceField, attribute.Reason);
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
               MainField = selectedAttribute.GetTargetFieldByContext(eventType, itemValue),
               Fields = selectedAttribute.GetTargetFields(),
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

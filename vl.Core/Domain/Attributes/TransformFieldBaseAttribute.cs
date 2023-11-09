using System;
using System.Linq;

namespace vl.Core.Domain.Attributes
{
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public abstract class TransformFieldBaseAttribute : Attribute
   {
      private readonly TransformMethod TransformMethod;
      private readonly UAVersion UASupportedVersion = UAVersion.UA_VERSION_CURRENT_RELEASE;

      protected TransformFieldBaseAttribute(string sourceField)
      {
         SourceField = sourceField;
      }

      protected TransformFieldBaseAttribute(string sourceField, TransformMethod transformMethod)
      {
         SourceField = sourceField;
         TransformMethod = transformMethod;
      }

      protected TransformFieldBaseAttribute(string sourceField, UAVersion uASupportedVersion)
      {
         SourceField = sourceField;
         UASupportedVersion = uASupportedVersion;
      }

      protected TransformFieldBaseAttribute(string sourceField, TransformMethod transformMethod, UAVersion uASupportedVersion)
      {
         SourceField = sourceField;
         TransformMethod = transformMethod;
         UASupportedVersion = uASupportedVersion;
      }

      public string SourceField { get; }

      public static string TransformTrailingBackslashes(string itemValue)
      {
         var quotes = itemValue.Count(c => c == '"');

         itemValue = itemValue.Replace(@"\", @"\\");
         if (quotes >= 2)
            itemValue = itemValue.Trim().Replace("\"", "\\\"");

         return itemValue;
      }

      public string TransformValue(string value)
      {
         return TransformMethod switch
         {
            TransformMethod.RemoveTrailingBackslashes => TransformTrailingBackslashes(value),
            _ => value
         };
      }

      public abstract TransformDataType GetDataType();
      public abstract string GetTargetField(string value);
   }
}

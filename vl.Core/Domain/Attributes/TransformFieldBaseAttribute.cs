using System;
using System.Linq;

namespace vl.Core.Domain.Attributes
{
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public abstract class TransformFieldBaseAttribute : Attribute
   {
      private readonly TransformMethod transformMethod;

      protected TransformFieldBaseAttribute(string sourceField)
      {
         SourceField = sourceField;
      }

      protected TransformFieldBaseAttribute(string sourceField, TransformMethod transformMethod)
      {
         SourceField = sourceField;
         this.transformMethod = transformMethod;
      }

      public string SourceField { get; }

      public static string TransformTrailingBackslashes(string itemValue)
      {
         var quotes = itemValue.Count(c => c == '"');
         if (quotes >= 2 || !itemValue.TrimEnd().EndsWith('"'))
            itemValue = itemValue.Trim().Replace("\"", "\\\"");

         return itemValue;
      }

      public string TransformValue(string value)
      {
         return transformMethod switch
         {
            TransformMethod.RemoveTrailingBackslashes => TransformTrailingBackslashes(value),
            _ => value
         };
      }

      public abstract string GetTargetField(string value);
   }
}

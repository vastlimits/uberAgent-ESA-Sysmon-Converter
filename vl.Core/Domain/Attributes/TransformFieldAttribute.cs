using System;
using System.Linq;

namespace vl.Core.Domain.Attributes
{
   public enum TransformMethod
   {
      RemoveTrailingBackslashes
   }

   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public abstract class TransformFieldBaseAttribute : Attribute
   {
      private readonly TransformMethod TransformMethod;

      public string SourceField { get; }

      protected TransformFieldBaseAttribute(string sourceField)
      {
         SourceField = sourceField;
      }

      protected TransformFieldBaseAttribute(string sourceField, TransformMethod transformMethod)
      {
         SourceField = sourceField;
         TransformMethod = transformMethod;
      }

      public static string TransformTrailingBackslashes(string itemValue)
      {
         var quotes = itemValue.Count(c => c == '"');
         if (quotes >= 2 || !itemValue.TrimEnd().EndsWith('"'))
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
      
      public abstract string GetTargetField(string value);
   }

   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public class TransformFieldAttribute : TransformFieldBaseAttribute
   {
      public string TargetField { get; }


      public TransformFieldAttribute(string sourceField, string targetField) : base(sourceField)
      {
         TargetField = targetField;
      }

      public TransformFieldAttribute(string sourceField, string targetField, TransformMethod transformMethod) : base(sourceField, transformMethod)
      {
         TargetField = targetField;
      }


      public override string GetTargetField(string value)
      {
         return TargetField;
      }
   }

   public class TransformFieldPathAttribute : TransformFieldBaseAttribute
   {
      public string TargetField { get; }

      public string TargetFieldPath { get; }


      public TransformFieldPathAttribute(string sourceField, string targetField, string targetFieldPath) : base(sourceField)
      {
         TargetField = targetField;
         TargetFieldPath = targetFieldPath;
      }

      public TransformFieldPathAttribute(string sourceField, string targetField, string targetFieldPath, TransformMethod transformMethod) : base(sourceField, transformMethod)
      {
         TargetField = targetField;
         TargetFieldPath = targetFieldPath;
      }


      public override string GetTargetField(string value)
      {
         return value.IndexOf('\\') > -1 ? TargetFieldPath : TargetField;
      }
   }
}

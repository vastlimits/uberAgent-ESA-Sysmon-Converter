using System;

namespace vl.Core.Domain.Attributes
{
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
}

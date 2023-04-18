using System;

namespace vl.Core.Domain.Attributes
{
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public class TransformFieldAttribute : TransformFieldBaseAttribute
   {
      protected string TargetField { get; }
      protected TransformDataType DataType { get; } = TransformDataType.String;
      
      public TransformFieldAttribute(string sourceField, string targetField) : base(sourceField)
      {
         TargetField = targetField;
      }

      public TransformFieldAttribute(string sourceField, string targetField, TransformDataType transformDataType) : base(sourceField)
      {
         TargetField = targetField;
         DataType = transformDataType;
      }

      public TransformFieldAttribute(string sourceField, string targetField, TransformMethod transformMethod) : base(sourceField, transformMethod)
      {
         TargetField = targetField;
      }

      public override TransformDataType GetDataType() => DataType;

      public override string GetTargetField(string value) => TargetField;
   }
}

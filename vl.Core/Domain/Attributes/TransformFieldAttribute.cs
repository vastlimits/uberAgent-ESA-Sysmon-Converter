using System;
using vl.Core.Domain.Activity;

namespace vl.Core.Domain.Attributes
{
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public class TransformFieldAttribute : TransformFieldBaseAttribute
   {
      protected string TargetField { get; }
      protected TransformDataType DataType { get; } = TransformDataType.String;
      
      public TransformFieldAttribute(string sourceField, string targetField, UAVersion uASupportedVersion) 
         : base(sourceField, uASupportedVersion)
      {
         TargetField = targetField;
      }

      public TransformFieldAttribute(string sourceField, string targetField, TransformDataType transformDataType, UAVersion uASupportedVersion) 
         : base(sourceField, uASupportedVersion)
      {
         TargetField = targetField;
         DataType = transformDataType;
      }

      public TransformFieldAttribute(string sourceField, string targetField, TransformMethod transformMethod, UAVersion uASupportedVersion) 
         : base(sourceField, transformMethod,uASupportedVersion)
      {
         TargetField = targetField;
      }

      public override TransformDataType GetDataType() => DataType;

      public override string GetTargetFieldByContext(EventType eventType, string value) => TargetField;
      public override string[] GetTargetFields() => [TargetField];
   }
}

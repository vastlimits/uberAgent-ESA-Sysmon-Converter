namespace vl.Core.Domain.Attributes
{
   public class TransformFieldPathAttribute : TransformFieldBaseAttribute
   {
      public string TargetField { get; }
      public string TargetFieldPath { get; }

      public TransformFieldPathAttribute(string sourceField, string targetField, string targetFieldPath, UAVersion uASupportedVersion) :
         base(sourceField, uASupportedVersion)
      {
         TargetField = targetField;
         TargetFieldPath = targetFieldPath;
      }

      public TransformFieldPathAttribute(string sourceField, string targetField, string targetFieldPath, TransformMethod transformMethod, UAVersion uASupportedVersion) 
         : base(sourceField, transformMethod, uASupportedVersion)
      {
         TargetField = targetField;
         TargetFieldPath = targetFieldPath;
      }

      public override TransformDataType GetDataType()
      {
         return TransformDataType.String;
      }

      public override string GetTargetField(string value)
      {
         return value.IndexOf('\\') > -1 ? TargetFieldPath : TargetField;
      }

      public override string[] GetTargetFields() => [TargetField, TargetFieldPath];
   }
}

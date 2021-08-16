namespace vl.Core.Domain.Attributes
{
   public class TransformFieldPathAttribute : TransformFieldBaseAttribute
   {
      public TransformFieldPathAttribute(string sourceField, string targetField, string targetFieldPath) :
         base(sourceField)
      {
         TargetField = targetField;
         TargetFieldPath = targetFieldPath;
      }

      public TransformFieldPathAttribute(string sourceField, string targetField, string targetFieldPath,
                                         TransformMethod transformMethod) : base(sourceField, transformMethod)
      {
         TargetField = targetField;
         TargetFieldPath = targetFieldPath;
      }

      public string TargetField { get; }

      public string TargetFieldPath { get; }


      public override string GetTargetField(string value)
      {
         return value.IndexOf('\\') > -1 ? TargetFieldPath : TargetField;
      }
   }
}

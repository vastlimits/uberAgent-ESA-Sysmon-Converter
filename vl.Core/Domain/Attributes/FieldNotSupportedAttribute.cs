using System;

namespace vl.Core.Domain.Attributes
{
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public class FieldNotSupportedAttribute : Attribute
   {
      public string SourceField { get; }
      public string Reason { get; }

      public FieldNotSupportedAttribute(string sourceField, string reason)
      {
         SourceField = sourceField;
         Reason = reason;
      }
   }
}

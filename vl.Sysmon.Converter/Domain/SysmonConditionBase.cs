using System;
using vl.Core.Domain.Attributes;

namespace vl.Sysmon.Converter.Domain;

public class SysmonConditionBase
{
   public string Field { get; set; }
   public string Value { get; set; }
   public string Condition { get; set; }
   public TransformDataType DataType { get; set; }

   public string GetValueFormated()
   {
      switch(DataType)
      {
         case TransformDataType.String:
            return $"\"{Value}\"";
         case TransformDataType.Int:
            return Value;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }
}
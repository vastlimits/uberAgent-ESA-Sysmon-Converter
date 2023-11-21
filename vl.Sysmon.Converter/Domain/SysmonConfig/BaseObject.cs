using System;

namespace vl.Sysmon.Converter.Domain;

public partial class BaseObject<T>
{
   private string conditionField;

   private T valueField;

   private string nameField;


   /// <remarks/>
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string condition
   {
      get { return this.conditionField; }
      set { this.conditionField = value; }
   }

   /// <remarks/>
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string name
   {
      get { return this.nameField; }
      set { this.nameField = value; }
   }

   /// <remarks/>
   [System.Xml.Serialization.XmlTextAttribute()]
   public T Value
   {
      get { return this.valueField; }
      set { this.valueField = value; }
   }
}
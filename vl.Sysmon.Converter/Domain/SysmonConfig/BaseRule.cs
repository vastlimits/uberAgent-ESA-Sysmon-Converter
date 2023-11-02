namespace vl.Sysmon.Converter.Domain;

public partial class BaseRule
{
   private string onmatchField;
   
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string onmatch
   {
      get { return this.onmatchField; }
      set { this.onmatchField = value; }
   }
}
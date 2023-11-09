namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTampering : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupProcessTamperingProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupProcessTamperingProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupProcessTamperingImage))]
[System.Xml.Serialization.XmlElementAttribute("Type",typeof(SysmonEventFilteringRuleGroupProcessTamperingType))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupProcessTamperingUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupProcessTamperingRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupProcessTamperingRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupProcessTamperingRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupProcessTamperingRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("Type",typeof(SysmonEventFilteringRuleGroupProcessTamperingRuleType))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupProcessTamperingRuleUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTampering : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringProcessTamperingProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringProcessTamperingProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringProcessTamperingImage))]
[System.Xml.Serialization.XmlElementAttribute("Type",typeof(SysmonEventFilteringProcessTamperingType))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringProcessTamperingUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringProcessTamperingRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringProcessTamperingRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringProcessTamperingRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringProcessTamperingRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("Type",typeof(SysmonEventFilteringProcessTamperingRuleType))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringProcessTamperingRuleUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingRuleType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessTamperingRuleUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingRuleType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessTamperingRuleUser : BaseObject<string>
{
}

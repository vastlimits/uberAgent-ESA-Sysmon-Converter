namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreate : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileCreateProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileCreateProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileCreateImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileCreateTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringRuleGroupFileCreateCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileCreateUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupFileCreateRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileCreateRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileCreateRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileCreateRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileCreateRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringRuleGroupFileCreateRuleCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileCreateRuleUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }

   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string groupRelation
   {
      get { return this.groupRelationField; }
      set { this.groupRelationField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreate : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileCreateProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileCreateProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileCreateImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileCreateTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringFileCreateCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileCreateUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringFileCreateRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileCreateRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileCreateRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileCreateRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileCreateRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringFileCreateRuleCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileCreateRuleUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }

   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string groupRelation
   {
      get { return this.groupRelationField; }
      set { this.groupRelationField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateRuleCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateRuleUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateRuleCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateRuleUser : BaseObject<string>
{
}

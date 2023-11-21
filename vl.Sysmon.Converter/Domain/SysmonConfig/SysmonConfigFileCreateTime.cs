namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTime : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileCreateTimeProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileCreateTimeProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileCreateTimeImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileCreateTimeTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringRuleGroupFileCreateTimeCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("PreviousCreationUtcTime",typeof(SysmonEventFilteringRuleGroupFileCreateTimePreviousCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileCreateTimeUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRuleCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("PreviousCreationUtcTime",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRulePreviousCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileCreateTimeRuleUser))]
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
public partial class SysmonEventFilteringFileCreateTime : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileCreateTimeProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileCreateTimeProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileCreateTimeImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileCreateTimeTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringFileCreateTimeCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("PreviousCreationUtcTime",typeof(SysmonEventFilteringFileCreateTimePreviousCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileCreateTimeUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringFileCreateTimeRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileCreateTimeRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileCreateTimeRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileCreateTimeRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileCreateTimeRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("CreationUtcTime",typeof(SysmonEventFilteringFileCreateTimeRuleCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("PreviousCreationUtcTime",typeof(SysmonEventFilteringFileCreateTimeRulePreviousCreationUtcTime))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileCreateTimeRuleUser))]
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
public partial class SysmonEventFilteringRuleGroupFileCreateTimeProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimePreviousCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRuleCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRulePreviousCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileCreateTimeRuleUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimePreviousCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRuleCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRulePreviousCreationUtcTime : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileCreateTimeRuleUser : BaseObject<string>
{
}

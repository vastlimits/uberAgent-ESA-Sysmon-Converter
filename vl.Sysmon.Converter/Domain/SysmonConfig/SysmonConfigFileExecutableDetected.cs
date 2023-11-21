namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetected : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedHashes))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupFileExecutableDetectedRuleHashes))]
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
public partial class SysmonEventFilteringFileExecutableDetected : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileExecutableDetectedProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileExecutableDetectedProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileExecutableDetectedUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileExecutableDetectedImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileExecutableDetectedTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringFileExecutableDetectedHashes))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringFileExecutableDetectedRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileExecutableDetectedRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileExecutableDetectedRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileExecutableDetectedRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileExecutableDetectedRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileExecutableDetectedRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringFileExecutableDetectedRuleHashes))]
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
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedHashes : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileExecutableDetectedRuleHashes : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedHashes : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileExecutableDetectedRuleHashes : BaseObject<string>
{
}

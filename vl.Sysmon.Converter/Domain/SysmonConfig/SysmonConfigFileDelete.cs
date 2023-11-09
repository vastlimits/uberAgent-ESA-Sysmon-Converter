namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDelete : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileDeleteProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileDeleteProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileDeleteUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileDeleteImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileDeleteTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupFileDeleteHashes))]
[System.Xml.Serialization.XmlElementAttribute("IsExecutable",typeof(SysmonEventFilteringRuleGroupFileDeleteIsExecutable))]
[System.Xml.Serialization.XmlElementAttribute("Archived",typeof(SysmonEventFilteringRuleGroupFileDeleteArchived))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupFileDeleteRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleHashes))]
[System.Xml.Serialization.XmlElementAttribute("IsExecutable",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleIsExecutable))]
[System.Xml.Serialization.XmlElementAttribute("Archived",typeof(SysmonEventFilteringRuleGroupFileDeleteRuleArchived))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDelete : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileDeleteProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileDeleteProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileDeleteUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileDeleteImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileDeleteTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringFileDeleteHashes))]
[System.Xml.Serialization.XmlElementAttribute("IsExecutable",typeof(SysmonEventFilteringFileDeleteIsExecutable))]
[System.Xml.Serialization.XmlElementAttribute("Archived",typeof(SysmonEventFilteringFileDeleteArchived))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringFileDeleteRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileDeleteRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileDeleteRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileDeleteRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileDeleteRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileDeleteRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringFileDeleteRuleHashes))]
[System.Xml.Serialization.XmlElementAttribute("IsExecutable",typeof(SysmonEventFilteringFileDeleteRuleIsExecutable))]
[System.Xml.Serialization.XmlElementAttribute("Archived",typeof(SysmonEventFilteringFileDeleteRuleArchived))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteIsExecutable : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteArchived : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleIsExecutable : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileDeleteRuleArchived : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteIsExecutable : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteArchived : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleIsExecutable : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileDeleteRuleArchived : BaseObject<string>
{
}

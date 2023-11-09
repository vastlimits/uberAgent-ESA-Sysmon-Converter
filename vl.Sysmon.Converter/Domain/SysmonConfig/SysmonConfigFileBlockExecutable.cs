namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutable : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableHashes))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupFileBlockExecutableRuleHashes))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutable : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileBlockExecutableProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileBlockExecutableProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileBlockExecutableUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileBlockExecutableImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileBlockExecutableTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringFileBlockExecutableHashes))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringFileBlockExecutableRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringFileBlockExecutableRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringFileBlockExecutableRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringFileBlockExecutableRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringFileBlockExecutableRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetFilename",typeof(SysmonEventFilteringFileBlockExecutableRuleTargetFilename))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringFileBlockExecutableRuleHashes))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableHashes : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupFileBlockExecutableRuleHashes : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableHashes : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableRuleTargetFilename : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringFileBlockExecutableRuleHashes : BaseObject<string>
{
}

namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreate : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupProcessCreateProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupProcessCreateProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupProcessCreateImage))]
[System.Xml.Serialization.XmlElementAttribute("FileVersion",typeof(SysmonEventFilteringRuleGroupProcessCreateFileVersion))]
[System.Xml.Serialization.XmlElementAttribute("Description",typeof(SysmonEventFilteringRuleGroupProcessCreateDescription))]
[System.Xml.Serialization.XmlElementAttribute("Product",typeof(SysmonEventFilteringRuleGroupProcessCreateProduct))]
[System.Xml.Serialization.XmlElementAttribute("Company",typeof(SysmonEventFilteringRuleGroupProcessCreateCompany))]
[System.Xml.Serialization.XmlElementAttribute("OriginalFileName",typeof(SysmonEventFilteringRuleGroupProcessCreateOriginalFileName))]
[System.Xml.Serialization.XmlElementAttribute("CommandLine",typeof(SysmonEventFilteringRuleGroupProcessCreateCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("CurrentDirectory",typeof(SysmonEventFilteringRuleGroupProcessCreateCurrentDirectory))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupProcessCreateUser))]
[System.Xml.Serialization.XmlElementAttribute("LogonGuid",typeof(SysmonEventFilteringRuleGroupProcessCreateLogonGuid))]
[System.Xml.Serialization.XmlElementAttribute("LogonId",typeof(SysmonEventFilteringRuleGroupProcessCreateLogonId))]
[System.Xml.Serialization.XmlElementAttribute("TerminalSessionId",typeof(SysmonEventFilteringRuleGroupProcessCreateTerminalSessionId))]
[System.Xml.Serialization.XmlElementAttribute("IntegrityLevel",typeof(SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupProcessCreateHashes))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid",typeof(SysmonEventFilteringRuleGroupProcessCreateParentProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessId",typeof(SysmonEventFilteringRuleGroupProcessCreateParentProcessId))]
[System.Xml.Serialization.XmlElementAttribute("ParentImage",typeof(SysmonEventFilteringRuleGroupProcessCreateParentImage))]
[System.Xml.Serialization.XmlElementAttribute("ParentCommandLine",typeof(SysmonEventFilteringRuleGroupProcessCreateParentCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("ParentUser",typeof(SysmonEventFilteringRuleGroupProcessCreateParentUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupProcessCreateRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("FileVersion",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleFileVersion))]
[System.Xml.Serialization.XmlElementAttribute("Description",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleDescription))]
[System.Xml.Serialization.XmlElementAttribute("Product",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleProduct))]
[System.Xml.Serialization.XmlElementAttribute("Company",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleCompany))]
[System.Xml.Serialization.XmlElementAttribute("OriginalFileName",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleOriginalFileName))]
[System.Xml.Serialization.XmlElementAttribute("CommandLine",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("CurrentDirectory",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleCurrentDirectory))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("LogonGuid",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleLogonGuid))]
[System.Xml.Serialization.XmlElementAttribute("LogonId",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleLogonId))]
[System.Xml.Serialization.XmlElementAttribute("TerminalSessionId",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleTerminalSessionId))]
[System.Xml.Serialization.XmlElementAttribute("IntegrityLevel",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleIntegrityLevel))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleHashes))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleParentProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessId",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleParentProcessId))]
[System.Xml.Serialization.XmlElementAttribute("ParentImage",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleParentImage))]
[System.Xml.Serialization.XmlElementAttribute("ParentCommandLine",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleParentCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("ParentUser",typeof(SysmonEventFilteringRuleGroupProcessCreateRuleParentUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreate : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringProcessCreateProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringProcessCreateProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringProcessCreateImage))]
[System.Xml.Serialization.XmlElementAttribute("FileVersion",typeof(SysmonEventFilteringProcessCreateFileVersion))]
[System.Xml.Serialization.XmlElementAttribute("Description",typeof(SysmonEventFilteringProcessCreateDescription))]
[System.Xml.Serialization.XmlElementAttribute("Product",typeof(SysmonEventFilteringProcessCreateProduct))]
[System.Xml.Serialization.XmlElementAttribute("Company",typeof(SysmonEventFilteringProcessCreateCompany))]
[System.Xml.Serialization.XmlElementAttribute("OriginalFileName",typeof(SysmonEventFilteringProcessCreateOriginalFileName))]
[System.Xml.Serialization.XmlElementAttribute("CommandLine",typeof(SysmonEventFilteringProcessCreateCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("CurrentDirectory",typeof(SysmonEventFilteringProcessCreateCurrentDirectory))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringProcessCreateUser))]
[System.Xml.Serialization.XmlElementAttribute("LogonGuid",typeof(SysmonEventFilteringProcessCreateLogonGuid))]
[System.Xml.Serialization.XmlElementAttribute("LogonId",typeof(SysmonEventFilteringProcessCreateLogonId))]
[System.Xml.Serialization.XmlElementAttribute("TerminalSessionId",typeof(SysmonEventFilteringProcessCreateTerminalSessionId))]
[System.Xml.Serialization.XmlElementAttribute("IntegrityLevel",typeof(SysmonEventFilteringProcessCreateIntegrityLevel))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringProcessCreateHashes))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid",typeof(SysmonEventFilteringProcessCreateParentProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessId",typeof(SysmonEventFilteringProcessCreateParentProcessId))]
[System.Xml.Serialization.XmlElementAttribute("ParentImage",typeof(SysmonEventFilteringProcessCreateParentImage))]
[System.Xml.Serialization.XmlElementAttribute("ParentCommandLine",typeof(SysmonEventFilteringProcessCreateParentCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("ParentUser",typeof(SysmonEventFilteringProcessCreateParentUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringProcessCreateRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringProcessCreateRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringProcessCreateRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringProcessCreateRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("FileVersion",typeof(SysmonEventFilteringProcessCreateRuleFileVersion))]
[System.Xml.Serialization.XmlElementAttribute("Description",typeof(SysmonEventFilteringProcessCreateRuleDescription))]
[System.Xml.Serialization.XmlElementAttribute("Product",typeof(SysmonEventFilteringProcessCreateRuleProduct))]
[System.Xml.Serialization.XmlElementAttribute("Company",typeof(SysmonEventFilteringProcessCreateRuleCompany))]
[System.Xml.Serialization.XmlElementAttribute("OriginalFileName",typeof(SysmonEventFilteringProcessCreateRuleOriginalFileName))]
[System.Xml.Serialization.XmlElementAttribute("CommandLine",typeof(SysmonEventFilteringProcessCreateRuleCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("CurrentDirectory",typeof(SysmonEventFilteringProcessCreateRuleCurrentDirectory))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringProcessCreateRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("LogonGuid",typeof(SysmonEventFilteringProcessCreateRuleLogonGuid))]
[System.Xml.Serialization.XmlElementAttribute("LogonId",typeof(SysmonEventFilteringProcessCreateRuleLogonId))]
[System.Xml.Serialization.XmlElementAttribute("TerminalSessionId",typeof(SysmonEventFilteringProcessCreateRuleTerminalSessionId))]
[System.Xml.Serialization.XmlElementAttribute("IntegrityLevel",typeof(SysmonEventFilteringProcessCreateRuleIntegrityLevel))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringProcessCreateRuleHashes))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid",typeof(SysmonEventFilteringProcessCreateRuleParentProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ParentProcessId",typeof(SysmonEventFilteringProcessCreateRuleParentProcessId))]
[System.Xml.Serialization.XmlElementAttribute("ParentImage",typeof(SysmonEventFilteringProcessCreateRuleParentImage))]
[System.Xml.Serialization.XmlElementAttribute("ParentCommandLine",typeof(SysmonEventFilteringProcessCreateRuleParentCommandLine))]
[System.Xml.Serialization.XmlElementAttribute("ParentUser",typeof(SysmonEventFilteringProcessCreateRuleParentUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateFileVersion : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateDescription : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateProduct : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateCompany : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateOriginalFileName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateCurrentDirectory : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateLogonGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateLogonId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateTerminalSessionId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateParentProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateParentProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateParentImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateParentCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateParentUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleFileVersion : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleDescription : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleProduct : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleCompany : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleOriginalFileName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleCurrentDirectory : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleLogonGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleLogonId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleTerminalSessionId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleIntegrityLevel : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleParentProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleParentProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleParentImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleParentCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRuleParentUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateFileVersion : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateDescription : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateProduct : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateCompany : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateOriginalFileName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateCurrentDirectory : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateLogonGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateLogonId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateTerminalSessionId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateIntegrityLevel : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateParentProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateParentProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateParentImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateParentCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateParentUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleFileVersion : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleDescription : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleProduct : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleCompany : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleOriginalFileName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleCurrentDirectory : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleLogonGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleLogonId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleTerminalSessionId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleIntegrityLevel : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleParentProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleParentProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleParentImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleParentCommandLine : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreateRuleParentUser : BaseObject<string>
{
}

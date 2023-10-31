namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreate
{
   private object[] itemsField;

   private string onmatchField;

   /// <remarks/>
   [System.Xml.Serialization.XmlElementAttribute("CommandLine", typeof(SysmonEventFilteringRuleGroupProcessCreateCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("CurrentDirectory", typeof(SysmonEventFilteringRuleGroupProcessCreateCurrentDirectory))]
   [System.Xml.Serialization.XmlElementAttribute("Hashes", typeof(SysmonEventFilteringRuleGroupProcessCreateHashes))]
   [System.Xml.Serialization.XmlElementAttribute("Image", typeof(SysmonEventFilteringRuleGroupProcessCreateImage))]
   [System.Xml.Serialization.XmlElementAttribute("IntegrityLevel", typeof(SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel))]
   [System.Xml.Serialization.XmlElementAttribute("LogonGuid", typeof(SysmonEventFilteringRuleGroupProcessCreateLogonGuid))]
   [System.Xml.Serialization.XmlElementAttribute("LogonId", typeof(SysmonEventFilteringRuleGroupProcessCreateLogonId))]
   [System.Xml.Serialization.XmlElementAttribute("OriginalFileName", typeof(SysmonEventFilteringRuleGroupProcessCreateOriginalFileName))]
   [System.Xml.Serialization.XmlElementAttribute("ParentCommandLine", typeof(SysmonEventFilteringRuleGroupProcessCreateParentCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("ParentImage", typeof(SysmonEventFilteringRuleGroupProcessCreateParentImage))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid", typeof(SysmonEventFilteringRuleGroupProcessCreateParentProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessId", typeof(SysmonEventFilteringRuleGroupProcessCreateParentProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid", typeof(SysmonEventFilteringRuleGroupProcessCreateProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessId", typeof(SysmonEventFilteringRuleGroupProcessCreateProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("Rule", typeof(SysmonEventFilteringRuleGroupProcessCreateRule))]
   [System.Xml.Serialization.XmlElementAttribute("TerminalSessionId", typeof(SysmonEventFilteringRuleGroupProcessCreateTerminalSessionId))]
   [System.Xml.Serialization.XmlElementAttribute("User", typeof(SysmonEventFilteringRuleGroupProcessCreateUser))]
   [System.Xml.Serialization.XmlElementAttribute("UtcTime", typeof(SysmonEventFilteringRuleGroupProcessCreateUtcTime))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }

   /// <remarks/>
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string onmatch
   {
      get { return this.onmatchField; }
      set { this.onmatchField = value; }
   }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessCreate
{
   private object[] itemsField;

   private string onmatchField;

   /// <remarks/>
   [System.Xml.Serialization.XmlElementAttribute("CommandLine", typeof(SysmonEventFilteringProcessCreateCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("CurrentDirectory", typeof(SysmonEventFilteringProcessCreateCurrentDirectory))]
   [System.Xml.Serialization.XmlElementAttribute("Hashes", typeof(SysmonEventFilteringProcessCreateHashes))]
   [System.Xml.Serialization.XmlElementAttribute("Image", typeof(SysmonEventFilteringProcessCreateImage))]
   [System.Xml.Serialization.XmlElementAttribute("ParentCommandLine", typeof(SysmonEventFilteringProcessCreateParentCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("ParentImage", typeof(SysmonEventFilteringProcessCreateParentImage))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessId", typeof(SysmonEventFilteringProcessCreateParentProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessId", typeof(SysmonEventFilteringProcessCreateProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("TerminalSessionId", typeof(SysmonEventFilteringProcessCreateTerminalSessionId))]
   [System.Xml.Serialization.XmlElementAttribute("IntegrityLevel", typeof(SysmonEventFilteringProcessCreateIntegrityLevel))]
   [System.Xml.Serialization.XmlElementAttribute("LogonGuid", typeof(SysmonEventFilteringProcessCreateLogonGuid))]
   [System.Xml.Serialization.XmlElementAttribute("LogonId", typeof(SysmonEventFilteringProcessCreateLogonId))]
   [System.Xml.Serialization.XmlElementAttribute("OriginalFileName", typeof(SysmonEventFilteringProcessCreateOriginalFileName))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid", typeof(SysmonEventFilteringProcessCreateParentProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid", typeof(SysmonEventFilteringProcessCreateProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("Rule", typeof(SysmonEventFilteringProcessCreateRule))]
   [System.Xml.Serialization.XmlElementAttribute("User", typeof(SysmonEventFilteringProcessCreateUser))]
   [System.Xml.Serialization.XmlElementAttribute("UtcTime", typeof(SysmonEventFilteringProcessCreateUtcTime))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }

   /// <remarks/>
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string onmatch
   {
      get { return this.onmatchField; }
      set { this.onmatchField = value; }
   }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessCreateRule
{

   private object[] itemsField;

   private string nameField;

   private string groupRelationField;

   /// <remarks/>
   [System.Xml.Serialization.XmlElementAttribute("CommandLine", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("CurrentDirectory", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateCurrentDirectory))]
   [System.Xml.Serialization.XmlElementAttribute("Hashes", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateHashes))]
   [System.Xml.Serialization.XmlElementAttribute("Image", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateImage))]
   [System.Xml.Serialization.XmlElementAttribute("IntegrityLevel", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateIntegrityLevel))]
   [System.Xml.Serialization.XmlElementAttribute("LogonGuid", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateLogonGuid))]
   [System.Xml.Serialization.XmlElementAttribute("LogonId", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateLogonId))]
   [System.Xml.Serialization.XmlElementAttribute("OriginalFileName", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateOriginalFileName))]
   [System.Xml.Serialization.XmlElementAttribute("ParentCommandLine", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateParentCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("ParentImage", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateParentImage))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateParentProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessId", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateParentProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessId", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("TerminalSessionId", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateTerminalSessionId))]
   [System.Xml.Serialization.XmlElementAttribute("User", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateUser))]
   [System.Xml.Serialization.XmlElementAttribute("UtcTime", typeof(SysmonEventFilteringRuleGroupProcessRuleCreateUtcTime))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }

   /// <remarks/>
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string name
   {
      get { return this.nameField; }
      set { this.nameField = value; }
   }

   /// <remarks/>
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
public partial class SysmonEventFilteringProcessCreateRule
{

   private object[] itemsField;

   private string nameField;

   private string groupRelationField;

   /// <remarks/>
   [System.Xml.Serialization.XmlElementAttribute("CommandLine", typeof(SysmonEventFilteringProcessRuleCreateCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("CurrentDirectory", typeof(SysmonEventFilteringProcessRuleCreateCurrentDirectory))]
   [System.Xml.Serialization.XmlElementAttribute("Hashes", typeof(SysmonEventFilteringProcessRuleCreateHashes))]
   [System.Xml.Serialization.XmlElementAttribute("Image", typeof(SysmonEventFilteringProcessRuleCreateImage))]
   [System.Xml.Serialization.XmlElementAttribute("IntegrityLevel", typeof(SysmonEventFilteringProcessRuleCreateIntegrityLevel))]
   [System.Xml.Serialization.XmlElementAttribute("LogonGuid", typeof(SysmonEventFilteringProcessRuleCreateLogonGuid))]
   [System.Xml.Serialization.XmlElementAttribute("LogonId", typeof(SysmonEventFilteringProcessRuleCreateLogonId))]
   [System.Xml.Serialization.XmlElementAttribute("OriginalFileName", typeof(SysmonEventFilteringProcessRuleCreateOriginalFileName))]
   [System.Xml.Serialization.XmlElementAttribute("ParentCommandLine", typeof(SysmonEventFilteringProcessRuleCreateParentCommandLine))]
   [System.Xml.Serialization.XmlElementAttribute("ParentImage", typeof(SysmonEventFilteringProcessRuleCreateParentImage))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessGuid", typeof(SysmonEventFilteringProcessRuleCreateParentProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("ParentProcessId", typeof(SysmonEventFilteringProcessRuleCreateParentProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid", typeof(SysmonEventFilteringProcessRuleCreateProcessGuid))]
   [System.Xml.Serialization.XmlElementAttribute("ProcessId", typeof(SysmonEventFilteringProcessRuleCreateProcessId))]
   [System.Xml.Serialization.XmlElementAttribute("TerminalSessionId", typeof(SysmonEventFilteringProcessRuleCreateTerminalSessionId))]
   [System.Xml.Serialization.XmlElementAttribute("User", typeof(SysmonEventFilteringProcessRuleCreateUser))]
   [System.Xml.Serialization.XmlElementAttribute("UtcTime", typeof(SysmonEventFilteringProcessRuleCreateUtcTime))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }

   /// <remarks/>
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string name
   {
      get { return this.nameField; }
      set { this.nameField = value; }
   }

   /// <remarks/>
   [System.Xml.Serialization.XmlAttributeAttribute()]
   public string groupRelation
   {
      get { return this.groupRelationField; }
      set { this.groupRelationField = value; }
   }
}


#region RuleGroup

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateCurrentDirectory
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateHashes
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateIntegrityLevel
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateLogonGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateLogonId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateOriginalFileName
   {

      private string nameField;

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string name
      {
         get { return this.nameField; }
         set { this.nameField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateParentCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateParentImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateParentProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateParentProcessId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateProcessId
   {

      private string conditionField;

      private ushort valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public ushort Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateTerminalSessionId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateUser
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessCreateUtcTime
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

#endregion

#region RuleGroupRule

   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateCurrentDirectory
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateHashes
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateIntegrityLevel
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateLogonGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateLogonId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateOriginalFileName
   {

      private string nameField;

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string name
      {
         get { return this.nameField; }
         set { this.nameField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateParentCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateParentImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateParentProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateParentProcessId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateProcessId
   {

      private string conditionField;

      private ushort valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public ushort Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateTerminalSessionId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateUser
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringRuleGroupProcessRuleCreateUtcTime
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }


#endregion

#region PlainRule
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateCurrentDirectory
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateHashes
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateIntegrityLevel
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateLogonGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateLogonId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateOriginalFileName
   {

      private string nameField;

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string name
      {
         get { return this.nameField; }
         set { this.nameField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateParentCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateParentImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateParentProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateParentProcessId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateProcessId
   {

      private string conditionField;

      private ushort valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public ushort Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateTerminalSessionId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateUser
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessCreateUtcTime
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }
#endregion

#region PlainRuleRule

   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateCurrentDirectory
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateHashes
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateIntegrityLevel
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateLogonGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateLogonId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateOriginalFileName
   {

      private string nameField;

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string name
      {
         get { return this.nameField; }
         set { this.nameField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateParentCommandLine
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateParentImage
   {

      private string conditionField;

      private string nameField;

      private string valueField;

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
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateParentProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateParentProcessId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateProcessGuid
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateProcessId
   {

      private string conditionField;

      private ushort valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public ushort Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateTerminalSessionId
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateUser
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }

   /// <remarks/>
   [System.SerializableAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
   public partial class SysmonEventFilteringProcessRuleCreateUtcTime
   {

      private string conditionField;

      private string valueField;

      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string condition
      {
         get { return this.conditionField; }
         set { this.conditionField = value; }
      }

      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value
      {
         get { return this.valueField; }
         set { this.valueField = value; }
      }
   }


#endregion

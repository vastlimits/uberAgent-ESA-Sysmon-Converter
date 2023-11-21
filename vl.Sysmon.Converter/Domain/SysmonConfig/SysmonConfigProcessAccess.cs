namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccess : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("SourceProcessGUID",typeof(SysmonEventFilteringRuleGroupProcessAccessSourceProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("SourceProcessId",typeof(SysmonEventFilteringRuleGroupProcessAccessSourceProcessId))]
[System.Xml.Serialization.XmlElementAttribute("SourceThreadId",typeof(SysmonEventFilteringRuleGroupProcessAccessSourceThreadId))]
[System.Xml.Serialization.XmlElementAttribute("SourceImage",typeof(SysmonEventFilteringRuleGroupProcessAccessSourceImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessGUID",typeof(SysmonEventFilteringRuleGroupProcessAccessTargetProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessId",typeof(SysmonEventFilteringRuleGroupProcessAccessTargetProcessId))]
[System.Xml.Serialization.XmlElementAttribute("TargetImage",typeof(SysmonEventFilteringRuleGroupProcessAccessTargetImage))]
[System.Xml.Serialization.XmlElementAttribute("GrantedAccess",typeof(SysmonEventFilteringRuleGroupProcessAccessGrantedAccess))]
[System.Xml.Serialization.XmlElementAttribute("CallTrace",typeof(SysmonEventFilteringRuleGroupProcessAccessCallTrace))]
[System.Xml.Serialization.XmlElementAttribute("SourceUser",typeof(SysmonEventFilteringRuleGroupProcessAccessSourceUser))]
[System.Xml.Serialization.XmlElementAttribute("TargetUser",typeof(SysmonEventFilteringRuleGroupProcessAccessTargetUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupProcessAccessRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("SourceProcessGUID",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleSourceProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("SourceProcessId",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleSourceProcessId))]
[System.Xml.Serialization.XmlElementAttribute("SourceThreadId",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleSourceThreadId))]
[System.Xml.Serialization.XmlElementAttribute("SourceImage",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleSourceImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessGUID",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleTargetProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessId",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleTargetProcessId))]
[System.Xml.Serialization.XmlElementAttribute("TargetImage",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleTargetImage))]
[System.Xml.Serialization.XmlElementAttribute("GrantedAccess",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleGrantedAccess))]
[System.Xml.Serialization.XmlElementAttribute("CallTrace",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleCallTrace))]
[System.Xml.Serialization.XmlElementAttribute("SourceUser",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleSourceUser))]
[System.Xml.Serialization.XmlElementAttribute("TargetUser",typeof(SysmonEventFilteringRuleGroupProcessAccessRuleTargetUser))]
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
public partial class SysmonEventFilteringProcessAccess : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("SourceProcessGUID",typeof(SysmonEventFilteringProcessAccessSourceProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("SourceProcessId",typeof(SysmonEventFilteringProcessAccessSourceProcessId))]
[System.Xml.Serialization.XmlElementAttribute("SourceThreadId",typeof(SysmonEventFilteringProcessAccessSourceThreadId))]
[System.Xml.Serialization.XmlElementAttribute("SourceImage",typeof(SysmonEventFilteringProcessAccessSourceImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessGUID",typeof(SysmonEventFilteringProcessAccessTargetProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessId",typeof(SysmonEventFilteringProcessAccessTargetProcessId))]
[System.Xml.Serialization.XmlElementAttribute("TargetImage",typeof(SysmonEventFilteringProcessAccessTargetImage))]
[System.Xml.Serialization.XmlElementAttribute("GrantedAccess",typeof(SysmonEventFilteringProcessAccessGrantedAccess))]
[System.Xml.Serialization.XmlElementAttribute("CallTrace",typeof(SysmonEventFilteringProcessAccessCallTrace))]
[System.Xml.Serialization.XmlElementAttribute("SourceUser",typeof(SysmonEventFilteringProcessAccessSourceUser))]
[System.Xml.Serialization.XmlElementAttribute("TargetUser",typeof(SysmonEventFilteringProcessAccessTargetUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringProcessAccessRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRule : BaseRule
{
   private object[] itemsField;
   private string groupRelationField;
   
   [System.Xml.Serialization.XmlElementAttribute("SourceProcessGUID",typeof(SysmonEventFilteringProcessAccessRuleSourceProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("SourceProcessId",typeof(SysmonEventFilteringProcessAccessRuleSourceProcessId))]
[System.Xml.Serialization.XmlElementAttribute("SourceThreadId",typeof(SysmonEventFilteringProcessAccessRuleSourceThreadId))]
[System.Xml.Serialization.XmlElementAttribute("SourceImage",typeof(SysmonEventFilteringProcessAccessRuleSourceImage))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessGUID",typeof(SysmonEventFilteringProcessAccessRuleTargetProcessGUID))]
[System.Xml.Serialization.XmlElementAttribute("TargetProcessId",typeof(SysmonEventFilteringProcessAccessRuleTargetProcessId))]
[System.Xml.Serialization.XmlElementAttribute("TargetImage",typeof(SysmonEventFilteringProcessAccessRuleTargetImage))]
[System.Xml.Serialization.XmlElementAttribute("GrantedAccess",typeof(SysmonEventFilteringProcessAccessRuleGrantedAccess))]
[System.Xml.Serialization.XmlElementAttribute("CallTrace",typeof(SysmonEventFilteringProcessAccessRuleCallTrace))]
[System.Xml.Serialization.XmlElementAttribute("SourceUser",typeof(SysmonEventFilteringProcessAccessRuleSourceUser))]
[System.Xml.Serialization.XmlElementAttribute("TargetUser",typeof(SysmonEventFilteringProcessAccessRuleTargetUser))]
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
public partial class SysmonEventFilteringRuleGroupProcessAccessSourceProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessSourceProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessSourceThreadId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessSourceImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessTargetProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessTargetProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessTargetImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessGrantedAccess : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessCallTrace : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessSourceUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessTargetUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleSourceProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleSourceProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleSourceThreadId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleSourceImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleTargetProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleTargetProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleTargetImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleGrantedAccess : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleCallTrace : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleSourceUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupProcessAccessRuleTargetUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessSourceProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessSourceProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessSourceThreadId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessSourceImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessTargetProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessTargetProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessTargetImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessGrantedAccess : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessCallTrace : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessSourceUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessTargetUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleSourceProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleSourceProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleSourceThreadId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleSourceImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleTargetProcessGUID : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleTargetProcessId : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleTargetImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleGrantedAccess : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleCallTrace : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleSourceUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringProcessAccessRuleTargetUser : BaseObject<string>
{
}

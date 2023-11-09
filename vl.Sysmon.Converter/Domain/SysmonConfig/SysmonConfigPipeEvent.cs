namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEvent : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("EventType",typeof(SysmonEventFilteringRuleGroupPipeEventEventType))]
[System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupPipeEventProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupPipeEventProcessId))]
[System.Xml.Serialization.XmlElementAttribute("PipeName",typeof(SysmonEventFilteringRuleGroupPipeEventPipeName))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupPipeEventImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupPipeEventUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupPipeEventRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("EventType",typeof(SysmonEventFilteringRuleGroupPipeEventRuleEventType))]
[System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupPipeEventRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupPipeEventRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("PipeName",typeof(SysmonEventFilteringRuleGroupPipeEventRulePipeName))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupPipeEventRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupPipeEventRuleUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEvent : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("EventType",typeof(SysmonEventFilteringPipeEventEventType))]
[System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringPipeEventProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringPipeEventProcessId))]
[System.Xml.Serialization.XmlElementAttribute("PipeName",typeof(SysmonEventFilteringPipeEventPipeName))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringPipeEventImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringPipeEventUser))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringPipeEventRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("EventType",typeof(SysmonEventFilteringPipeEventRuleEventType))]
[System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringPipeEventRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringPipeEventRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("PipeName",typeof(SysmonEventFilteringPipeEventRulePipeName))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringPipeEventRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringPipeEventRuleUser))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventEventType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventPipeName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventRuleEventType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventRulePipeName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupPipeEventRuleUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventEventType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventPipeName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventUser : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventRuleEventType : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventRulePipeName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringPipeEventRuleUser : BaseObject<string>
{
}

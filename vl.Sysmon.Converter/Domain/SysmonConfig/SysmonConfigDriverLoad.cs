namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoad : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ImageLoaded",typeof(SysmonEventFilteringRuleGroupDriverLoadImageLoaded))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupDriverLoadHashes))]
[System.Xml.Serialization.XmlElementAttribute("Signed",typeof(SysmonEventFilteringRuleGroupDriverLoadSigned))]
[System.Xml.Serialization.XmlElementAttribute("Signature",typeof(SysmonEventFilteringRuleGroupDriverLoadSignature))]
[System.Xml.Serialization.XmlElementAttribute("SignatureStatus",typeof(SysmonEventFilteringRuleGroupDriverLoadSignatureStatus))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringRuleGroupDriverLoadRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ImageLoaded",typeof(SysmonEventFilteringRuleGroupDriverLoadRuleImageLoaded))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringRuleGroupDriverLoadRuleHashes))]
[System.Xml.Serialization.XmlElementAttribute("Signed",typeof(SysmonEventFilteringRuleGroupDriverLoadRuleSigned))]
[System.Xml.Serialization.XmlElementAttribute("Signature",typeof(SysmonEventFilteringRuleGroupDriverLoadRuleSignature))]
[System.Xml.Serialization.XmlElementAttribute("SignatureStatus",typeof(SysmonEventFilteringRuleGroupDriverLoadRuleSignatureStatus))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoad : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ImageLoaded",typeof(SysmonEventFilteringDriverLoadImageLoaded))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringDriverLoadHashes))]
[System.Xml.Serialization.XmlElementAttribute("Signed",typeof(SysmonEventFilteringDriverLoadSigned))]
[System.Xml.Serialization.XmlElementAttribute("Signature",typeof(SysmonEventFilteringDriverLoadSignature))]
[System.Xml.Serialization.XmlElementAttribute("SignatureStatus",typeof(SysmonEventFilteringDriverLoadSignatureStatus))]
[System.Xml.Serialization.XmlElementAttribute("Rule",typeof(SysmonEventFilteringDriverLoadRule))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ImageLoaded",typeof(SysmonEventFilteringDriverLoadRuleImageLoaded))]
[System.Xml.Serialization.XmlElementAttribute("Hashes",typeof(SysmonEventFilteringDriverLoadRuleHashes))]
[System.Xml.Serialization.XmlElementAttribute("Signed",typeof(SysmonEventFilteringDriverLoadRuleSigned))]
[System.Xml.Serialization.XmlElementAttribute("Signature",typeof(SysmonEventFilteringDriverLoadRuleSignature))]
[System.Xml.Serialization.XmlElementAttribute("SignatureStatus",typeof(SysmonEventFilteringDriverLoadRuleSignatureStatus))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadImageLoaded : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadSigned : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadSignature : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadSignatureStatus : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadRuleImageLoaded : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadRuleHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadRuleSigned : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadRuleSignature : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupDriverLoadRuleSignatureStatus : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadImageLoaded : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadSigned : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadSignature : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadSignatureStatus : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadRuleImageLoaded : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadRuleHashes : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadRuleSigned : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadRuleSignature : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringDriverLoadRuleSignatureStatus : BaseObject<string>
{
}

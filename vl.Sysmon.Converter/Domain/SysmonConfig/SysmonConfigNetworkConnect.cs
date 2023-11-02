namespace vl.Sysmon.Converter.Domain;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnect : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupNetworkConnectProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupNetworkConnectProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupNetworkConnectImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupNetworkConnectUser))]
[System.Xml.Serialization.XmlElementAttribute("Protocol",typeof(SysmonEventFilteringRuleGroupNetworkConnectProtocol))]
[System.Xml.Serialization.XmlElementAttribute("Initiated",typeof(SysmonEventFilteringRuleGroupNetworkConnectInitiated))]
[System.Xml.Serialization.XmlElementAttribute("SourceIsIpv6",typeof(SysmonEventFilteringRuleGroupNetworkConnectSourceIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("SourceIp",typeof(SysmonEventFilteringRuleGroupNetworkConnectSourceIp))]
[System.Xml.Serialization.XmlElementAttribute("SourceHostname",typeof(SysmonEventFilteringRuleGroupNetworkConnectSourceHostname))]
[System.Xml.Serialization.XmlElementAttribute("SourcePort",typeof(SysmonEventFilteringRuleGroupNetworkConnectSourcePort))]
[System.Xml.Serialization.XmlElementAttribute("SourcePortName",typeof(SysmonEventFilteringRuleGroupNetworkConnectSourcePortName))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIsIpv6",typeof(SysmonEventFilteringRuleGroupNetworkConnectDestinationIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIp",typeof(SysmonEventFilteringRuleGroupNetworkConnectDestinationIp))]
[System.Xml.Serialization.XmlElementAttribute("DestinationHostname",typeof(SysmonEventFilteringRuleGroupNetworkConnectDestinationHostname))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPort",typeof(SysmonEventFilteringRuleGroupNetworkConnectDestinationPort))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPortName",typeof(SysmonEventFilteringRuleGroupNetworkConnectDestinationPortName))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Protocol",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleProtocol))]
[System.Xml.Serialization.XmlElementAttribute("Initiated",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleInitiated))]
[System.Xml.Serialization.XmlElementAttribute("SourceIsIpv6",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleSourceIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("SourceIp",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleSourceIp))]
[System.Xml.Serialization.XmlElementAttribute("SourceHostname",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleSourceHostname))]
[System.Xml.Serialization.XmlElementAttribute("SourcePort",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleSourcePort))]
[System.Xml.Serialization.XmlElementAttribute("SourcePortName",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleSourcePortName))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIsIpv6",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIp",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationIp))]
[System.Xml.Serialization.XmlElementAttribute("DestinationHostname",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationHostname))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPort",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationPort))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPortName",typeof(SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationPortName))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnect : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringNetworkConnectProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringNetworkConnectProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringNetworkConnectImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringNetworkConnectUser))]
[System.Xml.Serialization.XmlElementAttribute("Protocol",typeof(SysmonEventFilteringNetworkConnectProtocol))]
[System.Xml.Serialization.XmlElementAttribute("Initiated",typeof(SysmonEventFilteringNetworkConnectInitiated))]
[System.Xml.Serialization.XmlElementAttribute("SourceIsIpv6",typeof(SysmonEventFilteringNetworkConnectSourceIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("SourceIp",typeof(SysmonEventFilteringNetworkConnectSourceIp))]
[System.Xml.Serialization.XmlElementAttribute("SourceHostname",typeof(SysmonEventFilteringNetworkConnectSourceHostname))]
[System.Xml.Serialization.XmlElementAttribute("SourcePort",typeof(SysmonEventFilteringNetworkConnectSourcePort))]
[System.Xml.Serialization.XmlElementAttribute("SourcePortName",typeof(SysmonEventFilteringNetworkConnectSourcePortName))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIsIpv6",typeof(SysmonEventFilteringNetworkConnectDestinationIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIp",typeof(SysmonEventFilteringNetworkConnectDestinationIp))]
[System.Xml.Serialization.XmlElementAttribute("DestinationHostname",typeof(SysmonEventFilteringNetworkConnectDestinationHostname))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPort",typeof(SysmonEventFilteringNetworkConnectDestinationPort))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPortName",typeof(SysmonEventFilteringNetworkConnectDestinationPortName))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRule : BaseRule
{
   private object[] itemsField;
   
   [System.Xml.Serialization.XmlElementAttribute("ProcessGuid",typeof(SysmonEventFilteringNetworkConnectRuleProcessGuid))]
[System.Xml.Serialization.XmlElementAttribute("ProcessId",typeof(SysmonEventFilteringNetworkConnectRuleProcessId))]
[System.Xml.Serialization.XmlElementAttribute("Image",typeof(SysmonEventFilteringNetworkConnectRuleImage))]
[System.Xml.Serialization.XmlElementAttribute("User",typeof(SysmonEventFilteringNetworkConnectRuleUser))]
[System.Xml.Serialization.XmlElementAttribute("Protocol",typeof(SysmonEventFilteringNetworkConnectRuleProtocol))]
[System.Xml.Serialization.XmlElementAttribute("Initiated",typeof(SysmonEventFilteringNetworkConnectRuleInitiated))]
[System.Xml.Serialization.XmlElementAttribute("SourceIsIpv6",typeof(SysmonEventFilteringNetworkConnectRuleSourceIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("SourceIp",typeof(SysmonEventFilteringNetworkConnectRuleSourceIp))]
[System.Xml.Serialization.XmlElementAttribute("SourceHostname",typeof(SysmonEventFilteringNetworkConnectRuleSourceHostname))]
[System.Xml.Serialization.XmlElementAttribute("SourcePort",typeof(SysmonEventFilteringNetworkConnectRuleSourcePort))]
[System.Xml.Serialization.XmlElementAttribute("SourcePortName",typeof(SysmonEventFilteringNetworkConnectRuleSourcePortName))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIsIpv6",typeof(SysmonEventFilteringNetworkConnectRuleDestinationIsIpv6))]
[System.Xml.Serialization.XmlElementAttribute("DestinationIp",typeof(SysmonEventFilteringNetworkConnectRuleDestinationIp))]
[System.Xml.Serialization.XmlElementAttribute("DestinationHostname",typeof(SysmonEventFilteringNetworkConnectRuleDestinationHostname))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPort",typeof(SysmonEventFilteringNetworkConnectRuleDestinationPort))]
[System.Xml.Serialization.XmlElementAttribute("DestinationPortName",typeof(SysmonEventFilteringNetworkConnectRuleDestinationPortName))]
   public object[] Items
   {
      get { return this.itemsField; }
      set { this.itemsField = value; }
   }
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectProtocol : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectInitiated : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectSourceIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectSourceIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectSourceHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectSourcePort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectSourcePortName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectDestinationIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectDestinationIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectDestinationHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectDestinationPort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectDestinationPortName : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleProtocol : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleInitiated : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleSourceIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleSourceIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleSourceHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleSourcePort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleSourcePortName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationPort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringRuleGroupNetworkConnectRuleDestinationPortName : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectProtocol : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectInitiated : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectSourceIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectSourceIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectSourceHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectSourcePort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectSourcePortName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectDestinationIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectDestinationIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectDestinationHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectDestinationPort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectDestinationPortName : BaseObject<string>
{
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleProcessGuid : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleProcessId : BaseObject<uint>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleImage : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleUser : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleProtocol : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleInitiated : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleSourceIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleSourceIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleSourceHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleSourcePort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleSourcePortName : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleDestinationIsIpv6 : BaseObject<bool>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleDestinationIp : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleDestinationHostname : BaseObject<string>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleDestinationPort : BaseObject<ushort>
{
}


[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SysmonEventFilteringNetworkConnectRuleDestinationPortName : BaseObject<string>
{
}

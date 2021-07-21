namespace vl.Sysmon.Convert.Domain
{
   public partial class SysmonEventFilteringRuleGroupDnsQuery
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupWmiEvent
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupPipeEvent
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringFileCreateStreamHash
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupRegistryEvent
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupFileCreate
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupProcessAccess
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupRawAccessRead
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupCreateRemoteThread
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupImageLoad
   {
      public object[] Items { get; set; }
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupDriverLoad
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupProcessTerminate
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupNetworkConnect
   {
      public object[] Items { get; set; }
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupFileCreateTime
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }

   public partial class SysmonEventFilteringRuleGroupProcessCreate
   {
      public string name { get; set; }
      public string groupRelation { get; set; }
   }
}

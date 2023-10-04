// Do not change the namespace
namespace vl.Sysmon.Converter.Domain
{
   public partial class SysmonEventFilteringRuleGroupDnsQuery
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupDnsQuery(SysmonEventFilteringDnsQuery pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupWmiEvent
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      /*public static implicit operator SysmonEventFilteringRuleGroupWmiEvent(SysmonEventFilteringWmiEvent pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };*/
   }

   public partial class SysmonEventFilteringRuleGroupPipeEvent
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupPipeEvent(SysmonEventFilteringPipeEvent pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileCreateStreamHash
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileCreateStreamHash(SysmonEventFilteringFileCreateStreamHash pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupRegistryEvent
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupRegistryEvent(SysmonEventFilteringRegistryEvent pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileCreate
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileCreate(SysmonEventFilteringFileCreate pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessAccess
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessAccess(SysmonEventFilteringProcessAccess pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupRawAccessRead
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupRawAccessRead(SysmonEventFilteringRawAccessRead pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupCreateRemoteThread
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupCreateRemoteThread(SysmonEventFilteringCreateRemoteThread pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupImageLoad
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupImageLoad(SysmonEventFilteringImageLoad pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupDriverLoad
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupDriverLoad(SysmonEventFilteringDriverLoad pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessTerminate
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessTerminate(SysmonEventFilteringProcessTerminate pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupNetworkConnect
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupNetworkConnect(SysmonEventFilteringNetworkConnect pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileCreateTime
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileCreateTime(SysmonEventFilteringFileCreateTime pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessCreate
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessCreate(SysmonEventFilteringProcessCreate pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessTampering
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessTampering(SysmonEventFilteringProcessTampering pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileDelete
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileDelete(SysmonEventFilteringFileDelete pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "or",
         Items = pc.Items,
      };
   }
}

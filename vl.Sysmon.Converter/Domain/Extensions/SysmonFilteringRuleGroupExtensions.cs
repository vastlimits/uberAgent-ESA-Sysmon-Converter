// Do not change the namespace

using vl.Sysmon.Converter.Domain.Activity;

namespace vl.Sysmon.Converter.Domain
{
   public partial class SysmonEventFilteringRuleGroupDnsQuery : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupDnsQuery(SysmonEventFilteringDnsQuery pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
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

   public partial class SysmonEventFilteringRuleGroupPipeEvent : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupPipeEvent(SysmonEventFilteringPipeEvent pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileCreateStreamHash : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileCreateStreamHash(SysmonEventFilteringFileCreateStreamHash pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupRegistryEvent : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupRegistryEvent(SysmonEventFilteringRegistryEvent pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileCreate : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileCreate(SysmonEventFilteringFileCreate pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessAccess : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessAccess(SysmonEventFilteringProcessAccess pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupRawAccessRead : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupRawAccessRead(SysmonEventFilteringRawAccessRead pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupCreateRemoteThread : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupCreateRemoteThread(SysmonEventFilteringCreateRemoteThread pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupImageLoad : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupImageLoad(SysmonEventFilteringImageLoad pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupDriverLoad : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupDriverLoad(SysmonEventFilteringDriverLoad pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessTerminate : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessTerminate(SysmonEventFilteringProcessTerminate pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupNetworkConnect : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupNetworkConnect(SysmonEventFilteringNetworkConnect pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileCreateTime : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileCreateTime(SysmonEventFilteringFileCreateTime pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessCreate : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessCreate(SysmonEventFilteringProcessCreate pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupProcessTampering : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupProcessTampering(SysmonEventFilteringProcessTampering pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }

   public partial class SysmonEventFilteringRuleGroupFileDelete : ISysmonEventFilteringRuleGroup
   {
      public string name { get; set; }
      public string groupRelation { get; set; }

      public static implicit operator SysmonEventFilteringRuleGroupFileDelete(SysmonEventFilteringFileDelete pc) => new()
      {
         onmatch = pc.onmatch,
         groupRelation = "and",
         Items = pc.Items,
      };
   }
}

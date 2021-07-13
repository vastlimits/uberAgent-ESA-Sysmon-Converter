using System.Collections.Generic;

namespace vl.Sysmon.Convert.Domain.Helpers
{
   public class SysmonEventFilteringRuleListed
   {
      public List<SysmonEventFilteringRuleGroupDnsQuery> DnsQuery { get; set; } =
         new List<SysmonEventFilteringRuleGroupDnsQuery>();

      public List<SysmonEventFilteringRuleGroupWmiEvent> WmiEvent { get; set; } =
         new List<SysmonEventFilteringRuleGroupWmiEvent>();

      public List<SysmonEventFilteringRuleGroupPipeEvent> PipeEvent { get; set; } =
         new List<SysmonEventFilteringRuleGroupPipeEvent>();

      public List<SysmonEventFilteringRuleGroupFileCreateStreamHash> FileCreateStreamHash { get; set; } =
         new List<SysmonEventFilteringRuleGroupFileCreateStreamHash>();

      public List<SysmonEventFilteringRuleGroupRegistryEvent> RegistryEvent { get; set; } =
         new List<SysmonEventFilteringRuleGroupRegistryEvent>();

      public List<SysmonEventFilteringRuleGroupFileCreate> FileCreate { get; set; } =
         new List<SysmonEventFilteringRuleGroupFileCreate>();

      public List<SysmonEventFilteringRuleGroupProcessAccess> ProcessAccess { get; set; } =
         new List<SysmonEventFilteringRuleGroupProcessAccess>();

      public List<SysmonEventFilteringRuleGroupRawAccessRead> RawAccessRead { get; set; } =
         new List<SysmonEventFilteringRuleGroupRawAccessRead>();

      public List<SysmonEventFilteringRuleGroupCreateRemoteThread> CreateRemoteThread { get; set; } =
         new List<SysmonEventFilteringRuleGroupCreateRemoteThread>();

      public List<SysmonEventFilteringRuleGroupImageLoad> ImageLoad { get; set; } =
         new List<SysmonEventFilteringRuleGroupImageLoad>();

      public List<SysmonEventFilteringRuleGroupDriverLoad> DriverLoad { get; set; } =
         new List<SysmonEventFilteringRuleGroupDriverLoad>();

      public List<SysmonEventFilteringRuleGroupProcessTerminate> ProcessTerminate { get; set; } =
         new List<SysmonEventFilteringRuleGroupProcessTerminate>();

      public List<SysmonEventFilteringRuleGroupNetworkConnect> NetworkConnect { get; set; } =
         new List<SysmonEventFilteringRuleGroupNetworkConnect>();

      public List<SysmonEventFilteringRuleGroupFileCreateTime> FileCreateTime { get; set; } =
         new List<SysmonEventFilteringRuleGroupFileCreateTime>();

      public List<SysmonEventFilteringRuleGroupProcessCreate> ProcessCreate { get; set; } =
         new List<SysmonEventFilteringRuleGroupProcessCreate>();
   }
}

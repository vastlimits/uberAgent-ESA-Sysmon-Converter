using System.Collections.Generic;

namespace vl.Sysmon.Converter.Domain
{
   public class SysmonEventFilteringRuleListed
   {
      public List<SysmonEventFilteringRuleGroupDnsQuery> DnsQuery { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupWmiEvent> WmiEvent { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupPipeEvent> PipeEvent { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupFileCreateStreamHash> FileCreateStreamHash { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupRegistryEvent> RegistryEvent { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupFileCreate> FileCreate { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupProcessAccess> ProcessAccess { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupRawAccessRead> RawAccessRead { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupCreateRemoteThread> CreateRemoteThread { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupImageLoad> ImageLoad { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupDriverLoad> DriverLoad { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupProcessTerminate> ProcessTerminate { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupNetworkConnect> NetworkConnect { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupFileCreateTime> FileCreateTime { get; set; } = new();

      public List<SysmonEventFilteringRuleGroupProcessCreate> ProcessCreate { get; set; } = new();
   }
}

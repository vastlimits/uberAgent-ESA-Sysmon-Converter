using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain.Activity
{
   public class SysmonActivityMonitoringRule : ActivityMonitoringRule
   {
      public SysmonCondition[] Conditions { get; set; }
      public string MainGroupRelation { get; set; }
   }
}

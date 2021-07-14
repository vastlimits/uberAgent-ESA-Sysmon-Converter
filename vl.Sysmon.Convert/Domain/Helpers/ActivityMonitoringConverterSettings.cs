using vl.Core.Domain.ActivityMonitoring;

namespace vl.Sysmon.Convert.Domain.Helpers
{
   public class ActivityMonitoringConverterSettings
   {
      public EventType EventType { get; set; }
      public string Name { get; set; }
      public string Tag { get; set; }
      public SysmonCondition[] Conditions { get; set; }
      public string Comment { get; set; }
   }

   public class SysmonCondition
   {
      public string Condition { get; set; }
      public string Field { get; set; }
      public string Value { get; set; }
      public string GroupRelation { get; set; }
      public string OnMatch { get; set; }
   }
}

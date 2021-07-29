﻿using vl.Core.Domain.ActivityMonitoring;

namespace vl.Sysmon.Converter.Domain.Helpers
{
   public class ActivityMonitoringConverterSettings
   {
      public EventType EventType { get; set; }
      public Hive Hive { get; set; }
      public string Name { get; set; }
      public string Tag { get; set; }
      public SysmonCondition[] Conditions { get; set; }
      public string MainGroupRelation { get; set; }
   }

   public class SysmonCondition : SysmonConditionBase
   {
      public int RuleId { get; set; }
      public string GroupRelation { get; set; }
      public string OnMatch { get; set; }
   }

   public class SysmonConditionBase
   {
      public string Field { get; set; }
      public string Value { get; set; }
      public string Condition { get; set; }
   }
}
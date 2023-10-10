using System;

namespace vl.Core.Domain.Activity
{
   public class ActivityMonitoringRule
   {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public EventType EventType {get; set;}
      public Hive Hive { get; set; }
      public string Tag { get; set; }
      public string Query { get; set; }
   }
}

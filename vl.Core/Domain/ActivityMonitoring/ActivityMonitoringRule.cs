namespace vl.Core.Domain.ActivityMonitoring
{
   public class ActivityMonitoringRule
   {
      public string RuleName { get; set; }
      public EventType EventType {get; set;}
      public string Tag { get; set; }
      public string Query { get; set; }
   }
}

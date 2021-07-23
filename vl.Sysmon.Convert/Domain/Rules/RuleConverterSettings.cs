using vl.Core.Domain.ActivityMonitoring;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class RuleConverterSettings
   {
      public EventType CurrentEventType { get; set; } = EventType.Unknown;
      public Hashes[] HashAlgorithms { get; set; } = { Hashes.None };
   }
}

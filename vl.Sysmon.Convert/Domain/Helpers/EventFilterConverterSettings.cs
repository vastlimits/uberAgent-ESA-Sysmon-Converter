using System.Collections.Generic;
using vl.Core.Domain.EventData;

namespace vl.Sysmon.Convert.Domain.Helpers
{
   public class EventFilterConverterSettings
   {
      public EventDataFilterAction Action { get; set; }
      public List<string> Sourcetypes { get; set; } = new();
      public string Field { get; set; }
      public string Condition { get; set; }
      public string Value { get; set; }
      public string Comment { get; set; }
   }
}

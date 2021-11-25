using System.Collections.Generic;

namespace vl.Core.Domain.EventData
{
    public class EventDataFilter
    {
        public string Comment { get; set; }
        public EventDataFilterAction Action { get; set; } = EventDataFilterAction.Allow;
        public List<string> Sourcetypes { get; set; } = new();
        public List<string> Fields { get; set; } = new();
        public string Query { get; set; }
    }
}

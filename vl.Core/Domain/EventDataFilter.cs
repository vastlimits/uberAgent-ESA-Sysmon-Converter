using System.Collections.Generic;

namespace vl.Core.Domain
{
    public class EventDataFilter
    {
        public string Comment { get; set; }
        public EventDataFilterAction Action { get; set; } = EventDataFilterAction.Allow;
        public List<string> Sourcetypes { get; set; } = new List<string>();
        public List<string> Fields { get; set; } = new List<string>();
        public string Query { get; set; }
    }
}

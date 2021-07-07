using System.Collections.Generic;
using System.IO;
using System.Text;

namespace vl.Core.Domain.EventData
{
    public static class EventDataFilterSerializer
    {
        public static void Serialize(Stream stream, IEnumerable<EventDataFilter> filters, string headerComment)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                sw.WriteLine(headerComment);

                foreach (var filter in filters)
                {
                    sw.WriteLine("[EventDataFilter]");
                    
                    if (!string.IsNullOrEmpty(filter.Comment))
                        sw.WriteLine($"# {filter.Comment}");

                    sw.WriteLine($"Action = {filter.Action.ToString().ToLower()}");
                    
                    foreach (var sourcetype in filter.Sourcetypes)
                        sw.WriteLine($"Sourcetype = {sourcetype}");

                    foreach (var field in filter.Fields)
                        sw.WriteLine($"Field = {field}");

                    sw.WriteLine($"Query = {filter.Query}");
                    sw.WriteLine(string.Empty);
                }
            }

            var contents = sb.ToString();
            var contentsUtf8 = Encoding.UTF8.GetBytes(contents);
            stream.Write(contentsUtf8);
        }
    }
}

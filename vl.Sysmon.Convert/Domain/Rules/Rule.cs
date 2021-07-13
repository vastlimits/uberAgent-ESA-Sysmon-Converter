using System;
using System.Collections.Generic;
using Serilog;
using vl.Core.Domain;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class Rule
   {
      protected static readonly ILogger Log = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();

      private static string ConvertQuery(string field, string condition, string value)
      {
         return condition switch
         {
            "is" => $"{field} == \"{value}\"",
            "begin with" => $"istartswith({field}, \"{value}\")",
            "end with" => $"iendswith({field}, \"{value}\")",
            "contains" => $"icontains({field}, \"{value}\")",
            "image" => $"icontains({field}, \"{value}\")",
            _ => throw new NotImplementedException()
         };
      }

      protected static EventDataFilter Convert(ConverterSettings settings)
      {
         return new()
         {
            Action = settings.Action,
            Fields = new List<string>(),
            Sourcetypes = settings.Sourcetypes,
            Query = ConvertQuery(settings.Field, settings.Condition, settings.Value),
            Comment = settings.Comment
         };
      }
   }
}

using System;
using Serilog;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class Rule
   {
      protected static readonly ILogger Log = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();

      protected static string ConvertQuery(string property, string condition, string value)
      {
         return condition switch
         {
            "is" => $"{property} == \"{value}\"",
            "begin with" => $"istartswith({property}, \"{value}\")",
            "end with" => $"iendswith({property}, \"{value}\")",
            "contains" => $"icontains({property}, \"{value}\")",
            "image" => $"icontains({property}, \"{value}\")",
            _ => throw new NotImplementedException()
         };
      }
   }
}

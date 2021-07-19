using System.Collections.Generic;

namespace vl.Sysmon.Convert.Domain.Helpers.Wrappers
{
   public class NetworkConnect
   {
      public List<object> Items { get; set; } = new();
      public string onmatch { get; set; }
      public string groupRelation { get; set; }
   }
}

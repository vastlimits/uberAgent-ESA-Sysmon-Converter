using System.Collections.Generic;
using System.IO;

namespace vl.Core.Domain.Activity
{
   public class ActivitySerializeOptions
   {
      public Stream Stream { get; set;}
      public IEnumerable<ActivityMonitoringRule> Rules { get; set; }
      public int RiskScore { get; set; }
   }
}

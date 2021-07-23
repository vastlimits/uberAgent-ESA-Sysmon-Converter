using System.Collections.Generic;
using System.IO;
using System.Text;

namespace vl.Core.Domain.ActivityMonitoring
{
   public static class ActivityMonitoringRuleSerializer
   {
      /*
         [ActivityMonitoringRule]
         RuleName = Detect Backslashy
         EventType = Process.Start
         Tag = Test1
         RiskScore = 100
         Query = icontains(Process.Path, r"C:\Users\") or icontains(Process.Path, r"\AppData\Local\Microsoft\OneDrive") or icontains(Process.Path, r"\FileCoAuth.exe")
       */

      public static void Serialize(Stream stream, IEnumerable<ActivityMonitoringRule> rules)
      {
         var sb = new StringBuilder();
         using (var sw = new StringWriter(sb))
         {
            foreach (var rule in rules)
            {
               sw.WriteLine("[ActivityMonitoringRule]");
               sw.WriteLine($"RuleName = {rule.RuleName}");
               sw.WriteLine($"EventType = {rule.EventType}");
               sw.WriteLine($"Tag = {rule.Tag}");
               sw.WriteLine($"RiskScore = 100");
               sw.WriteLine($"{rule.Query}");
               sw.WriteLine(string.Empty);
            }
         }

         var contents = sb.ToString();
         var contentsUtf8 = Encoding.UTF8.GetBytes(contents);
         stream.Write(contentsUtf8);
      }
   }
}
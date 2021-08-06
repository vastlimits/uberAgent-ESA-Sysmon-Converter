using System.Collections.Generic;
using System.IO;
using System.Text;
using vl.Core.Domain.Extensions;

namespace vl.Core.Domain.Activity
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

               if (string.IsNullOrEmpty(rule.Name))
                  rule.Name = "A Sysmon converted rule";

               if (string.IsNullOrEmpty(rule.Tag))
                  rule.Tag= "A-Sysmon-converted-rule";

               sw.WriteLine($"RuleName = {rule.Name}");
               sw.WriteLine($"EventType = {rule.EventType.ToActivityMonitoringString()}");
               sw.WriteLine($"Tag = {rule.Tag}");
               sw.WriteLine($"RiskScore = 100");
               sw.WriteLine($"Query = {rule.Query}");

               if (rule.Hive != Hive.Unknown)
                  sw.WriteLine($"Hive = {rule.Hive.ToActivityMonitoringHive()}");

               sw.WriteLine(string.Empty);
            }
         }

         var contents = sb.ToString();
         var contentsUtf8 = Encoding.UTF8.GetBytes(contents);
         stream.Write(contentsUtf8);
      }
   }
}
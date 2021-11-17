using System.Collections.Generic;
using System.IO;
using System.Text;
using vl.Core.Domain.Extensions;

namespace vl.Core.Domain.Activity
{

   public static class ActivityMonitoringRuleSerializer
   {
      private static readonly Dictionary<EventType, int> EventCounter = new ();

      /*
         [ActivityMonitoringRule]
         RuleName = Detect Backslash
         EventType = Process.Start
         Tag = Test1
         RiskScore = 100
         Query = icontains(Process.Path, r"C:\Users\") or icontains(Process.Path, r"\AppData\Local\Microsoft\OneDrive") or icontains(Process.Path, r"\FileCoAuth.exe")
      */

      public static void Serialize(ActivitySerializeOptions options)
      {
         var sb = new StringBuilder();
         using (var sw = new StringWriter(sb))
         {
            foreach (var rule in options.Rules)
            {
               sw.WriteLine("[ActivityMonitoringRule]");

               if (string.IsNullOrEmpty(rule.Name))
                  rule.Name = $"{rule.EventType} converted rule";

               if (string.IsNullOrEmpty(rule.Tag))
                  rule.Tag = $"{rule.EventType}-{GetEventCounter(rule.EventType)}-converted-rule";

               sw.WriteLine($"RuleName = {rule.Name}");
               sw.WriteLine($"EventType = {rule.EventType.ToActivityEventName()}");
               sw.WriteLine($"Tag = {rule.Tag}");
               sw.WriteLine($"RiskScore = {options.RiskScore}");
               sw.WriteLine($"Query = {rule.Query}");

               if (rule.Hive != Hive.Unknown)
                  sw.WriteLine($"Hive = {rule.Hive.ToActivityRegistryHive()}");

               sw.WriteLine(string.Empty);
            }
         }

         var contents = sb.ToString();
         var contentsUtf8 = Encoding.UTF8.GetBytes(contents);
         options.Stream.Write(contentsUtf8);
      }

      private static int GetEventCounter(EventType ruleEventType)
      {
         if (EventCounter.ContainsKey(ruleEventType))
            return ++EventCounter[ruleEventType];

         EventCounter.Add(ruleEventType, 1);
         return 1;
      }
   }
}

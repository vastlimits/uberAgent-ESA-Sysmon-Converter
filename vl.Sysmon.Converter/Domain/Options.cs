using System.Collections.Generic;
using CommandLine;
using vl.Core.Domain;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain;

public class Options
{
   [Option('i', "input", Required = true, HelpText = "Input files to be processed.")]
   public IEnumerable<string> InputFiles { get; set; }

   [Option('o', "output", Required = true, HelpText = "Output folder, if files in folder already exists, its previous content will be replaced by the new one.")]
   public string OutputDirectory { get; set; }

   [Option('r', "rule", Required = false, HelpText = "Specify the Sysmon rule IDs to be converted. If not set, all possible rules will be converted. E.g: -r 1 2")]
   public IEnumerable<SysmonEventId> RulesToConvert { get; set; }

   [Option('v', "version", Required = false, HelpText = "Specify the uberAgent version to get only supported rules converted. If not set, the latest version is used. E.g: -v 6.1")]
   public string Version
   {
      get => UAVersion.ToString();
      set
      {
         if (value.StartsWith("6.0"))
         {
            UAVersion = UAVersion.UA_VERSION_6_0;
            return;
         }

         if (value.StartsWith("6.1"))
         {
            UAVersion = UAVersion.UA_VERSION_6_1;
            return;
         }

         if (value.StartsWith("6.2"))
         {
            UAVersion = UAVersion.UA_VERSION_6_2;
            return;
         }

         if (value.StartsWith("7.0"))
         {
            UAVersion = UAVersion.UA_VERSION_7_0;
            return;
         }

         if (value.StartsWith("7.1"))
         {
            UAVersion = UAVersion.UA_VERSION_7_1;
            return;
         }

         if (value.StartsWith("7.2"))
         {
            UAVersion = UAVersion.UA_VERSION_7_2;
            return;
         }
      }
   }

   [Option('s', "score", Required = false,
      HelpText =
         "Specify the risk score for all rules that will be converted. If not set, the Risk Score of 50 is used for all rules. E.g: -s 75")]
   public int RiskScore { get; set; } = 50;

   public UAVersion UAVersion { get; set; } = UAVersion.UA_VERSION_CURRENT_RELEASE;
}
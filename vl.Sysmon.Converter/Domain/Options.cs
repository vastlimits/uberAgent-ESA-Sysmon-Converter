using System.Collections.Generic;
using CommandLine;
using Serilog;
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

   [Option('v', "version", Required = false, HelpText = "Specify the uberAgent version to get only supported rules converted. If not set or invalid, the latest version is used. E.g: -v 7.2")]
   public string Version
   {
      get => UAVersion.ToString();
      set
      {
         UAVersion = UAVersionExtensions.ParseVersion(value);
         if (UAVersion == UAVersion.UA_VERSION_CURRENT_RELEASE && !string.IsNullOrEmpty(value))
         {
            Log.Warning($"Invalid version '{value}' specified. Using the latest version {UAVersion.ToVersionString()}.");
         }
         else
         {
            Log.Information($"Using uberAgent {UAVersion.ToVersionString()} as target version for conversion.");
         }
      }
   }

   [Option('s', "score", Required = false, HelpText = "Specify the risk score for all rules that will be converted. If not set, the Risk Score of 50 is used for all rules. E.g: -s 75")]
   public int RiskScore { get; set; } = 50;

   public UAVersion UAVersion { get; set; } = UAVersion.UA_VERSION_CURRENT_RELEASE;
}
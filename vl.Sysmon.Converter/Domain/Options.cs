using System.Collections.Generic;
using CommandLine;
using vl.Core.Domain.Activity;

namespace vl.Sysmon.Converter.Domain
{
   public class Options
   {
      [Option('i', "input", Required = true, HelpText = "Input files to be processed.")]
      public IEnumerable<string> InputFiles { get; set; }

      [Option('o', "output", Required = true, HelpText = "Output folder, if files in folder already exists, its previous content will be replaced by the new one.")]
      public string OutputDirectory { get; set; }

      [Option('r', "rule", Required = false, HelpText = "Specify the Sysmon rule IDs to be converted. If not set, all possible rules will be converted. E.g: -r 1 2")]
      public IEnumerable<SysmonEventId> RulesToConvert { get; set; }

      [Option('s', "score", Required = false,
              HelpText =
                 "Specify the risk score for all rules that will be converted. If not set, the Risk Score of 50 is used for all rules. E.g: -s 75")]
      public int RiskScore { get; set; } = 50;
   }
}

﻿using System.Collections.Generic;
using CommandLine;

namespace vl.Sysmon.Converter.Domain
{
   public class Options
   {
      [Option('i', "input", Required = true, HelpText = "Input files to be processed.")]
      public IEnumerable<string> InputFiles { get; set; }

      [Option('o', "output", Required = true, HelpText = "Output file, if file already exists, its previous content will be replaced by the new one.")]
      public string OutputFile { get; set; }

      [Option('r', "rule", Required = false, HelpText = "Specify the Sysmon rule IDs to be converted. If not set, all possible rules will be converted. E.g: -r 1 2")]
      public IEnumerable<int> RulesToConvert { get; set; }
   }
}
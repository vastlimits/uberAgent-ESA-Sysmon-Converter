using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using vl.Core.Domain.ActivityMonitoring;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain;
using vl.Sysmon.Convert.Domain.Rules;

namespace vl.Sysmon.Convert
{
   class Program
   {
      private static readonly ILogger Log = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();
      private static Options _options = new();

      private static void Main(string[] args)
      {
         Log.Information("vl.Sysmon.Convert starting..");
         
         var configurations = new List<Domain.Sysmon>();

         Parser.Default.ParseArguments<Options>(args)
               .WithParsed<Options>(o =>
               {
                  _options = o;
               })
               .WithNotParsed<Options>(e =>
               {
                  Environment.Exit(-1);
               });

         foreach (var file in _options.InputFiles)
         {
            var config = ParseConfiguration(file);
            if (config == null)
               Environment.Exit(-1);

            configurations.Add(config);
         }
         
         var result = ConvertConfiguration(configurations);
         if (!result)
            Environment.Exit(-1);

         Log.Information("Done.");
      }

      private static bool ConvertConfiguration(IEnumerable<Domain.Sysmon> configs)
      {
         var eventDataFilters = new List<EventDataFilter>();
         var activityMonitoringRules = new List<ActivityMonitoringRule>();

         foreach (var config in configs)
         {
            eventDataFilters.AddRange(DNSQuery.ConvertExcludeRules(config));
            eventDataFilters.AddRange(ProcessStartup.ConvertExcludeRules(config));
         }

         return Serialize(_options.OutputFile, eventDataFilters.ToArray());
      }

      private static bool Serialize(string outputFile, IEnumerable<EventDataFilter> filters)
      {
         try
         {
            Log.Information("Serialize rules to {file}", outputFile);

            using (var fs = new FileStream(outputFile, FileMode.Create))
            {
               EventDataFilterSerializer.Serialize(fs, filters, Constants.ConversionHeaderComment);
               return true;
            }
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to serialize rules to {outputFile}.");
         }

         return false;
      }

      private static Domain.Sysmon ParseConfiguration(string filePath)
      {
         try
         {
            if (!File.Exists(filePath))
            {
               Log.Fatal("Configuration {file} does not exists.", filePath);
               return null;
            }

            Log.Information("Parse configuration {file}.", filePath);
            return SysmonConfigParser.ParseConfiguration(filePath);
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to parse configuration file: {filePath}.");
         }

         return null;
      }
   }
}

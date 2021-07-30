using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using Serilog;
using Serilog.Core;
using vl.Core.Domain.ActivityMonitoring;
using vl.Core.Domain.EventData;
using vl.Sysmon.Converter.Domain;
using vl.Sysmon.Converter.Domain.Extensions;
using vl.Sysmon.Converter.Domain.Rules;
using Constants = vl.Sysmon.Converter.Domain.Constants;

namespace vl.Sysmon.Converter
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
               .WithParsed(o =>
               {
                  _options = o;
               })
               .WithNotParsed(e =>
               {
                  Environment.Exit(-1);
               });

         try
         {
            if (!Directory.Exists(_options.OutputFolder))
            {
               Log.Information("Folder does not exist, create folder: {folder}", _options.OutputFolder);
               Directory.CreateDirectory(_options.OutputFolder);
            }
         }
         catch (Exception e)
         {
            Log.Error("Failed to create Folder: {innerException}", e.InnerException);
         }
         

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
            var configListedRules = config.GetSysmonRulesListed();
            
            eventDataFilters.AddRange(DNSQuery.ConvertExcludeRules(configListedRules.DnsQuery));
            activityMonitoringRules.AddRange(ProcessStartup.ConvertRules(configListedRules.ProcessCreate));
            activityMonitoringRules.AddRange(ProcessStop.ConvertRules(configListedRules.ProcessTerminate));
            activityMonitoringRules.AddRange(ProcessNetwork.ConvertRules(configListedRules.NetworkConnect));
            activityMonitoringRules.AddRange(Registry.ConvertRules(configListedRules.RegistryEvent));
            activityMonitoringRules.AddRange(ImageLoad.ConvertRules(configListedRules.ImageLoad));
         }

         return Serialize(_options.OutputFolder, eventDataFilters.ToArray(), activityMonitoringRules.ToArray());
      }

      private static bool Serialize(string outputFile, IEnumerable<EventDataFilter> filters, IEnumerable<ActivityMonitoringRule> rules)
      {
         try
         {
            Log.Information("Serialize rules to {file}", outputFile);

            var eventDataPath = Path.Combine(outputFile, Constants.EventDataFilterOutputFileName);
            var activityPath = Path.Combine(outputFile, Constants.ActivityMonitoringOutputFileName);

            using (var fs = new FileStream(eventDataPath, FileMode.Create))
            {
               EventDataFilterSerializer.Serialize(fs, filters);
            }
            using (var fs = new FileStream(activityPath, FileMode.Create))
            {
               ActivityMonitoringRuleSerializer.Serialize(fs, rules);
            }

            return true;
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

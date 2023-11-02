using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;
using Serilog;
using vl.Core.Domain.Activity;
using vl.Core.Domain.EventData;
using vl.Sysmon.Converter.Domain;
using vl.Sysmon.Converter.Domain.Activity;
using vl.Sysmon.Converter.Domain.EventData;
using vl.Sysmon.Converter.Domain.Extensions;
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
         Log.Information("Sysmon Converter starting..");
         
         var configurations = new List<NamedConfig>();

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
            if (!Directory.Exists(_options.OutputDirectory))
            {
               Log.Information("Directory does not exist, create directory: {directory}", _options.OutputDirectory);
               Directory.CreateDirectory(_options.OutputDirectory);
            }
         }
         catch (Exception e)
         {
            Log.Error("Failed to create directory: {innerException}", e.InnerException);
         }
         

         foreach (var file in _options.InputFiles)
         {
            var config = ParseConfiguration(file);
            if (config == null)
               Environment.Exit(-1);

            configurations.Add(new NamedConfig
            {
               Name = Path.GetFileNameWithoutExtension(file),
               Config = config
            });
         }
         
         var result = ConvertConfiguration(configurations);
         if (!result)
            Environment.Exit(-1);

         Log.Information("Done.");
      }

      private static bool ConvertConfiguration(IEnumerable<NamedConfig> configurations)
      {
         var eventDataFilters = new List<EventDataFilter>();
         var activityMonitoringRules = new List<ActivityMonitoringRule>();

         foreach (var namedConfig in configurations)
         {
            Console.WriteLine();
            Log.Information("---- Converting file: {0} ----", namedConfig.Name);
            var configGroupedListedRules = namedConfig.Config.GetSysmonRulesFromGroupListed();
            configGroupedListedRules = namedConfig.Config.GetSysmonRules(configGroupedListedRules);

            if (configGroupedListedRules == null)
            {
               Log.Error("Could not find any rule groups <RuleGroup> in {0}, skip.", namedConfig.Name);
               continue;
            }

            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.NetworkConnect, "NetworkConnect", EventType.NetConnect));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ProcessCreate, "ProcessCreate", EventType.ProcessCreate));

            if (!_options.RulesToConvert.Any())
            {
               /*eventDataFilters.AddRange(DNSQuery.ConvertExcludeRules(configGroupedListedRules.DnsQuery));
               activityMonitoringRules.AddRange(ProcessStartup.ConvertRules(configGroupedListedRules.ProcessCreate));
               activityMonitoringRules.AddRange(ProcessStop.ConvertRules(configGroupedListedRules.ProcessTerminate));
               activityMonitoringRules.AddRange(ProcessNetwork.ConvertRules(configGroupedListedRules.NetworkConnect));
               activityMonitoringRules.AddRange(Registry.ConvertRules(configGroupedListedRules.RegistryEvent));
               activityMonitoringRules.AddRange(ImageLoad.ConvertRules(configGroupedListedRules.ImageLoad));
               activityMonitoringRules.AddRange(CreateRemoteThread.ConvertRules(configGroupedListedRules.CreateRemoteThread));
               activityMonitoringRules.AddRange(ProcessTampering.ConvertRules(configGroupedListedRules.ProcessTampering));
               activityMonitoringRules.AddRange(DriverLoad.ConvertRules(configGroupedListedRules.DriverLoad));
               activityMonitoringRules.AddRange(FileCreate.ConvertRules(configGroupedListedRules.FileCreate));
               activityMonitoringRules.AddRange(FileCreateTime.ConvertRules(configGroupedListedRules.FileCreateTime));
               activityMonitoringRules.AddRange(FileCreateStreamHash.ConvertRules(configGroupedListedRules.FileCreateStreamHash));
               activityMonitoringRules.AddRange(FileDelete.ConvertRules(configGroupedListedRules.FileDelete));
               activityMonitoringRules.AddRange(FilePipeEvent.ConvertRules(configGroupedListedRules.PipeEvent));
               activityMonitoringRules.AddRange(FileRawAccessRead.ConvertRules(configGroupedListedRules.RawAccessRead));*/
            }
            else
            {
              /* foreach (var ruleId in _options.RulesToConvert)
               {
                  switch (ruleId)
                  {
                     case SysmonEventId.DNSQuery:
                        eventDataFilters.AddRange(DNSQuery.ConvertExcludeRules(configGroupedListedRules.DnsQuery));
                        break;
                     case SysmonEventId.ProcessCreate:
                        activityMonitoringRules.AddRange(ProcessStartup.ConvertRules(configGroupedListedRules.ProcessCreate));
                        break;
                     case SysmonEventId.NetworkConnect:
                        activityMonitoringRules.AddRange(ProcessNetwork.ConvertRules(configGroupedListedRules.NetworkConnect));
                        break;
                     case SysmonEventId.ProcessTerminate:
                        activityMonitoringRules.AddRange(ProcessStop.ConvertRules(configGroupedListedRules.ProcessTerminate));
                        break;
                     case SysmonEventId.ImageLoad:
                        activityMonitoringRules.AddRange(ImageLoad.ConvertRules(configGroupedListedRules.ImageLoad));
                        break;
                     case SysmonEventId.CreateRemoteThread:
                        activityMonitoringRules.AddRange(CreateRemoteThread.ConvertRules(configGroupedListedRules.CreateRemoteThread));
                        break;
                     case SysmonEventId.RegistryEvent:
                        activityMonitoringRules.AddRange(Registry.ConvertRules(configGroupedListedRules.RegistryEvent));
                        break;
                     case SysmonEventId.ProcessTampering:
                        activityMonitoringRules.AddRange(ProcessTampering.ConvertRules(configGroupedListedRules.ProcessTampering));
                        break;
                     case SysmonEventId.DriverLoad:
                        activityMonitoringRules.AddRange(DriverLoad.ConvertRules(configGroupedListedRules.DriverLoad));
                        break;
                     case SysmonEventId.FileCreateStreamHash:
                        activityMonitoringRules.AddRange(FileCreateStreamHash.ConvertRules(configGroupedListedRules.FileCreateStreamHash));
                        break;
                     case SysmonEventId.FileCreateTime:
                        activityMonitoringRules.AddRange(FileCreateTime.ConvertRules(configGroupedListedRules.FileCreateTime));
                        break;
                     case SysmonEventId.RawAccessRead:
                        activityMonitoringRules.AddRange(FileRawAccessRead.ConvertRules(configGroupedListedRules.RawAccessRead));
                        break;
                     case SysmonEventId.FileCreate:
                        activityMonitoringRules.AddRange(FileCreate.ConvertRules(configGroupedListedRules.FileCreate));
                        break;
                     case SysmonEventId.PipeEvent:
                        activityMonitoringRules.AddRange(FilePipeEvent.ConvertRules(configGroupedListedRules.PipeEvent));
                        break;
                     case SysmonEventId.FileDelete:
                     case SysmonEventId.FileDeleteDetected:
                        activityMonitoringRules.AddRange(FileDelete.ConvertRules(configGroupedListedRules.FileDelete));
                        break;
                     case SysmonEventId.ClipboardChange:
                     case SysmonEventId.WmiEvent:
                     case SysmonEventId.ProcessAccess:
                     default:
                        Log.Warning("Rule: {0} is currently not supported!", ruleId);
                        break;
                  }
               }*/
            }

            Log.Information("---- Finished converting file: {0} ----", namedConfig.Name);
         }
         
         Console.WriteLine();

         return Serialize(_options, eventDataFilters.ToArray(), activityMonitoringRules.ToArray());
      }

      private static bool Serialize(Options options, EventDataFilter[] filters, ActivityMonitoringRule[] rules)
      {
         try
         {
            if (filters.Length == 0 && rules.Length == 0)
            {
               Log.Information("Nothing to convert.");
               return true;
            }

            Log.Information("Serialize rules to {directory}", options.OutputDirectory);

            var eventDataPath = Path.Combine(options.OutputDirectory, Constants.EventDataFilterOutputFileName);
            var activityPath = Path.Combine(options.OutputDirectory, Constants.ActivityMonitoringOutputFileName);

            if (filters.Length > 0)
            {
               using (var fs = new FileStream(eventDataPath, FileMode.Create))
               {
                  EventDataFilterSerializer.Serialize(fs, filters);
               }
            }

            if (rules.Length == 0) 
               return true;

            using (var fs = new FileStream(activityPath, FileMode.Create))
            {
               ActivityMonitoringRuleSerializer.Serialize(
                  new ActivitySerializeOptions
                  {
                     RiskScore = options.RiskScore,
                     Rules = rules,
                     Stream = fs
                  });
            }

            return true;
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to serialize rules to {options.OutputDirectory}.");
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

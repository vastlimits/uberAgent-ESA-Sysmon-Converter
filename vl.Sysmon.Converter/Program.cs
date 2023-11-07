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

namespace vl.Sysmon.Converter;

class Program
{
   private static readonly ILogger Log = new LoggerConfiguration()
      .WriteTo.Console()
      .CreateLogger();
   private static Options _options = new();
   private static readonly List<EventType> RegistryEventTypes = new()
   {
      EventType.RegKeyCreate, EventType.RegKeyDelete, EventType.RegValueWrite, EventType.RegKeyRename
   };

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

         if (!_options.RulesToConvert.Any())
         {
            eventDataFilters.AddRange(DNSQuery.ConvertExcludeRules(configGroupedListedRules.DnsQuery));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ProcessCreate, "ProcessCreate", EventType.ProcessCreate));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ProcessTerminate, "ProcessTerminate", EventType.ProcessTerminate));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.NetworkConnect, "NetworkConnect", EventType.NetConnect));

            var removedAnyEventType = HandlePreConvertingRegistry(configGroupedListedRules.RegistryEvent);
            if (removedAnyEventType)
            {
               activityMonitoringRules.AddRange(RegistryEventTypes.Select(eventType => SysmonActivityMonitoringRule.Create(configGroupedListedRules.RegistryEvent, "RegistryEvent", eventType)));
            }
            else
            {
               activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.RegistryEvent, "RegistryEvent", EventType.RegAny));
            }

            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ImageLoad, "ImageLoad", EventType.ImageLoad));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.CreateRemoteThread, "CreateRemoteThread", EventType.CreateRemoteThread));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ProcessTampering, "ProcessTampering", EventType.ProcessTampering));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.DriverLoad, "DriverLoad", EventType.DriverLoad));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileCreate, "FileCreate", EventType.FileCreate));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileCreateTime, "FileCreateTime", EventType.FileCreateTime));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileCreateStreamHash, "FileCreateStreamHash", EventType.FileCreateStreamHash));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileDelete, "FileDelete", EventType.FileDelete));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.PipeEvent, "FilePipeConnected", EventType.FilePipeConnected));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.PipeEvent, "FilePipeCreate", EventType.FilePipeCreate));
            activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.RawAccessRead, "RawAccessRead", EventType.RawAccessRead));
         }
         else
         {
            foreach (var ruleId in _options.RulesToConvert)
            {
               switch (ruleId)
               {
                  case SysmonEventId.DNSQuery:
                     eventDataFilters.AddRange(DNSQuery.ConvertExcludeRules(configGroupedListedRules.DnsQuery));
                     break;
                  case SysmonEventId.ProcessCreate:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ProcessCreate, "ProcessCreate", EventType.ProcessCreate));
                     break;
                  case SysmonEventId.NetworkConnect:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.NetworkConnect, "NetworkConnect", EventType.NetConnect));
                     break;
                  case SysmonEventId.ProcessTerminate:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ProcessTerminate, "ProcessTerminate", EventType.ProcessTerminate));
                     break;
                  case SysmonEventId.ImageLoad:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ImageLoad, "ImageLoad", EventType.ImageLoad));
                     break;
                  case SysmonEventId.CreateRemoteThread:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.CreateRemoteThread, "CreateRemoteThread", EventType.CreateRemoteThread));
                     break;
                  case SysmonEventId.RegistryEventAddDelete:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.RegistryEvent, "RegistryEvent", EventType.RegKeyCreate));
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.RegistryEvent, "RegistryEvent", EventType.RegKeyDelete));
                     break;
                  case SysmonEventId.RegistryEventValueSet:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.RegistryEvent, "RegistryEvent", EventType.RegValueWrite));
                     break;
                  case SysmonEventId.RegistryEventobjectRenamed:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.RegistryEvent, "RegistryEvent", EventType.RegKeyRename));
                     break;
                  case SysmonEventId.ProcessTampering:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.ProcessTampering, "ProcessTampering", EventType.ProcessTampering));
                     break;
                  case SysmonEventId.DriverLoad:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.DriverLoad, "DriverLoad", EventType.DriverLoad));
                     break;
                  case SysmonEventId.FileCreateStreamHash:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileCreateStreamHash, "FileCreateStreamHash", EventType.FileCreateStreamHash));
                     break;
                  case SysmonEventId.FileCreateTime:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileCreateTime, "FileCreateTime", EventType.FileCreateTime));
                     break;
                  case SysmonEventId.RawAccessRead:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.RawAccessRead, "RawAccessRead", EventType.RawAccessRead));
                     break;
                  case SysmonEventId.FileCreate:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileCreate, "FileCreate", EventType.FileCreate));
                     break;
                  case SysmonEventId.PipeEventCreated:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.PipeEvent, "PipeEvent", EventType.FilePipeCreate));
                     break;
                  case SysmonEventId.PipeEventConnected:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.PipeEvent, "PipeEvent", EventType.FilePipeConnected));
                     break;
                  case SysmonEventId.FileDelete:
                  case SysmonEventId.FileDeleteDetected:
                     activityMonitoringRules.Add(SysmonActivityMonitoringRule.Create(configGroupedListedRules.FileDelete, "FileDelete", EventType.FileDelete));
                     break;
                  case SysmonEventId.ClipboardChange:
                  case SysmonEventId.WmiEvent:
                  case SysmonEventId.ProcessAccess:
                  default:
                     Log.Warning("Rule: {0} is currently not supported!", ruleId);
                     break;
               }
            }
         }

         Log.Information("---- Finished converting file: {0} ----", namedConfig.Name);
      }
         
      Console.WriteLine();

      return Serialize(_options, eventDataFilters.ToArray(), activityMonitoringRules.ToArray());
   }

   private static bool HandlePreConvertingRegistry(List<SysmonEventFilteringRuleGroupRegistryEvent> sysmonGroupActivities)
   {
      var retn = false;
      var excludes = (from ruleGroup in sysmonGroupActivities
         where ruleGroup.onmatch.Equals(Constants.SysmonExcludeOnMatchString) && ruleGroup.Items != null
         select ruleGroup.Items.Where(c => c.GetType() == typeof(SysmonEventFilteringRuleGroupRegistryEventEventType))
         into toExcludeEventTypes
         from SysmonEventFilteringRuleGroupRegistryEventEventType item in toExcludeEventTypes
         select item).ToArray();

      foreach (var item in excludes)
      {
         switch (item.Value)
         {
            case "SetValue":
               RegistryEventTypes.Remove(EventType.RegValueWrite);
               retn = true;
               break;
            case "CreateKey":
               RegistryEventTypes.Remove(EventType.RegKeyCreate);
               retn = true;
               break;
            case "DeleteKey":
               RegistryEventTypes.Remove(EventType.RegKeyDelete);
               retn = true;
               break;
            case "RenameKey":
               RegistryEventTypes.Remove(EventType.RegKeyRename);
               retn = true;
               break;
         }
      }

      return retn;
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
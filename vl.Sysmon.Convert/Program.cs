using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
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

      private const string TestFile = @"C:\tmp\sysmonconfig-export.xml";
      private const string TestOutputFile = @"C:\tmp\uberAgent-eventdata-filter-sysmon.conf";


      private static void Main(string[] args)
      {
         Log.Information("vl.Sysmon.Convert starting..");

         var config = ParseConfiguration(TestFile);
         if (config == null)
            Environment.Exit(-1);

         var result = ConvertConfiguration(config);
         if (!result)
            Environment.Exit(-1);

         Log.Information("Done.");
      }

      private static bool ConvertConfiguration(Domain.Sysmon config)
      {
         var eventDataFilters = new List<EventDataFilter>();
         var activityMonitoringRules = new List<ActivityMonitoringRule>();
         
         eventDataFilters.AddRange(DNSQuery.ConvertExcludeRules(config));
         eventDataFilters.AddRange(ProcessStartup.ConvertExcludeRules(config));

         return Serialize(eventDataFilters.ToArray());
      }

      private static bool Serialize(EventDataFilter[] filters)
      {
         try
         {
            Log.Information("Serialize rules to {file}", TestOutputFile);

            using (var fs = new FileStream(TestOutputFile, FileMode.Create))
            {
               EventDataFilterSerializer.Serialize(fs, filters, Constants.ConversionHeaderComment);
               return true;
            }
         }
         catch (Exception ex)
         {
            Log.Error(ex, $"Failure to serialize rules for DNS to {TestOutputFile}.");
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

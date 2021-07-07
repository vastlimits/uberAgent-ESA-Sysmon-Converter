using Serilog;
using System;
using System.IO;
using vl.Core.Domain;
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
        

        static void Main(string[] args)
        {
            Log.Information("vl.Sysmon.Convert starting..");

            var config = ParseConfiguration(TestFile);
            if (config == null) 
                goto Failure;

            var dnsRules = DNSQuery.GetExcludeRulesForDNS(config);
            if (dnsRules == null || dnsRules.Length == 0)
                goto Failure;

            var filters = DNSQuery.ConvertExcludeRulesForDNS(dnsRules);
            if (filters == null || filters.Length == 0)
                goto Failure;

            if (Serialize(filters))
            {
                Log.Information("Done.");
                Environment.Exit(0);
            }

        Failure:
            Log.Information("Aborted.");
            Environment.Exit(-1);
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
                Log.Information("Parse configuration {file}..", TestFile);
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

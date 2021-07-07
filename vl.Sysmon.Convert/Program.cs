using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using vl.Core.Domain;
using vl.Sysmon.Convert.Domain;
using vl.Sysmon.Convert.Domain.Extensions;

namespace vl.Sysmon.Convert
{
    class Program
    {
       private static readonly ILogger Log = new LoggerConfiguration()
                                             .WriteTo.Console()
                                             .CreateLogger();

        private const string TestFile = @"C:\tmp\sysmonconfig-export.xml";
        private const string TestOutputFile = @"C:\tmp\uberAgent-eventdata-filter-sysmon.conf";
        private const string ConversionComment = "Source: https://github.com/SwiftOnSecurity/sysmon-config";
        private const string ConversionHeaderComment = "" +
                                                      "#\n" +
                                                      "# The rules are converted from sysmonconfig-export.xml.\n" +
                                                      "# GitHub repository at https://github.com/SwiftOnSecurity/sysmon-config/blob/master/sysmonconfig-export.xml\n" +
                                                      "# Git Commit: cbc22e8\n" +
                                                      "#\n";

        static void Main(string[] args)
        {
            Log.Information("vl.Sysmon.Convert starting..");

            Domain.Sysmon config = ParseConfiguration(TestFile);
            if (config == null) 
                goto Failure;

            object[] dnsRules = GetExcludeRulesForDNS(config);
            if (dnsRules == null || dnsRules.Length == 0)
                goto Failure;

            EventDataFilter[] filters = ConvertExcludeRulesForDNS(dnsRules);
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
                    EventDataFilterSerializer.Serialize(fs, filters, ConversionHeaderComment);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failure to serialize rules for DNS to {TestOutputFile}.");
            }

            return false;
        }

        private static EventDataFilter[] ConvertExcludeRulesForDNS(object[] dnsRules)
        {
            try
            {
                Log.Information("Convert exclude rules for DNS..");

                List<EventDataFilter> result = new List<EventDataFilter>();
                foreach (var item in dnsRules)
                {
                    switch (item)
                    {
                        case SysmonEventFilteringRuleGroupDnsQueryImage c:
                            // We cannot convert this rule because we are not able to access the full image path in this sourcetype.
                            break;
                        case SysmonEventFilteringRuleGroupDnsQueryQueryName c:
                            {
                                var filter = c.Convert(ConversionComment);
                                result.Add(filter);

                                Log.Information("Rule <{query}>", filter.Query);
                            }
                            break;
                        default:
                            break;
                    }
                }

                Log.Information("Converted {count} rules.", result.Count);
                return result.ToArray();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failure to convert exclude rules for DNS.");
            }
            
            return null;
        }

        private static object[] GetExcludeRulesForDNS(Domain.Sysmon config)
        {
            try
            {
                Log.Information("Get exclude rules for DNS..");
                return config.GetExcludeRulesForDNS();
            }
            catch (NotImplementedException ex)
            {
                Log.Error(ex, $"A new DNS exclude rule type is present that is not implemented.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failure to get exclude rules for DNS.");
            }

            return null;
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

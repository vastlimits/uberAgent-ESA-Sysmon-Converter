namespace vl.Sysmon.Converter.Domain
{
   class Constants
   {
      public const string ActivityMonitoringOutputFileName = "uberAgent-ESA-am-converted.conf";
      public const string EventDataFilterOutputFileName = "uberAgent-eventdata-filter-converted.conf";

      public const string SysmonExcludeOnMatchString = "exclude";
      public const string SysmonIncludeOnMatchString = "include";
      public const string SysmonOrGroupRelationString = "or";

      public const string RuleNotSupportedTemplate = "Rule currently not supported: {item} - Reason: {reason}";
   }
}

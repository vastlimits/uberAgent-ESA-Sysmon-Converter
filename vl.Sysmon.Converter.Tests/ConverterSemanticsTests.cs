using System.Collections.Generic;
using vl.Core.Domain;
using vl.Core.Domain.Activity;
using vl.Sysmon.Converter.Domain;
using vl.Sysmon.Converter.Domain.Activity;

namespace vl.Sysmon.Converter.Tests;

public class ConverterSemanticsTests
{
   public ConverterSemanticsTests()
   {
      Globals.Options = new Options
      {
         UAVersion = UAVersion.UA_VERSION_CURRENT_RELEASE,
         RiskScore = 50,
         RulesToConvert = []
      };
   }

   [Fact]
   public void MultipleIncludeBlocksAreJoinedWithOr()
   {
      var rule = ConvertProcessCreate(
         ProcessCreate("include",
            Image("cmd.exe"),
            CommandLine("/c", "contains")),
         ProcessCreate("include",
            Image("powershell.exe")));

      Assert.Equal("(Process.Name == \"cmd.exe\" and icontains(Process.CommandLine, \"/c\")) or (Process.Name == \"powershell.exe\")", rule.Query);
   }

   [Fact]
   public void ExcludeBlocksVetoIncludeBlocks()
   {
      var rule = ConvertProcessCreate(
         ProcessCreate("include", Image("cmd.exe")),
         ProcessCreate("exclude", CommandLine("/safe", "contains")));

      Assert.Equal("Process.Name == \"cmd.exe\" and not (icontains(Process.CommandLine, \"/safe\"))", rule.Query);
   }

   [Fact]
   public void DefaultSysmonFieldSemanticsUseSameFieldOrAndCrossFieldAnd()
   {
      var rule = ConvertProcessCreate(
         ProcessCreate("include",
            Image("cmd.exe"),
            Image("powershell.exe"),
            CommandLine("/c", "contains")));

      Assert.Equal("(Process.Name == \"cmd.exe\" or Process.Name == \"powershell.exe\") and icontains(Process.CommandLine, \"/c\")", rule.Query);
   }

   [Fact]
   public void NegativeConditionsOnSameFieldAreJoinedWithAnd()
   {
      var rule = ConvertProcessCreate(
         ProcessCreate("include",
            Image("cmd.exe", "is not"),
            Image("powershell.exe", "is not")));

      Assert.Equal("Process.Name != \"cmd.exe\" and Process.Name != \"powershell.exe\"", rule.Query);
   }

   [Fact]
   public void NestedRuleGroupsKeepExpectedParentheses()
   {
      var rule = ConvertProcessCreate(
         ProcessCreate("include", "or",
            ProcessCreateRule("and",
               CommandLine("control", "contains"),
               CommandLine("/name", "contains")),
            ProcessCreateRule("and",
               CommandLine("rundll32.exe", "contains"),
               CommandLine("shell32.dll", "contains"),
               CommandLine("Control_RunDLL", "contains"))));

      Assert.Equal("(icontains(Process.CommandLine, \"control\") and icontains(Process.CommandLine, \"/name\")) or (icontains(Process.CommandLine, \"rundll32.exe\") and icontains(Process.CommandLine, \"shell32.dll\") and icontains(Process.CommandLine, \"Control_RunDLL\"))", rule.Query);
   }

   [Fact]
   public void OriginalFileNameMapsToProcessName()
   {
      var rule = ConvertProcessCreate(
         ProcessCreate("include",
            OriginalFileName("rundll32.exe")));

      Assert.Equal("Process.Name == \"rundll32.exe\"", rule.Query);
   }

   [Fact]
   public void MissingSysmonConditionsAreSupported()
   {
      var processRule = ConvertProcessCreate(
         ProcessCreate("include",
            CommandLine("C:\\Windows", "not begin with")));
      var networkRule = ConvertNetworkConnect(
         NetworkConnect("include",
            DestinationPort("1024", "more than"),
            SourcePort("65535", "less than")));

      Assert.Equal("istartswith(Process.CommandLine, \"C:\\\\Windows\") == false", processRule.Query);
      Assert.Equal("Net.Target.Port > 1024 and Net.Source.Port < 65535", networkRule.Query);
   }

   [Fact]
   public void ExcludesAnyAndAllFollowSysmonDocumentedSemantics()
   {
      var excludesAny = ConvertProcessCreate(
         ProcessCreate("include",
            CommandLine("foo;bar", "excludes any")));
      var excludesAll = ConvertProcessCreate(
         ProcessCreate("include",
            CommandLine("foo;bar", "excludes all")));

      Assert.Equal("not (icontains(Process.CommandLine, \"foo\") and icontains(Process.CommandLine, \"bar\"))", excludesAny.Query);
      Assert.Equal("not (icontains(Process.CommandLine, \"foo\") or icontains(Process.CommandLine, \"bar\"))", excludesAll.Query);
   }

   [Fact]
   public void ImageConditionUsesNameOrPathByValue()
   {
      var byName = ConvertProcessCreate(ProcessCreate("include", Image("cmd.exe", "image")));
      var byPath = ConvertProcessCreate(ProcessCreate("include", Image(@"C:\Windows\System32\cmd.exe", "image")));

      Assert.Equal("Process.Name == \"cmd.exe\"", byName.Query);
      Assert.Equal("Process.Path == \"C:\\\\Windows\\\\System32\\\\cmd.exe\"", byPath.Query);
   }

   [Theory]
   [InlineData("7.4.0", UAVersion.UA_VERSION_7_4)]
   [InlineData("7.4.x", UAVersion.UA_VERSION_7_4)]
   [InlineData("7.5.x", UAVersion.UA_VERSION_7_5)]
   [InlineData("8.0", UAVersion.UA_VERSION_8_0)]
   public void CurrentUberAgentVersionsAreParsed(string versionString, UAVersion expected)
   {
      Assert.Equal(expected, UAVersionExtensions.ParseVersion(versionString));
   }

   [Fact]
   public void DirectFieldsUnsupportedByTargetVersionAreNotEmitted()
   {
      Globals.Options.UAVersion = UAVersion.UA_VERSION_6_0;

      var rule = ConvertRegistryEvent(EventType.RegKeyCreate,
         RegistryEvent("include",
            TargetObject(@"HKLM\Software\Microsoft\Windows\CurrentVersion\Run", "contains")));

      Assert.True(string.IsNullOrEmpty(rule.Query));
   }

   private static ActivityMonitoringRule ConvertProcessCreate(params SysmonEventFilteringRuleGroupProcessCreate[] rules)
      => SysmonActivityMonitoringRule.Create(new List<SysmonEventFilteringRuleGroupProcessCreate>(rules), "ProcessCreate", EventType.ProcessCreate);

   private static ActivityMonitoringRule ConvertNetworkConnect(params SysmonEventFilteringRuleGroupNetworkConnect[] rules)
      => SysmonActivityMonitoringRule.Create(new List<SysmonEventFilteringRuleGroupNetworkConnect>(rules), "NetworkConnect", EventType.NetConnect);

   private static ActivityMonitoringRule ConvertRegistryEvent(EventType eventType, params SysmonEventFilteringRuleGroupRegistryEvent[] rules)
      => SysmonActivityMonitoringRule.Create(new List<SysmonEventFilteringRuleGroupRegistryEvent>(rules), "RegistryEvent", eventType);

   private static SysmonEventFilteringRuleGroupProcessCreate ProcessCreate(string onMatch, params object[] items)
      => ProcessCreate(onMatch, null, items);

   private static SysmonEventFilteringRuleGroupProcessCreate ProcessCreate(string onMatch, string? groupRelation, params object[] items)
      => new()
      {
         onmatch = onMatch,
         groupRelation = groupRelation,
         Items = items
      };

   private static SysmonEventFilteringRuleGroupNetworkConnect NetworkConnect(string onMatch, params object[] items)
      => new()
      {
         onmatch = onMatch,
         Items = items
      };

   private static SysmonEventFilteringRuleGroupRegistryEvent RegistryEvent(string onMatch, params object[] items)
      => new()
      {
         onmatch = onMatch,
         Items = items
      };

   private static SysmonEventFilteringRuleGroupProcessCreateRule ProcessCreateRule(string groupRelation, params object[] items)
      => new()
      {
         groupRelation = groupRelation,
         Items = items
      };

   private static SysmonEventFilteringRuleGroupProcessCreateImage Image(string value, string condition = "is")
      => new()
      {
         condition = condition,
         Value = value
      };

   private static SysmonEventFilteringRuleGroupProcessCreateCommandLine CommandLine(string value, string condition = "is")
      => new()
      {
         condition = condition,
         Value = value
      };

   private static SysmonEventFilteringRuleGroupProcessCreateOriginalFileName OriginalFileName(string value, string condition = "is")
      => new()
      {
         condition = condition,
         Value = value
      };

   private static SysmonEventFilteringRuleGroupNetworkConnectDestinationPort DestinationPort(string value, string condition = "is")
      => new()
      {
         condition = condition,
         Value = value
      };

   private static SysmonEventFilteringRuleGroupNetworkConnectSourcePort SourcePort(string value, string condition = "is")
      => new()
      {
         condition = condition,
         Value = value
      };

   private static SysmonEventFilteringRuleGroupRegistryEventTargetObject TargetObject(string value, string condition = "is")
      => new()
      {
         condition = condition,
         Value = value
      };
}

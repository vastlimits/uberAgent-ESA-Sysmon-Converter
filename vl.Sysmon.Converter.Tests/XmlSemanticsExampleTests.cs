using System.Text;
using vl.Core.Domain;
using vl.Core.Domain.Activity;
using vl.Sysmon.Converter.Domain;
using vl.Sysmon.Converter.Domain.Activity;
using vl.Sysmon.Converter.Domain.Extensions;

namespace vl.Sysmon.Converter.Tests;

public class XmlSemanticsExampleTests
{
   public XmlSemanticsExampleTests()
   {
      Globals.Options = new Options
      {
         UAVersion = UAVersion.UA_VERSION_CURRENT_RELEASE,
         RiskScore = 50,
         RulesToConvert = []
      };
   }

   [Fact]
   public void Example_DefaultSysmonLogicUsesOrWithinSameFieldAndAndAcrossDifferentFields()
   {
      var query = ConvertProcessCreate("""
         <ProcessCreate onmatch="include">
           <Image condition="is">cmd.exe</Image>
           <Image condition="is">powershell.exe</Image>
           <CommandLine condition="contains">/c</CommandLine>
         </ProcessCreate>
         """);

      Assert.Equal("(Process.Name == \"cmd.exe\" or Process.Name == \"powershell.exe\") and icontains(Process.CommandLine, \"/c\")", query);
   }

   [Fact]
   public void Example_IncludeAndExcludeBlocksPreserveSysmonPrecedence()
   {
      var query = ConvertProcessCreate("""
         <ProcessCreate onmatch="include">
           <Image condition="is">cmd.exe</Image>
         </ProcessCreate>
         <ProcessCreate onmatch="include">
           <Image condition="is">powershell.exe</Image>
         </ProcessCreate>
         <ProcessCreate onmatch="exclude">
           <ParentImage condition="is">explorer.exe</ParentImage>
         </ProcessCreate>
         """);

      Assert.Equal("((Process.Name == \"cmd.exe\") or (Process.Name == \"powershell.exe\")) and not (Parent.Name == \"explorer.exe\")", query);
   }

   [Fact]
   public void Example_RepeatedEventElementsInsideRuleGroupAreAllConverted()
   {
      var query = ConvertProcessCreate("""
         <RuleGroup name="ObfuscatedPowerShell" groupRelation="or">
           <ProcessCreate onmatch="include">
             <CommandLine condition="contains">FromBase64</CommandLine>
           </ProcessCreate>
           <ProcessCreate onmatch="include">
             <CommandLine condition="contains">gzip</CommandLine>
           </ProcessCreate>
           <ProcessCreate onmatch="include">
             <CommandLine condition="contains">decompress</CommandLine>
           </ProcessCreate>
         </RuleGroup>
         """);

      Assert.Equal("(icontains(Process.CommandLine, \"FromBase64\")) or (icontains(Process.CommandLine, \"gzip\")) or (icontains(Process.CommandLine, \"decompress\"))", query);
   }

   [Fact]
   public void Example_NestedRulesCanExpressControlPanelLaunchPatterns()
   {
      var query = ConvertProcessCreate("""
         <RuleGroup name="ControlPanelLaunch" groupRelation="or">
           <ProcessCreate onmatch="include">
             <Rule groupRelation="and">
               <CommandLine condition="contains">control</CommandLine>
               <CommandLine condition="contains">/name</CommandLine>
             </Rule>
             <Rule groupRelation="and">
               <CommandLine condition="contains">rundll32.exe</CommandLine>
               <CommandLine condition="contains">shell32.dll</CommandLine>
               <CommandLine condition="contains">Control_RunDLL</CommandLine>
             </Rule>
           </ProcessCreate>
         </RuleGroup>
         """);

      Assert.Equal("(icontains(Process.CommandLine, \"control\") and icontains(Process.CommandLine, \"/name\")) or (icontains(Process.CommandLine, \"rundll32.exe\") and icontains(Process.CommandLine, \"shell32.dll\") and icontains(Process.CommandLine, \"Control_RunDLL\"))", query);
   }

   [Fact]
   public void Example_RuleGroupAndRequiresAllNestedRulesToMatch()
   {
      var query = ConvertProcessCreate("""
         <RuleGroup name="ShellWithParent" groupRelation="and">
           <ProcessCreate onmatch="include">
             <Rule groupRelation="or">
               <Image condition="is">cmd.exe</Image>
               <Image condition="is">powershell.exe</Image>
             </Rule>
             <Rule groupRelation="and">
               <CommandLine condition="contains">/c</CommandLine>
               <ParentImage condition="is">explorer.exe</ParentImage>
             </Rule>
           </ProcessCreate>
         </RuleGroup>
         """);

      Assert.Equal("(Process.Name == \"cmd.exe\" or Process.Name == \"powershell.exe\") and icontains(Process.CommandLine, \"/c\") and Parent.Name == \"explorer.exe\"", query);
   }

   [Fact]
   public void Example_MultiValueConditionsExpandToExplicitBooleanGroups()
   {
      var query = ConvertProcessCreate("""
         <ProcessCreate onmatch="include">
           <Image condition="is any">cmd.exe;powershell.exe</Image>
           <CommandLine condition="contains all">-EncodedCommand;-NoProfile</CommandLine>
           <ParentImage condition="excludes all">services.exe;wininit.exe</ParentImage>
         </ProcessCreate>
         """);

      Assert.Equal("(Process.Name == \"cmd.exe\" or Process.Name == \"powershell.exe\") and icontains(Process.CommandLine, \"-EncodedCommand\") and icontains(Process.CommandLine, \"-NoProfile\") and not (icontains(Parent.Name, \"services.exe\") or icontains(Parent.Name, \"wininit.exe\"))", query);
   }

   [Fact]
   public void Example_SemicolonIsLiteralForSingleValueConditions()
   {
      var query = ConvertProcessCreate("""
         <ProcessCreate onmatch="include">
           <CommandLine condition="contains">foo;bar</CommandLine>
         </ProcessCreate>
         """);

      Assert.Equal("icontains(Process.CommandLine, \"foo;bar\")", query);
   }

   [Fact]
   public void Example_EmptyConditionValuesAreIgnored()
   {
      var query = ConvertProcessCreate("""
         <ProcessCreate onmatch="include">
           <Image condition="is"></Image>
           <CommandLine condition="contains">FromBase64</CommandLine>
         </ProcessCreate>
         """);

      Assert.Equal("icontains(Process.CommandLine, \"FromBase64\")", query);
   }

   [Fact]
   public void Example_ModularSysmonEventWrappersAreNormalized()
   {
      var config = ParseFullConfig("""
         <Sysmon schemaversion="4.30">
           <FileCreate>
             <RuleGroup name="" groupRelation="or">
               <FileCreate onmatch="include">
                 <Rule groupRelation="and">
                   <Image condition="end with">\WINWORD.EXE</Image>
                   <TargetFilename condition="contains any">.cab;.inf</TargetFilename>
                 </Rule>
               </FileCreate>
             </RuleGroup>
           </FileCreate>
         </Sysmon>
         """);
      var rules = config.GetSysmonRulesFromGroupListed();
      rules = config.GetSysmonRules(rules);

      var query = SysmonActivityMonitoringRule.Create(rules.FileCreate, "FileCreate", EventType.FileCreate).Query;

      Assert.Equal("iendswith(Process.Path, \"\\\\WINWORD.EXE\") and (icontains(File.Path, \".cab\") or icontains(File.Path, \".inf\"))", query);
   }

   private static string ConvertProcessCreate(string eventFilteringContent)
   {
      var config = ParseConfig(eventFilteringContent);
      var rules = config.GetSysmonRulesFromGroupListed();
      rules = config.GetSysmonRules(rules);

      return SysmonActivityMonitoringRule.Create(rules.ProcessCreate, "ProcessCreate", EventType.ProcessCreate).Query;
   }

   private static global::vl.Sysmon.Converter.Domain.Sysmon ParseConfig(string eventFilteringContent)
   {
      var xml = $"""
         <Sysmon schemaversion="4.82">
           <EventFiltering>
             {eventFilteringContent}
           </EventFiltering>
         </Sysmon>
         """;
      using var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
      return SysmonConfigParser.ParseConfiguration(stream);
   }

   private static global::vl.Sysmon.Converter.Domain.Sysmon ParseFullConfig(string xml)
   {
      using var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
      return SysmonConfigParser.ParseConfiguration(stream);
   }
}

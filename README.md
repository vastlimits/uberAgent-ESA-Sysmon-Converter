
# uberAgent-ESA-Sysmon-Converter
> A Sysmon rule converter for uberAgent ESA

## Table of Contents

- [Platforms](#platforms)
- [Getting Started](#gettingstarted)
- [Syntax](#Syntax)
- [Limitations](#limitations)
- [License](#license)
- [Third Party](#third-party)


## Platforms
The uberAgent-ESA-Sysmon-Converter is written in .NET 5 and therefore platform independent. 

## Getting Started
### Download

 1. The latest binary archive can be found [here](https://www.example.com).
 2. After unpacking, the converter can be controlled via the command line.

### Converting
Further information at [Syntax](#syntax)

### After converting
After the converter has run successfully, 2 files are created in the output directory, depending on the rules.

 1. `uberAgent-eventdata-filter-converted.conf`
 2. `uberAgent-ESA-am-converted.conf`

`uberAgent-eventdata-filter-converted.conf` contains excluded DNS queries. 
All other rules are converted to `uberAgent-ESA-am-converted.conf` 

For more information about the setup for uberAgent, see the documentation for [Event Data Filtering](https://uberagent.com/docs/uberagent/latest/uxm-features-configuration/event-data-filtering/) and for [Activity Monitoring Engine](https://uberagent.com/docs/uberagent/latest/esa-features-configuration/activity-monitoring-engine/).


## Syntax

To convert all rules from one or more files, use the following command:

```cmd
vl.Sysmon.Converter --input filePath1 filePath2 --output outputFolder
```
or a shorter notation
```cmd
vl.Sysmon.Converter -i filePath1 -o outputFolder
```
To convert one or more specific Sysmon rules:

```cmd
vl.Sysmon.Converter --input filePath1 filePath2 --output outputFolder --rule 1 2 12
```

## Example
An **ProcessCreate** excerpt from the [Sysmon configuration of SwiftOnSecurity](https://github.com/SwiftOnSecurity/sysmon-config):
```  
<Sysmon schemaversion="4.50">
	<EventFiltering>
        <RuleGroup name="" groupRelation="or">
            <ProcessCreate onmatch="exclude">
                <!--SECTION: Microsoft Windows-->
                <CommandLine condition="is">C:\Windows\System32\RuntimeBroker.exe -Embedding</CommandLine> <!--Windows:Apps permissions [ https://fossbytes.com/runtime-broker-process-windows-10/ ] -->
                <Image condition="is">C:\Program Files (x86)\Common Files\microsoft shared\ink\TabTip32.exe</Image> <!--Windows: Touch Keyboard and Handwriting Panel Helper-->
                <IntegrityLevel condition="is">AppContainer</IntegrityLevel> <!--Windows: Don't care about sandboxed processes right now. Will need to revisit this decision.-->
                <ParentCommandLine condition="begin with">%%SystemRoot%%\system32\csrss.exe ObjectDirectory=\Windows</ParentCommandLine> <!--Windows:CommandShell: Triggered when programs use the command shell, but doesn't provide attribution for what caused it-->
                <ParentCommandLine condition="is">C:\windows\system32\wermgr.exe -queuereporting</ParentCommandLine> <!--Windows:Windows error reporting/telemetry-->
                <ParentImage condition="is">C:\Windows\system32\SearchIndexer.exe</ParentImage> <!--Windows:Search: Launches many uninteresting sub-processes-->
                <!--SECTION: Windows:svchost-->
                <CommandLine condition="is">C:\Windows\system32\svchost.exe -k appmodel -s StateRepository</CommandLine>
                <CommandLine condition="is">C:\Windows\system32\svchost.exe -k wsappx</CommandLine> <!--Windows:Apps [ https://www.howtogeek.com/320261/what-is-wsappx-and-why-is-it-running-on-my-pc/ ] -->
                <ParentCommandLine condition="is">C:\Windows\system32\svchost.exe -k netsvcs</ParentCommandLine> <!--Windows: Network services: Spawns Consent.exe-->
                <ParentCommandLine condition="is">C:\Windows\system32\svchost.exe -k localSystemNetworkRestricted</ParentCommandLine> <!--Windows-->
                <CommandLine condition="is">C:\Windows\system32\deviceenroller.exe /c /AutoEnrollMDM</CommandLine> <!--Windows: AzureAD device enrollment agent-->
                <!--SECTION: Microsoft:Edge-->
                <CommandLine condition="begin with">"C:\Program Files (x86)\Microsoft\Edge Dev\Application\msedge.exe" --type=</CommandLine>
                <!--SECTION: Microsoft:dotNet-->
                <CommandLine condition="begin with">C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen.exe</CommandLine> <!--Microsoft:DotNet-->
                <CommandLine condition="begin with">C:\WINDOWS\Microsoft.NET\Framework64\v4.0.30319\Ngen.exe</CommandLine> <!--Microsoft:DotNet-->
                <Image condition="is">C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorsvw.exe</Image> <!--Microsoft:DotNet-->
                <Image condition="is">C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorsvw.exe</Image> <!--Microsoft:DotNet-->
                <Image condition="is">C:\Windows\Microsoft.Net\Framework64\v3.0\WPF\PresentationFontCache.exe</Image> <!--Windows: Font cache service-->
                <ParentCommandLine condition="contains">C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ngentask.exe</ParentCommandLine>
                <ParentImage condition="is">C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorsvw.exe</ParentImage> <!--Microsoft:DotNet-->
                <ParentImage condition="is">C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ngentask.exe</ParentImage> <!--Microsoft:DotNet-->
                <ParentImage condition="is">C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorsvw.exe</ParentImage> <!--Microsoft:DotNet-->
                <ParentImage condition="is">C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngentask.exe</ParentImage> <!--Microsoft:DotNet: Spawns thousands of ngen.exe processes-->
                <!--SECTION: Microsoft:Office-->
                <Image condition="is">C:\Program Files\Microsoft Office\Office16\MSOSYNC.EXE</Image> <!--Microsoft:Office: Background process for SharePoint/Office365 connectivity-->
                <Image condition="is">C:\Program Files (x86)\Microsoft Office\Office16\MSOSYNC.EXE</Image> <!--Microsoft:Office: Background process for SharePoint/Office365 connectivity-->
                <!--SECTION: Microsoft:Office:Click2Run-->
                <Image condition="is">C:\Program Files\Common Files\Microsoft Shared\ClickToRun\OfficeC2RClient.exe</Image> <!--Microsoft:Office: Background process-->
                <ParentImage condition="is">C:\Program Files\Common Files\Microsoft Shared\ClickToRun\OfficeClickToRun.exe</ParentImage> <!--Microsoft:Office: Background process-->
                <ParentImage condition="is">C:\Program Files\Common Files\Microsoft Shared\ClickToRun\OfficeC2RClient.exe</ParentImage> <!--Microsoft:Office: Background process-->
                <!--SECTION: Windows: Media player-->
                <Image condition="is">C:\Program Files\Windows Media Player\wmpnscfg.exe</Image> <!--Windows: Windows Media Player Network Sharing Service Configuration Application-->
                <!--SECTION: Google-->
                <CommandLine condition="begin with">"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --type=</CommandLine> <!--Google:Chrome: massive command-line arguments-->
                <CommandLine condition="begin with">"C:\Program Files\Google\Chrome\Application\chrome.exe" --type=</CommandLine> <!--Google:Chrome: massive command-line arguments-->
            </ProcessCreate>
        </RuleGroup>
	</EventFiltering>
</Sysmon>
```
After executing the following statement 
--- `vl.Sysmon.Converter -i C:\tmp\example.xml -o C:\tmp\exampleOutput\`
we should find **uberAgent-ESA-am-converted.conf** in our output directory with the following content: 
```  
[ActivityMonitoringRule]
RuleName = A Sysmon converted rule
EventType = Process.Start
Tag = a-Sysmon-converted-rule
RiskScore = 100
Query = not ((Process.CommandLine == r"C:\Windows\System32\RuntimeBroker.exe -Embedding" or Process.Path == r"C:\Program Files (x86)\Common Files\microsoft shared\ink\TabTip32.exe" or istartswith(Parent.CommandLine, r"%SystemRoot%\system32\csrss.exe ObjectDirectory=\Windows") or Parent.CommandLine == r"C:\windows\system32\wermgr.exe -queuereporting" or Parent.Path == r"C:\Windows\system32\SearchIndexer.exe" or Process.CommandLine == r"C:\Windows\system32\svchost.exe -k appmodel -s StateRepository" or Process.CommandLine == r"C:\Windows\system32\svchost.exe -k wsappx" or Parent.CommandLine == r"C:\Windows\system32\svchost.exe -k netsvcs" or Parent.CommandLine == r"C:\Windows\system32\svchost.exe -k localSystemNetworkRestricted" or Process.CommandLine == r"C:\Windows\system32\deviceenroller.exe /c /AutoEnrollMDM" or istartswith(Process.CommandLine, r"\"C:\Program Files (x86)\Microsoft\Edge Dev\Application\msedge.exe\" --type=") or istartswith(Process.CommandLine, r"C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen.exe") or istartswith(Process.CommandLine, r"C:\WINDOWS\Microsoft.NET\Framework64\v4.0.30319\Ngen.exe") or Process.Path == r"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorsvw.exe" or Process.Path == r"C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorsvw.exe" or Process.Path == r"C:\Windows\Microsoft.Net\Framework64\v3.0\WPF\PresentationFontCache.exe" or icontains(Parent.CommandLine, r"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ngentask.exe") or Parent.Path == r"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorsvw.exe" or Parent.Path == r"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ngentask.exe" or Parent.Path == r"C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorsvw.exe" or Parent.Path == r"C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngentask.exe" or Process.Path == r"C:\Program Files\Microsoft Office\Office16\MSOSYNC.EXE" or Process.Path == r"C:\Program Files (x86)\Microsoft Office\Office16\MSOSYNC.EXE" or Process.Path == r"C:\Program Files\Common Files\Microsoft Shared\ClickToRun\OfficeC2RClient.exe" or Parent.Path == r"C:\Program Files\Common Files\Microsoft Shared\ClickToRun\OfficeClickToRun.exe" or Parent.Path == r"C:\Program Files\Common Files\Microsoft Shared\ClickToRun\OfficeC2RClient.exe" or Process.Path == r"C:\Program Files\Windows Media Player\wmpnscfg.exe" or istartswith(Process.CommandLine, r"\"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe\" --type=") or istartswith(Process.CommandLine, r"\"C:\Program Files\Google\Chrome\Application\chrome.exe\" --type=")))
```  


## Limitations
Currently, not all rules can be converted from Sysmon to uberAgent.
The following rule IDs are currently not supported:

- 2: FileCreateTime
- 6: DriverLoad
- 9: RawAccessRead
- 10: ProcessAccess
- 11: FileCreate
- 15: FileCreateStreamHash
- 17: NamedPipeCreated
- 18: NamedPipeConnected
- 19: WMI filter
- 20: WMI consumer
- 21: WMI consumer filter
- 23: FileDelete
- 25: ProcessTampering
- 26: FileDeleteDetected

The following Sysmon rule queries are currently not supported:

- OriginalFileName
- IntegrityLevel
- CurrentDirectory
- UtcTime
- Guid
- LogonId
- Details (Registry)
- Network source details

## License
MIT License

## Third Party
This project uses the following third-party libraries:

- [CommandLineParser](https://github.com/commandlineparser/commandline)
- [Serilog](https://serilog.net/)

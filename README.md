# uberAgent-ESA-Sysmon-Converter
> A Sysmon rule converter for uberAgent ESA

## Table of Contents

- [Platforms](#platforms)
- [Usage](#usage)
- [Limitations](#limitations)
- [License](#license)
- [Third Party](#third-party)


## Platforms
The uberAgent-ESA-Sysmon-Converter is written in .NET 5 and therefore platform independent. 

## Usage

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


## Limitations
Currently, not all rules can be converted from Sysmon to uberAgent.
The following rule IDs are currently not supported:

- 2: FileCreateTime
- 6: DriverLoad
- 8: CreateRemoteThread
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

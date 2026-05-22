[CmdletBinding()]
param(
   [string] $WorkRoot = (Join-Path ([System.IO.Path]::GetTempPath()) "sysmon-converter-corpus"),
   [switch] $SkipClone,
   [switch] $IncludeWazuh,
   [switch] $KeepOutput
)

$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$solution = Join-Path $repoRoot "vl.Sysmon.Converter.sln"
$project = Join-Path $repoRoot "vl.Sysmon.Converter\vl.Sysmon.Converter.csproj"
$corpusRoot = Join-Path $WorkRoot "repos"
$outputRoot = Join-Path $WorkRoot "output"

function Sync-Repo {
   param(
      [string] $Name,
      [string] $Url
   )

   $path = Join-Path $corpusRoot $Name
   if ($SkipClone -and (Test-Path $path)) {
      return $path
   }

   if (Test-Path (Join-Path $path ".git")) {
      git -C $path pull --ff-only --depth 1 | Out-Null
      return $path
   }

   if (Test-Path $path) {
      Remove-Item -Recurse -Force $path
   }

   git clone --depth 1 $Url $path
   return $path
}

function Invoke-Converter {
   param(
      [string] $Name,
      [string[]] $InputFiles,
      [string[]] $Rules = @()
   )

   $caseOutput = Join-Path $outputRoot $Name
   New-Item -ItemType Directory -Force -Path $caseOutput | Out-Null

   $arguments = @("run", "--no-build", "--project", $project, "--", "-i") + $InputFiles + @("-o", $caseOutput, "-v", "8.0")
   if ($Rules.Count -gt 0) {
      $arguments += @("-r") + $Rules
   }

   $log = Join-Path $outputRoot "$Name.log"
   $stdout = & dotnet @arguments 2>&1
   $stdout | Set-Content -Path $log -Encoding UTF8

   if ($LASTEXITCODE -ne 0) {
      throw "Converter failed for $Name. See log: $log"
   }

   $config = Join-Path $caseOutput "uberAgent-ESA-am-converted.conf"
   if (!(Test-Path $config)) {
      throw "Converter did not create output for $Name."
   }

   [pscustomobject]@{
      Name = $Name
      Config = $config
      Content = Get-Content -Raw -Path $config
      RuleCount = (Select-String -Path $config -Pattern "^\[ActivityMonitoringRule\]" -AllMatches).Count
      QueryShape = Assert-OutputQueriesAreWellFormed $config $Name
      Log = $log
   }
}

function Assert-Contains {
   param(
      [string] $Content,
      [string] $Fragment,
      [string] $CaseName
   )

   if (!$Content.Contains($Fragment)) {
      throw "Missing expected fragment for ${CaseName}: $Fragment"
   }
}

function Test-QueryShape {
   param(
      [string] $Query
   )

   $depth = 0
   $maxDepth = 0
   $inString = $false
   $escaped = $false

   for ($i = 0; $i -lt $Query.Length; $i++) {
      $char = $Query[$i]

      if ($inString) {
         if ($escaped) {
            $escaped = $false
            continue
         }

         if ($char -eq "\") {
            $escaped = $true
            continue
         }

         if ($char -eq '"') {
            $inString = $false
         }

         continue
      }

      if ($char -eq '"') {
         $inString = $true
         continue
      }

      if ($char -eq "(") {
         $depth++
         if ($depth -gt $maxDepth) {
            $maxDepth = $depth
         }
         continue
      }

      if ($char -eq ")") {
         $depth--
         if ($depth -lt 0) {
            return [pscustomobject]@{ Ok = $false; Reason = "closing parenthesis before opening"; MaxDepth = $maxDepth }
         }
      }
   }

   if ($inString) {
      return [pscustomobject]@{ Ok = $false; Reason = "unterminated string literal"; MaxDepth = $maxDepth }
   }

   if ($depth -ne 0) {
      return [pscustomobject]@{ Ok = $false; Reason = "unbalanced parentheses depth $depth"; MaxDepth = $maxDepth }
   }

   $withoutStrings = [regex]::Replace($Query, '"(?:\\.|[^"\\])*"', '""')
   $badPatterns = @(
      @{ Pattern = "\(\s*\)"; Reason = "empty parentheses" },
      @{ Pattern = "\b(and|or)\s*(\)|$)"; Reason = "dangling boolean operator" },
      @{ Pattern = "(^|\()\s*(and|or)\b"; Reason = "leading boolean operator" },
      @{ Pattern = "\bnot\s*(\)|$)"; Reason = "dangling not" },
      @{ Pattern = "\b(and|or)\s+\b(and|or)\b"; Reason = "duplicate boolean operator" },
      @{ Pattern = "\bnot\s+not\b"; Reason = "duplicate not" }
   )

   foreach ($badPattern in $badPatterns) {
      if ($withoutStrings -match $badPattern.Pattern) {
         return [pscustomobject]@{ Ok = $false; Reason = $badPattern.Reason; MaxDepth = $maxDepth }
      }
   }

   [pscustomobject]@{ Ok = $true; Reason = "ok"; MaxDepth = $maxDepth }
}

function Assert-OutputQueriesAreWellFormed {
   param(
      [string] $ConfigPath,
      [string] $CaseName
   )

   $queryLines = Select-String -Path $ConfigPath -Pattern "^Query = "
   foreach ($queryLine in $queryLines) {
      $query = $queryLine.Line.Substring(8)
      $shape = Test-QueryShape $query
      if (!$shape.Ok) {
         throw "Malformed query in ${CaseName} at line $($queryLine.LineNumber): $($shape.Reason)"
      }
   }

   [pscustomobject]@{
      QueryCount = $queryLines.Count
      MaxDepth = (($queryLines | ForEach-Object { Test-QueryShape $_.Line.Substring(8) } | Measure-Object -Property MaxDepth -Maximum).Maximum)
   }
}

function Assert-NotContains {
   param(
      [string] $Content,
      [string] $Fragment,
      [string] $CaseName
   )

   if ($Content.Contains($Fragment)) {
      throw "Unexpected fragment for ${CaseName}: $Fragment"
   }
}

New-Item -ItemType Directory -Force -Path $corpusRoot | Out-Null
if (!$KeepOutput -and (Test-Path $outputRoot)) {
   Remove-Item -Recurse -Force $outputRoot
}
New-Item -ItemType Directory -Force -Path $outputRoot | Out-Null

$sysmonModular = Sync-Repo "sysmon-modular" "https://github.com/olafhartong/sysmon-modular.git"
$swiftSysmon = Sync-Repo "sysmon-config" "https://github.com/SwiftOnSecurity/sysmon-config.git"
$wazuhRuleset = $null
if ($IncludeWazuh) {
   $wazuhRuleset = Sync-Repo "wazuh-ruleset" "https://github.com/wazuh/wazuh-ruleset.git"
}

dotnet build $solution --nologo --verbosity:minimal -warnaserror

$cases = @(
   @{
      Name = "olaf-control-panel"
      Input = @(Join-Path $sysmonModular "1_process_creation\include_windows_control_panel.xml")
      Rules = @("1")
      MustContain = @('Query = (icontains(Process.CommandLine, "control") and icontains(Process.CommandLine, "/name")) or (icontains(Process.CommandLine, "rundll32.exe") and icontains(Process.CommandLine, "shell32.dll") and icontains(Process.CommandLine, "Control_RunDLL"))')
   },
   @{
      Name = "olaf-powershell-multi-include"
      Input = @(Join-Path $sysmonModular "1_process_creation\include_suspicious_powershell.xml")
      Rules = @("1")
      MustContain = @(
         'icontains(Process.CommandLine, "FromBase64")',
         'icontains(Process.CommandLine, "gzip")',
         'icontains(Process.CommandLine, "decompress")',
         'icontains(Process.CommandLine, "http")',
         'icontains(Process.CommandLine, "replace")'
      )
   },
   @{
      Name = "olaf-originalfilename-include-all"
      Input = @(Join-Path $sysmonModular "1_process_creation\include_all.xml")
      Rules = @("1")
      MustContain = @('Query = icontains(Process.Name, "\\")')
   },
   @{
      Name = "swift-process-exclude"
      Input = @(Join-Path $swiftSysmon "sysmonconfig-export.xml")
      Rules = @("1")
      MustContain = @(
         'Query = not (',
         'Process.CommandLine == "C:\\Windows\\System32\\RuntimeBroker.exe -Embedding"',
         'Process.Path == "C:\\Program Files (x86)\\Common Files\\microsoft shared\\ink\\TabTip32.exe"'
      )
      MustNotContain = @("IntegrityLevel")
   },
   @{
      Name = "swift-network-include-exclude"
      Input = @(Join-Path $swiftSysmon "sysmonconfig-export.xml")
      Rules = @("3")
      MustContain = @(
         'Process.Name == "powershell.exe"',
         'Net.Target.Port == 3389',
         'and not (',
         'Net.Target.Ip == "127.0.0.1"'
      )
   },
   @{
      Name = "swift-registry-event-types"
      Input = @(Join-Path $swiftSysmon "sysmonconfig-export.xml")
      Rules = @("12", "13", "14")
      MustContain = @(
         'EventType = Reg.Key.Create',
         'EventType = Reg.Key.Delete',
         'EventType = Reg.Value.Write',
         'EventType = Reg.Key.Rename',
         'icontains(Reg.TargetObject, "CurrentVersion\\Run")'
      )
   }
)

$results = foreach ($case in $cases) {
   $result = Invoke-Converter $case.Name $case.Input $case.Rules
   foreach ($fragment in $case.MustContain) {
      Assert-Contains $result.Content $fragment $case.Name
   }

   if ($case.ContainsKey("MustNotContain")) {
      foreach ($fragment in $case.MustNotContain) {
         Assert-NotContains $result.Content $fragment $case.Name
      }
   }

   [pscustomobject]@{
      Case = $case.Name
      Rules = $result.RuleCount
      Queries = $result.QueryShape.QueryCount
      MaxQueryDepth = $result.QueryShape.MaxDepth
      Expectations = "passed"
   }
}

$batchResults = foreach ($dir in Get-ChildItem -Path $sysmonModular -Directory | Sort-Object Name) {
   $files = Get-ChildItem -Path $dir.FullName -File -Filter "*.xml" | Sort-Object Name
   if ($files.Count -eq 0) {
      continue
   }

   $safeName = $dir.Name -replace "[^A-Za-z0-9_.-]", "_"
   $result = Invoke-Converter "batch-$safeName" $files.FullName
   $logContent = Get-Content -Path $result.Log
   $errors = ($logContent | Select-String -Pattern "ERR|FTL|Unhandled|Exception" | Measure-Object).Count
   if ($errors -gt 0) {
      throw "Converter logged errors for sysmon-modular batch $($dir.Name). See log: $($result.Log)"
   }

   [pscustomobject]@{
      Directory = $dir.Name
      Files = $files.Count
      Rules = $result.RuleCount
      Queries = $result.QueryShape.QueryCount
      MaxQueryDepth = $result.QueryShape.MaxDepth
   }
}

$results | Format-Table -AutoSize
$batchResults | Format-Table -AutoSize

if ($IncludeWazuh) {
   $wazuhSysmonConfigs = Get-ChildItem -Path $wazuhRuleset -Recurse -File -Include "*.xml" |
      Where-Object { Select-String -Path $_.FullName -Pattern "<Sysmon\b|<EventFiltering\b" -Quiet }

   Write-Host "Wazuh direct Sysmon config files: $($wazuhSysmonConfigs.Count)"
}

Write-Host "Corpus validation completed successfully. Output root: $outputRoot"

#!/bin/bash
set -e

# Build, signs and notarizes an universal vl.Sysmon.Converter build for macOS.
# This script assumes that the current working directory is the repository root.

# Certificate used for code signing.
# The private key for this certificate must be availabe in your keychain.
CERTIFICATE="Developer ID Application: vast limits GmbH (64N35HHH3F)"

# Team identifier, Apple ID, and app-specific password for upload to notarization server.
TEAM_ID="64N35HHH3F"
APPLE_ID="jan-gerd@vastlimits.com"
PASSWORD="SuperSecretAppSpecificPassword"

if ! command -v jq &> /dev/null
then
    echo "Installing jq"
    brew install jq
fi

for RUNTIME in osx-x64 osx-arm64
do
   echo
   echo "# Building for $RUNTIME"
   dotnet publish -c Release --runtime $RUNTIME --self-contained vl.Sysmon.Converter/vl.Sysmon.Converter.csproj
done

echo
echo "# Creating fat binary"
mkdir -p output_macos
lipo -create vl.Sysmon.Converter/bin/Release/net6.0/{osx-x64,osx-arm64}/publish/vl.Sysmon.Converter -output output_macos/vlSysmonConverter

ls -lh output_macos/vlSysmonConverter
lipo -archs output_macos/vlSysmonConverter

echo
echo "# Signing fat binary"
codesign --timestamp --options=runtime -s "$CERTIFICATE" --entitlements hardened-runtime.plist --force -v output_macos/vlSysmonConverter

echo
echo "# Uploading build for notarization"
rm -f output_macos/vlSysmonConverter.zip
zip -9 -j output_macos/vlSysmonConverter.zip output_macos/vlSysmonConverter

UPLOAD_ID=$(xcrun notarytool submit output_macos/vlSysmonConverter.zip --apple-id "$APPLE_ID" --password "$PASSWORD" --team-id "$TEAM_ID" --output-format json | jq .id | tr -d '"')

echo
echo "# Waiting for response from notarization server"
xcrun notarytool wait $UPLOAD_ID --apple-id "$APPLE_ID" --password "$PASSWORD" --team-id $TEAM_ID
xcrun notarytool log $UPLOAD_ID --apple-id "$APPLE_ID" --password "$PASSWORD" --team-id $TEAM_ID

echo
echo "# Verifiying notarization status of binary"
codesign --test-requirement="=notarized" --verify -v output_macos/vlSysmonConverter 

echo
echo "# Universal signed and notarized build available in output_macos/vlSysmonConverter"
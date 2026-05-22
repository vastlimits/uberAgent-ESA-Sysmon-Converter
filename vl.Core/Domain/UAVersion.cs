using System;
using System.Collections.Generic;

namespace vl.Core.Domain;

public enum UAVersion
{
   UA_VERSION_6_0,
   UA_VERSION_6_1,
   UA_VERSION_6_2,
   UA_VERSION_7_0,
   UA_VERSION_7_1,
   UA_VERSION_7_2,
   UA_VERSION_7_4,
   UA_VERSION_7_5,
   UA_VERSION_8_0,
   UA_VERSION_CURRENT_RELEASE = UA_VERSION_8_0
}

public static class UAVersionExtensions
{
   private static readonly Dictionary<UAVersion, string> VersionStrings = new Dictionary<UAVersion, string>
        {
            { UAVersion.UA_VERSION_6_0, "6.0" },
            { UAVersion.UA_VERSION_6_1, "6.1" },
            { UAVersion.UA_VERSION_6_2, "6.2" },
            { UAVersion.UA_VERSION_7_0, "7.0" },
            { UAVersion.UA_VERSION_7_1, "7.1" },
            { UAVersion.UA_VERSION_7_2, "7.2" },
            { UAVersion.UA_VERSION_7_4, "7.4.x" },
            { UAVersion.UA_VERSION_7_5, "7.5.x" },
            { UAVersion.UA_VERSION_8_0, "8.0" }
        };

   private static readonly Dictionary<string, UAVersion> StringToVersion = new(StringComparer.OrdinalIgnoreCase)
   {
      { "6.0", UAVersion.UA_VERSION_6_0 },
      { "6.1", UAVersion.UA_VERSION_6_1 },
      { "6.2", UAVersion.UA_VERSION_6_2 },
      { "7.0", UAVersion.UA_VERSION_7_0 },
      { "7.1", UAVersion.UA_VERSION_7_1 },
      { "7.2", UAVersion.UA_VERSION_7_2 },
      { "7.4", UAVersion.UA_VERSION_7_4 },
      { "7.4.0", UAVersion.UA_VERSION_7_4 },
      { "7.4.x", UAVersion.UA_VERSION_7_4 },
      { "7.5", UAVersion.UA_VERSION_7_5 },
      { "7.5.x", UAVersion.UA_VERSION_7_5 },
      { "8", UAVersion.UA_VERSION_8_0 },
      { "8.0", UAVersion.UA_VERSION_8_0 },
   };

   public static string ToVersionString(this UAVersion version)
   {
      return VersionStrings.TryGetValue(version, out var versionString)
          ? versionString
          : throw new ArgumentOutOfRangeException(nameof(version), version, null);
   }

   public static UAVersion ParseVersion(string value)
   {
      return TryParseVersion(value, out var version)
         ? version
         : UAVersion.UA_VERSION_CURRENT_RELEASE;
   }

   public static bool TryParseVersion(string value, out UAVersion version)
   {
      if (string.IsNullOrWhiteSpace(value))
      {
         version = UAVersion.UA_VERSION_CURRENT_RELEASE;
         return true;
      }

      return StringToVersion.TryGetValue(value.Trim(), out version);
   }
}
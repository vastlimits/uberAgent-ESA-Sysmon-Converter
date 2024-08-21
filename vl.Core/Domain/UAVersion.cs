using System;
using System.Collections.Generic;
using System.Linq;

namespace vl.Core.Domain;

public enum UAVersion
{
   UA_VERSION_6_0,
   UA_VERSION_6_1,
   UA_VERSION_6_2,
   UA_VERSION_7_0,
   UA_VERSION_7_1,
   UA_VERSION_7_2,
   UA_VERSION_CURRENT_RELEASE = UA_VERSION_7_2
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
            { UAVersion.UA_VERSION_7_2, "7.2" }
        };

   private static readonly Dictionary<string, UAVersion> StringToVersion = VersionStrings
       .ToDictionary(pair => pair.Value, pair => pair.Key);

   public static string ToVersionString(this UAVersion version)
   {
      return VersionStrings.TryGetValue(version, out var versionString)
          ? versionString
          : throw new ArgumentOutOfRangeException(nameof(version), version, null);
   }

   public static UAVersion ParseVersion(string value)
   {
      if (string.IsNullOrEmpty(value))
      {
         return UAVersion.UA_VERSION_CURRENT_RELEASE;
      }

      return StringToVersion.TryGetValue(value, out var version)
          ? version
          : UAVersion.UA_VERSION_CURRENT_RELEASE;
   }
}
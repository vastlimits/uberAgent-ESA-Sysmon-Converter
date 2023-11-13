namespace vl.Core.Domain.Activity;

public static class Versioning
{

   public static bool IsSupportedByCurrentVersion(UAVersion version, EventType eventType)
   {
      switch (eventType)
      {
         case EventType.ProcessCreate:
         case EventType.ProcessTerminate:
         case EventType.ImageLoad:
         case EventType.RegAny:
         case EventType.RegKeyCreate:
         case EventType.RegKeyDelete:
         case EventType.RegValueWrite:
         case EventType.RegKeyRename:
            return version >= UAVersion.UA_VERSION_6_0;
         case EventType.DnsQuery:
            return version >= UAVersion.UA_VERSION_6_1;
         case EventType.CreateRemoteThread:
         case EventType.ProcessTampering:
         case EventType.NetConnect:
            return version >= UAVersion.UA_VERSION_6_2;

         case EventType.FileCreate:
         case EventType.FileDelete:
         case EventType.FileRename:
         case EventType.FileWrite:
         case EventType.FileRead:
         case EventType.FileCreateTime:
         case EventType.FileCreateStreamHash:
         case EventType.DriverLoad:
         case EventType.FilePipeConnected:
         case EventType.FilePipeCreate:
         case EventType.RawAccessRead:
            return version >= UAVersion.UA_VERSION_7_1;
      }

      return false;
   }


}
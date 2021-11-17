namespace vl.Core.Domain.Activity
{
   public enum SysmonEventId
   {
      ProcessCreate = 1,
      FileCreateTime = 2,
      NetworkConnect = 3,
      ProcessTerminate = 5,
      DriverLoad = 6,
      ImageLoad = 7,
      CreateRemoteThread = 8,
      RawAccessRead = 9,
      ProcessAccess = 10,
      FileCreate = 11,
      RegistryEvent = 12,
      FileCreateStreamHash = 15,
      PipeEvent = 17,
      WmiEvent = 19,
      DNSQuery = 22,
      FileDelete = 23,
      ClipboardChange = 24,
      ProcessTampering = 25,
      FileDeleteDetected =26
   }
}
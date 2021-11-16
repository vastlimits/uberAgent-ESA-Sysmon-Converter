namespace vl.Core.Domain.Activity
{
   public enum SysmonEventId
   {
      ProcessCreate = 1,
      FileCreateTime,
      NetworkConnect,
      ProcessTerminate = 5,
      DriverLoad,
      ImageLoad,
      CreateRemoteThread,
      RawAccessRead,
      ProcessAccess,
      FileCreate,
      RegistryEvent,
      FileCreateStreamHash = 15,
      PipeEvent = 17,
      WmiEvent = 19,
      DNSQuery = 22,
      FileDelete,
      ClipboardChange,
      ProcessTampering, 
      FileDeleteDetected
   }
}
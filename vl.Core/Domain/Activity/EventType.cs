﻿namespace vl.Core.Domain.Activity
{
   public enum EventType
   {
      Unknown,
      ProcessCreate,
      ProcessTerminate,
      ImageLoad, 
      NetConnect,
      NetReceive,
      NetReconnect,
      NetRetransmit,
      NetSend,
      RegKeyCreate,
      RegValueWrite,
      RegDelete,
      RegKeyDelete,
      RegValueDelete,
      RegKeySecurityChange,
      RegKeyRename,
      RegKeySetInformation,
      RegKeyLoad,
      RegKeyUnload,
      RegKeyRestore,
      RegKeySave,
      RegKeyReplace,
      RegAny,
      DnsQuery,
      CreateRemoteThread,
      ProcessTampering,
      DriverLoad,
      FileCreateTime,
      RawAccessRead,
      FileCreate,
      FileCreateStreamHash,
      FilePipeCreate,
      FilePipeConnected,
      FileDelete,
      FileRename,
      FileWrite,
      FileRead,
   }
}

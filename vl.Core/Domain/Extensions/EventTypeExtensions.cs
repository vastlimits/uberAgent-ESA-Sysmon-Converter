using System;
using vl.Core.Domain.Activity;

namespace vl.Core.Domain.Extensions
{
   public static class EventTypeExtensions
   {
      public static string ToActivityEventName(this EventType eventType)
      {
         return eventType switch
         {
            EventType.Unknown => string.Empty,
            EventType.ProcessStart => "Process.Start",
            EventType.ProcessStop => "Process.Stop",
            EventType.ImageLoad => "Image.Load",
            EventType.NetConnect => "Net.Connect",
            EventType.NetReceive => "Net.Receive",
            EventType.NetReconnect => "Net.Reconnect",
            EventType.NetRetransmit => "Net.Retransmit",
            EventType.NetSend => "Net.Send",
            EventType.RegKeyCreate => "Reg.Key.Create",
            EventType.RegValueWrite => "Reg.Value.Write",
            EventType.RegDelete => "Reg.Delete",
            EventType.RegKeyDelete => "Reg.Key.Delete",
            EventType.RegValueDelete => "Reg.Value.Delete",
            EventType.RegKeySecurityChange => "Reg.Key.SecurityChange",
            EventType.RegKeyRename => "Reg.Key.Rename",
            EventType.RegKeySetInformation => "Reg.Key.SetInformation",
            EventType.RegKeyLoad => "Reg.Key.Load",
            EventType.RegKeyUnload => "Reg.Key.Unload",
            EventType.RegKeyRestore => "Reg.Key.Restore",
            EventType.RegKeySave => "Reg.Key.Save",
            EventType.RegKeyReplace => "Reg.Key.Replace",
            EventType.RegAny => "Reg.Any",
            EventType.DnsQuery => "DNS.Event",
            EventType.ProcessCreateRemoteThread => "Process.CreateRemoteThread",
            EventType.ProcessTamperingEvent => "Process.TamperingEvent",
            EventType.DriverLoad => "Driver.Load",
            EventType.FileChangeCreationTime => "File.ChangeCreationTime",
            EventType.FileCreate => "File.Create",
            EventType.FileCreateStream => "File.CreateStream",
            EventType.FileDelete => "File.Delete",
            EventType.FilePipeCreate => "File.PipeCreate",
            EventType.FilePipeConnected => "File.PipeConnected",
            EventType.FileRawAccessRead => "File.RawAccessRead",
            EventType.FileRename => "File.Rename",
            EventType.FileWrite => "File.Write",
            EventType.FileRead => "File.Read",
            _ => throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null)
         };
      }
   }
}

﻿using System;
using vl.Core.Domain.ActivityMonitoring;

namespace vl.Sysmon.Convert.Domain.Extensions
{
   public static class EventTypeExtensions
   {
      public static string ToActivityMonitoringString(this EventType eventType)
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
            _ => throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null)
         };
      }
   }
}
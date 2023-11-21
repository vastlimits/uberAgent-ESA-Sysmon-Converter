﻿using System.IO;
using System.Xml.Serialization;

namespace vl.Sysmon.Converter.Domain;

public static class SysmonConfigParser
{
   public static Sysmon ParseConfiguration(string filePath)
   {
      using (var fs = new FileStream(filePath, FileMode.Open))
      {
         return ParseConfiguration(fs);
      }
   }

   public static Sysmon ParseConfiguration(Stream stream)
   {
      var serializer = new XmlSerializer(typeof(Sysmon));
      return (Sysmon)serializer.Deserialize(stream);
   }
}
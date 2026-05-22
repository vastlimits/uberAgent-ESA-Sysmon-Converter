using System.IO;
using System.Linq;
using System.Xml.Linq;
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
      var document = XDocument.Load(stream, LoadOptions.PreserveWhitespace);
      NormalizeModularSysmonConfig(document);

      var serializer = new XmlSerializer(typeof(Sysmon));
      using var reader = document.CreateReader();
      return (Sysmon)serializer.Deserialize(reader);
   }

   private static void NormalizeModularSysmonConfig(XDocument document)
   {
      var root = document.Root;
      if (root == null || root.Element("EventFiltering") != null)
         return;

      var moduleRuleGroups = root.Elements()
         .Where(element => element.Elements("RuleGroup").Any())
         .SelectMany(element => element.Elements("RuleGroup"))
         .Select(element => new XElement(element))
         .ToArray();

      if (moduleRuleGroups.Length == 0)
         return;

      root.Add(new XElement("EventFiltering", moduleRuleGroups));
   }
}
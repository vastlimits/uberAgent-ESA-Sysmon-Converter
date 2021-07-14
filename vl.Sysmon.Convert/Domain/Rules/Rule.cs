using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using vl.Core.Domain.ActivityMonitoring;
using vl.Core.Domain.EventData;
using vl.Sysmon.Convert.Domain.Extensions;
using vl.Sysmon.Convert.Domain.Helpers;

namespace vl.Sysmon.Convert.Domain.Rules
{
   public class Rule
   {
      protected static readonly ILogger Log = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();

      private static string ConvertQuery(string field, string condition, string value)
      {
         return condition switch
         {
            "is" => $"{field} == r\"{value}\"",
            "begin with" => $"istartswith({field}, r\"{value}\")",
            "end with" => $"iendswith({field}, r\"{value}\")",
            "contains" => $"icontains({field}, r\"{value}\")",
            "image" => $"icontains({field}, r\"{value}\")",
            _ => throw new NotImplementedException()
         };
      }

      private static string ConvertQuery(IReadOnlyList<SysmonCondition> conditions)
      {
         if (conditions == null || conditions.Count == 0)
            return string.Empty;

         var queryBuilder = new StringBuilder("Query = ");
         var exclude = conditions[0].OnMatch.Equals(Constants.SysmonExcludeOnMatchString);
         
         if (exclude)
            queryBuilder.Append("not (");

         for (var i = 0; i < conditions.Count; i++)
         {
            var item = conditions[i];
            var groupRelation = i + 1 < conditions.Count ? $" {item.GroupRelation} " : string.Empty;

            item.Value = item.Value.Replace("%%", "%");

            switch (item.Condition)
            {
               case "is":
                  queryBuilder.Append($"{item.Field} == r\"{item.Value}\"{groupRelation}");
                  break;
               case "begin with":
                  queryBuilder.Append($"istartswith({item.Field}, r\"{item.Value}\"){groupRelation}");
                  break;
               case "end with":
                  queryBuilder.Append($"iendswith({item.Field}, r\"{item.Value}\"){groupRelation}");
                  break;
               case "image":
               case "contains":
                  queryBuilder.Append($"icontains({item.Field}, r\"{item.Value}\"){groupRelation}");
                  break;
               default:
                  throw new NotImplementedException();
            }
         }

         if (exclude)
            queryBuilder.Append(")");

         return queryBuilder.ToString();
      }

      protected static ActivityMonitoringRule Convert(ActivityMonitoringConverterSettings settings)
      {
         return new()
         {
            EventType = settings.EventType,
            RuleName = settings.Name,
            Tag = settings.Name,
            Query = ConvertQuery(settings.Conditions),
         };
      }

      protected static EventDataFilter Convert(EventFilterConverterSettings settings)
      {
         return new()
         {
            Action = settings.Action,
            Fields = new List<string>(),
            Sourcetypes = settings.Sourcetypes,
            Query = ConvertQuery(settings.Field, settings.Condition, settings.Value),
            Comment = settings.Comment
         };
      }
   }
}

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

      private static string ConvertQuery(IReadOnlyList<SysmonCondition> conditions, string mainGroupRelation)
      {
         if (conditions == null || conditions.Count == 0)
            return string.Empty;

         var queryBuilder = new StringBuilder("Query = ");
         var exclude = conditions[0].OnMatch.Equals(Constants.SysmonExcludeOnMatchString);
         
         if (exclude)
            queryBuilder.Append("not ");

         var conditionsGrouped = conditions.GroupBy(c => c.RuleId).ToDictionary(c => c.Key, c=> c.ToList());

         for (var groupIndex = 0; groupIndex < conditionsGrouped.Count; groupIndex++)
         {
            var (_, value) = conditionsGrouped.ElementAt(groupIndex);
            var lastGroup = groupIndex + 1 == conditionsGrouped.Count;

            for (var i = 0; i < value.Count; i++)
            {
               var item = value[i];
               var lastValueInGroup = i + 1 == value.Count;
               var groupRelation = lastValueInGroup ? string.Empty : $" {item.GroupRelation} ";
               var query = string.Empty;
               item.Value = item.Value.Replace("%%", "%");

               switch (item.Condition)
               {
                  case "is":
                     query = $"{item.Field} == r\"{item.Value}\"{groupRelation}";
                     break;
                  case "begin with":
                     query = $"istartswith({item.Field}, r\"{item.Value}\"){groupRelation}";
                     break;
                  case "end with":
                     query = $"iendswith({item.Field}, r\"{item.Value}\"){groupRelation}";
                     break;
                  case "image":
                  case "contains":
                     query = $"icontains({item.Field}, r\"{item.Value}\"){groupRelation}";
                     break;
                  case "is not":
                     query = $"{item.Field} != r\"{item.Value}\"{groupRelation}";
                     break;
                  default:
                     Log.Error("Condition: {condition} is not implemented.", item.Condition);
                     throw new NotImplementedException();
               }

               if (string.IsNullOrEmpty(query))
                  continue;

               queryBuilder.Append(i == 0 ? $"({query}" : lastValueInGroup && !lastGroup ? $"{query}) {mainGroupRelation} " : lastValueInGroup && lastGroup ? $"{query})" : $"{query}");
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
            Query = ConvertQuery(settings.Conditions, settings.MainGroupRelation),
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

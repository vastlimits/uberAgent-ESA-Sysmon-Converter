using System;
using System.Collections.Generic;
using System.Linq;

namespace vl.Sysmon.Converter.Domain;

internal enum UaqRelation
{
   And,
   Or
}

internal abstract class UaqExpression
{
   public abstract string ToQuery(bool isRoot = true, UaqRelation? parentRelation = null);
}

internal sealed class UaqPredicateExpression : UaqExpression
{
   private readonly string _query;

   public UaqPredicateExpression(string query)
   {
      _query = query;
   }

   public override string ToQuery(bool isRoot = true, UaqRelation? parentRelation = null) => _query;
}

internal sealed class UaqNotExpression : UaqExpression
{
   private readonly UaqExpression _expression;

   public UaqNotExpression(UaqExpression expression)
   {
      _expression = expression;
   }

   public override string ToQuery(bool isRoot = true, UaqRelation? parentRelation = null)
      => $"not ({_expression.ToQuery()})";
}

internal sealed class UaqBinaryExpression : UaqExpression
{
   private readonly UaqRelation _relation;
   private readonly IReadOnlyList<UaqExpression> _terms;

   public UaqBinaryExpression(UaqRelation relation, IEnumerable<UaqExpression> terms)
   {
      _relation = relation;
      _terms = terms.Where(term => term != null).ToArray();
   }

   public override string ToQuery(bool isRoot = true, UaqRelation? parentRelation = null)
   {
      if (_terms.Count == 0)
         return string.Empty;

      if (_terms.Count == 1)
         return _terms[0].ToQuery(isRoot, parentRelation);

      var separator = _relation == UaqRelation.And ? " and " : " or ";
      var query = string.Join(separator, _terms.Select(term => term.ToQuery(false, _relation)));

      if (!isRoot && parentRelation.HasValue && parentRelation.Value != _relation)
         return $"({query})";

      return query;
   }
}

internal static class UaqExpressionFactory
{
   public static UaqExpression Combine(UaqRelation relation, IEnumerable<UaqExpression> terms)
   {
      var filtered = terms.Where(term => term != null).ToArray();
      if (filtered.Length == 0)
         return null;

      return filtered.Length == 1
         ? filtered[0]
         : new UaqBinaryExpression(relation, filtered);
   }

   public static UaqRelation? ParseRelation(string relation)
   {
      if (string.IsNullOrWhiteSpace(relation))
         return null;

      return relation.Trim().ToLowerInvariant() switch
      {
         "and" => UaqRelation.And,
         "or" => UaqRelation.Or,
         _ => throw new ArgumentOutOfRangeException(nameof(relation), relation, "Unsupported Sysmon group relation.")
      };
   }
}

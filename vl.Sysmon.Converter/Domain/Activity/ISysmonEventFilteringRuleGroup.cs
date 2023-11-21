namespace vl.Sysmon.Converter.Domain.Activity;

public interface ISysmonEventFilteringRuleGroup
{
   string name { get; set; }
   object[] Items { get; }
   string onmatch { get; }
   string groupRelation { get; set; }
}
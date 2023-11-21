namespace vl.Sysmon.Converter.Domain;

public class SysmonCondition : SysmonConditionBase
{
   public int RuleId { get; set; }
   public string GroupRelation { get; set; }
   public string OnMatch { get; set; }
}
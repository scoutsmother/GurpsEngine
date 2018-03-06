using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Services.Rolling;

namespace EvolutionSimulator.Models.Rules.RuleTypes
{
  public enum MoveType
  {
    In,
    Out,
    Teleport
  }

  public class MovementRule : GenericRule
  {
    public MoveType Type { get; }

    public MovementRule(Direction ruleDirection, MoveType type, double diff) 
      : base(ruleDirection, diff)
    {
      Type = type;
    }

    public override bool TrySatisfy(IRollable roll)
    {
      return base.TrySatisfy(roll);
    }
  }
}

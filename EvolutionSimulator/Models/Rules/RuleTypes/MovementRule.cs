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

  public class MovementRule : IRuleRequirement
  {
    public Direction RuleDirection { get; }
    public double Diff { get; }
    public MoveType Type { get; }

    public MovementRule(Direction ruleDirection, MoveType type, double diff)
    {
      RuleDirection = ruleDirection;
      Diff = diff;
      Type = type;
    }

    public bool TrySatisfy(IRollable roll)
    {
      return roll.Roll();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Services.Rolling;

namespace EvolutionSimulator.Models.Rules.RuleTypes
{
  public class GenericRule : IRuleRequirement
  {
    public Direction RuleDirection { get; }

    public double Diff { get; }

    protected GenericRule(Direction d, double diff)
    {
      RuleDirection = d;
      Diff = diff;
    }

    public virtual bool TrySatisfy(IRollable roll)
    {
      return roll.Roll(Diff).margin >= 0;
    }
  }
}

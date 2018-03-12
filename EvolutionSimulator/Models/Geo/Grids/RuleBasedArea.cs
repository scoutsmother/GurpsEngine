using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Actions;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Rules;
using EvolutionSimulator.Models.Rules.RuleTypes;
using EvolutionSimulator.Services.Rolling;
using EvolutionSimulator.Utilities.DeepCopy;

namespace EvolutionSimulator.Models.Geo.Grids
{
  public class RuleBasedArea : GridArea
  {
    public Dictionary<Point, HashSet<IRuleRequirement>> RulesForPoints { get; }

    public RuleBasedArea(int width, int height) : base(width, height)
    {
      RulesForPoints = EntitiesFromPoint.ToDictionary(
        pair => pair.Key, 
        _ => new HashSet<IRuleRequirement>());
    }

    public HashSet<IEntity> At(Point p, IRollable roll)
    {
      var applicableRules = from rule in RulesForPoints[p]
                            where rule is DirectObservationRule
                            select rule as DirectObservationRule;

      var objectiveSet = base.At(p);

      foreach (var rule in applicableRules)
      {
        if (!rule.TrySatisfy(roll))
        {
          objectiveSet.Remove(rule.Subject);
        }
      }

      return base.At(p);
    }

    public void Move(IEntity e, Direction d, IRollable roll)
    {
      var p = base.Where(e);

      var applicableFrom = 
        from ruleFrom in RulesForPoints[p]
        where (ruleFrom as MovementRule)?.Type == MoveType.Out &&
              ((MovementRule)ruleFrom).RuleDirection == d
        select ruleFrom;

      var applicableTo =
        from ruleTo in RulesForPoints[p + d]
        where (ruleTo as MovementRule)?.Type == MoveType.In &&
              ((MovementRule)ruleTo).RuleDirection == d
        select ruleTo;

      var applicableRules = applicableTo.Concat(applicableFrom);
      if (applicableRules.ToList().TrueForAll(x => x.TrySatisfy(roll)))
      {
        base.Move(e, d);
      }
    }

    public override GridArea DeepCopy()
    {
      // Deep copy the base class.
      var newRea = (RuleBasedArea) base.DeepCopy();

      // Copy everything introduced by this class.

      return newRea;
    }

    public override GridArea CreateInstanceForBase()
    {
      return new RuleBasedArea(Width, Height);
    }
  }
}

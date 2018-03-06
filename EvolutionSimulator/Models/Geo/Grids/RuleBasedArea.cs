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
    protected Dictionary<Point, HashSet<IRuleRequirement>> RulesForPoints; 

    public RuleBasedArea(int width, int height) : base(width, height)
    {
      RulesForPoints = EntitiesFromPoint.ToDictionary(
        pair => pair.Key, 
        _ => new HashSet<IRuleRequirement>());
    }

    public HashSet<IEntity> At(Point p, IRollable roll)
    {
      var applicableRules = from rule in RulesForPoints[p].ToList()
                            where rule is ObservationRule
                            select rule as ObservationRule;

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

    public Point Where(IEntity e, IRollable roll)
    {
      return base.Where(e);
    }

    public void Move(IEntity e, Direction d, IRollable roll)
    {
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

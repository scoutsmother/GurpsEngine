using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Rules;
using EvolutionSimulator.Services.Rolling;
using EvolutionSimulator.Utilities.DeepCopy;

namespace EvolutionSimulator.Models.Geo.Grids
{
  public class RuleEnforcedArea : GridArea
  {
    public Dictionary<Point, HashSet<IRuleRequirement>> PointsToRuleSet;

    public RuleEnforcedArea(int width, int height) : base(width, height)
    {
      PointsToRuleSet = new Dictionary<Point, HashSet<IRuleRequirement>>();
      foreach (var p in Points)
      {
        PointsToRuleSet[p] = new HashSet<IRuleRequirement>();
      }
    }

    public HashSet<IEntity> At(Point p, IRollable roll)
    {
      return base.At(p);
    }

    public Point Where(IEntity e, IRollable roll)
    {
      return base.Where(e);
    }

    public void Move(IEntity e, Direction d, IRollable roll)
    {
      var eLoc = Where(e);
      var pointToMoveTo = eLoc + d;
      var prevRuleset = PointsToRuleSet[eLoc];
      var nextRuleset = PointsToRuleSet[pointToMoveTo];

      if (prevRuleset.TryLeave(d, roll) && nextRuleset.TryEnter(d, roll))
      {
        base.Move(e, d);
      }
    }

    public override GridArea DeepCopy()
    {
      var newRea = (RuleEnforcedArea) base.DeepCopy();
      newRea.PointsToRuleSet = PointsToRuleSet.ToDictionary(
        pair => pair.Key, pair => pair.Value.Copy());
      return newRea;
    }

    public override GridArea CreateInstanceForBase()
    {
      return new RuleEnforcedArea(Width, Height);
    }
  }
}

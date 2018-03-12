using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Rules.RuleTypes;
using EvolutionSimulator.Models.State;

namespace EvolutionSimulator.Models.Actions.ActionTypes
{
  public abstract class TargetedAction : EntityAction
  {
    protected IEntity Target;
    private int _requiredDistance;

    protected TargetedAction(IEntity src, IEntity targ, int requiredDistance) : base(src)
    {
      Target = targ;
      _requiredDistance = requiredDistance;
    }

    public override void ResolveAction(IGameState gs)
    {
      var srcPt = gs.Grid.Where(Source);
      var targPt = gs.Grid.Where(Target);
      var distance = srcPt.ManhattanDistance(targPt);
    }
  }
}

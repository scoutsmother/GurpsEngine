using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.State;

namespace EvolutionSimulator.Models.Actions.ActionTypes
{
  public interface ITarget<TTargetType>
  {

  }

  public class TargetedAction<TTargetType> : EntityAction
  {
    private ITarget<TTargetType> Target;

    public TargetedAction(IEntity e) : base(e)
    {

    }

    public override void ResolveAction(IGameState gs)
    {
      base.ResolveAction(gs);
    }
  }
}

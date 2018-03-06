using System;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.State;

namespace EvolutionSimulator.Models.Actions.ActionTypes
{
  public abstract class EntityAction : IEntityAction
  {
    public IEntity Source { get; }

    protected EntityAction(IEntity src)
    {
      Source = src;
    }

    public virtual void ResolveAction(IGameState gs)
    {
      throw new NotImplementedException();
    }
  }
}

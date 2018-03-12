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

    public abstract void ResolveAction(IGameState gs);
  }
}

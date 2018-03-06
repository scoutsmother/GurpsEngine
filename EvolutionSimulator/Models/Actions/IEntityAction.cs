using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.State;

namespace EvolutionSimulator.Models.Actions
{
  public interface IEntityAction
  {
    void ResolveAction(IGameState gs);
  }
}

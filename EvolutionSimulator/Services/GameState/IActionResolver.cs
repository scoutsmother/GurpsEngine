using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Actions;
using EvolutionSimulator.Models.GameState;

namespace EvolutionSimulator.Services.GameState
{
  public interface IActionResolver
  {
    IGameState Resolve(IEntityAction action);
  }
}

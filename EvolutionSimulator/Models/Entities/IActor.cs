using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Actions;
using EvolutionSimulator.Models.State;
using EvolutionSimulator.Models.Stats;

namespace EvolutionSimulator.Models.Entities
{
  public interface IActor: IEntity
  {
    IEntityAction SelectAction(IGameState gs);
  }
}

using EvolutionSimulator.Models.Geo.Grids;

namespace EvolutionSimulator.Models.State
{
  public interface IGameState
  {
    IGrid Grid { get; }
  }
}

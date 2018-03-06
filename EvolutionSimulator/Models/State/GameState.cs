using EvolutionSimulator.Models.Geo.Grids;

namespace EvolutionSimulator.Models.State
{
  public class GameState : IGameState
  {
    public IGrid Grid { get; }

    public GameState(IGrid grid)
    {
      Grid = grid;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Grids;

namespace EvolutionSimulator.Models.Geo.Managers
{
  public class GridAreaManager
  {
    private IGrid _area;

    public GridAreaManager(IGrid area)
    {
      _area = area;
    }
  }
}

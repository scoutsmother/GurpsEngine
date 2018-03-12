using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Utilities.DeepCopy;

namespace EvolutionSimulator.Models.Geo.Grids
{
  public class SubjectiveGridArea : RuleBasedArea
  {
    public SubjectiveGridArea(RuleBasedArea rba) : base(rba.Width, rba.Height)
    {
    }

    public SubjectiveGridArea(int width, int height) : base(width, height)
    {
    }
  }
}

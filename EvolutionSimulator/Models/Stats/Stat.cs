using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Services.Rolling;
using EvolutionSimulator.Services.Rolling.RollTypes;

namespace EvolutionSimulator.Models.Stats
{
  public class Stat : BasicRoll
  {
    public Stat(double value) : base(value, 0.0)
    {
    }

    public static Stat operator + (Stat s1, Stat s2)
    {
      return new Stat(s1.Value + s2.Value);
    }
  }
}

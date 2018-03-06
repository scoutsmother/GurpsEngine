using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Services.Rolling;
using EvolutionSimulator.Services.Rolling.RollTypes;

namespace EvolutionSimulator.Models.Stats
{
  public class Stat
  {
    public double Value { get; }
    public Stat(double value)
    {
      Value = value;
    }

    public static Stat operator + (Stat s1, Stat s2)
    {
      return new Stat(s1.Value + s2.Value);
    }
  }
}

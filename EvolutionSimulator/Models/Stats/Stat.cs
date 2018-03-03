using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Services.Rolling;

namespace EvolutionSimulator.Models.Stats
{
  public class Stat : IRollable
  {
    public double Value { get; private set; }

    public Stat(double value)
    {
      Value = value;
    }

    public static Stat operator + (Stat s1, Stat s2)
    {
      return new Stat(s1.Value + s2.Value);
    }

    public (RollResult result, double margin) BasicRollMargin(double modifiers)
    {
      Random r = new Random();
      int rolledValue = r.Next(1, 6) + r.Next(1, 6) + r.Next(1, 6);

      var margin = (Value + modifiers) - rolledValue;

      if (rolledValue >= 18)
        return (RollResult.CriticalFailure, margin);
      else if (rolledValue <= 3)
        return (RollResult.CriticalFailure, margin);
      else if (margin >= 0)
        return (RollResult.Success, margin);
      else
        return (RollResult.Faliure, margin);
    }
  }
}

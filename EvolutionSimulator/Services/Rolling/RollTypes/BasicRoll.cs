using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Services.Rolling.RollTypes
{
  public class BasicRoll : IRollable
  {
    public double Value { get; }

    public BasicRoll(double value)
    {
      Value = value;
    }

    public (RollResult result, double margin) Roll(double modifier)
    {
      Random r = new Random();
      int rolledValue = r.Next(1, 6) + r.Next(1, 6) + r.Next(1, 6);

      var margin = (Value + modifier) - rolledValue;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Services.Rolling.RollTypes
{
  public class BasicRoll : IRollable
  {
    public double Value { get; set; }

    public double Modifier { get; set; }

    public BasicRoll(double value, double modifier)
    {
      Value = value;
      Modifier = modifier;
    }

    public (RollResult result, double margin) Roll()
    {
      Random r = new Random();
      int rolledValue = r.Next(1, 6) + r.Next(1, 6) + r.Next(1, 6);

      var margin = (Value + Modifier) - rolledValue;

      if (rolledValue >= 18)
        return (RollResult.CriticalFailure, margin);
      if (rolledValue <= 3)
        return (RollResult.CriticalFailure, margin);
      if (margin >= 0)
        return (RollResult.Success, margin);

      return (RollResult.Faliure, margin);
    }
  }
}

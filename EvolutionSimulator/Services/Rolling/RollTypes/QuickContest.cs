using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Services.Rolling.RollTypes
{
  public class QuickContest : IRollable
  {
    private readonly IRollable Source;
    private readonly IRollable Target;

    // Value is ignored since two rolls are being compared to each other.
    public double Value { get; set; }

    // Modifier is ignored for both rolls since the contest is a difference on roll.
    public double Modifier { get; set; }

    public QuickContest(IRollable src, IRollable targ)
    {
      Source = src;
      Target = targ;
    }

    public (RollResult result, double margin) Roll()
    {
      var srcRoll = Source.Roll();
      var targRoll = Target.Roll();
      var margin = srcRoll.margin - targRoll.margin;

      if (Math.Abs(margin) < 0.0001)
        return (RollResult.None, 0);

      else if (margin > 5)
        return (RollResult.CriticalSuccess, margin);

      else if (margin < -5)
        return (RollResult.CriticalFailure, margin);

      else if (margin > 0)
        return (RollResult.Success, margin);

      return (RollResult.Faliure, margin);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Services.Rolling.RollTypes
{
  public class QuickContest : IRollable
  {
    private IRollable Source;
    private IRollable Target;
    public QuickContest(IRollable src, IRollable targ)
    {
      Source = src;
      Target = targ;
    }

    public (RollResult result, double margin) Roll()
    {
      while (true)
      {
        var srcRoll = Source.Roll();
        var targRoll = Target.Roll();
        var margin = srcRoll.margin - targRoll.margin;

        if (Math.Abs(margin) < 0.0001) continue;

        if (margin > 5)
          return (RollResult.CriticalSuccess, margin);

        if (margin < -5)
          return (RollResult.CriticalFailure, margin);

        if (margin > 0)
          return (RollResult.Success, margin);

        if (margin > 0)
          return (RollResult.Faliure, margin);
      }
    }
  }
}

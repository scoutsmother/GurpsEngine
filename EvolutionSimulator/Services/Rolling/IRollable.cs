using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Services.Rolling
{
  public enum RollResult
  {
    Success,
    Faliure,
    CriticalFailure,
    CriticalSuccess,
    None
  }
  public interface IRollable
  {
    double Value { get; }
    double Modifier { get; }

    (RollResult result, double margin) Roll();
  }
}

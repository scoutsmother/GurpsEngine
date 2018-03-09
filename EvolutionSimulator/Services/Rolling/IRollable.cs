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
    double Value { get; set; }
    double Modifier { get; set; }

    (RollResult result, double margin) Roll();
  }
}

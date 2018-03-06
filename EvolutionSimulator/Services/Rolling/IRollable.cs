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
    (RollResult result, double margin) Roll(double modifier);
  }
}

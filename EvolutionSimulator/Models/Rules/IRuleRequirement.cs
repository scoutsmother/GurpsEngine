using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Services.Rolling;

namespace EvolutionSimulator.Models.Rules
{
  public interface IRuleRequirement
  {
    bool TrySatisfy(IRollable roll);
  }
}

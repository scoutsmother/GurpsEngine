using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Rules;

namespace EvolutionSimulator.Models.Entities
{
  public interface IRuleEnabledEntity : IEntity
  {
    IReadOnlyCollection<IRuleRequirement> EntityBoundRules { get; }
  }
}

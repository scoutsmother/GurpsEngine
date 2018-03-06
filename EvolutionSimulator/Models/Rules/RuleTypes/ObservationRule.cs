using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Services.Rolling;

namespace EvolutionSimulator.Models.Rules.RuleTypes
{
  public class ObservationRule : GenericRule
  {
    public IEntity Subject { get; }

    public ObservationRule(Direction d, double diff, IEntity subject)
    : base(d, diff)
    {
      Subject = subject;
    }

    public override bool TrySatisfy(IRollable roll)
    {
      return base.TrySatisfy(roll);
    }
  }
}

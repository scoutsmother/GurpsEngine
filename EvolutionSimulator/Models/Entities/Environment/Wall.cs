using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Rules;
using EvolutionSimulator.Models.Rules.RuleTypes;
using EvolutionSimulator.Models.Stats;

namespace EvolutionSimulator.Models.Entities.Environment
{
  public class Wall : IRuleEnabledEntity
  {
    public StatSet Stats { get; }

    public IReadOnlyCollection<IRuleRequirement> EntityBoundRules => _entityBoundaryRules;

    private HashSet<IRuleRequirement> _entityBoundaryRules;

    public Wall(HashSet<Direction> blockedDirections, StatSet stats, double diff)
    {
      Stats = stats;
      _entityBoundaryRules = new HashSet<IRuleRequirement>();

      foreach (var dir in blockedDirections)
      {
        _entityBoundaryRules.Add(new MovementRule(dir, MoveType.In, diff));
        _entityBoundaryRules.Add(new MovementRule(dir, MoveType.Out, diff));
      }
    }
  }
}

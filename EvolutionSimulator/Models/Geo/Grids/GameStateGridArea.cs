using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Rules;

namespace EvolutionSimulator.Models.Geo.Grids
{
  public class GameStateGridArea : RuleBasedArea
  {
    public GameStateGridArea(int width, int height) : base(width, height)
    {

    }

    public void AddEntity(IRuleEnabledEntity ree, Point pt)
    {
      RulesForPoints[pt].UnionWith(ree.EntityBoundRules);
      Add(ree, pt);
    }

    public void RemoveEntity(IRuleEnabledEntity ree)
    {
      var location = Where(ree);
      RulesForPoints[location].ExceptWith(ree.EntityBoundRules);
      Remove(ree);
    }

    public void MoveEntity(IRuleEnabledEntity ree, Direction d)
    {
      var location = Where(ree);
      RemoveEntity(ree);
      AddEntity(ree, location + d);
    }
  }
}

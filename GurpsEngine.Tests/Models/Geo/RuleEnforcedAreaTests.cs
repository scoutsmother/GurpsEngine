using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Geo.Grids;
using EvolutionSimulator.Models.Rules;
using EvolutionSimulator.Models.Rules.RuleTypes;
using EvolutionSimulator.Services.Rolling;
using NSubstitute;
using Xunit;

namespace GurpsEngine.Tests.Models.Geo
{
  public class RuleEnforcedAreaTests
  {
    [Fact]
    public void MoveTest()
    {
      // Arrange
      RuleEnforcedArea rea = new RuleEnforcedArea(10, 10);
      LocationRuleSet ruleset = new LocationRuleSet(new HashSet<Rule>(), new HashSet<Rule>());

      // This rule will always succeed.
      IRuleRequirement succReq = Substitute.For<IRuleRequirement>();
      succReq.TrySatisfy(Arg.Any<IRollable>()).Returns(true);
      Rule r1 = new Rule(Direction.North, succReq);

      // This rule will always fail.
      IRuleRequirement failReq = Substitute.For<IRuleRequirement>();
      failReq.TrySatisfy(Arg.Any<IRollable>()).Returns(false);
      Rule r2 = new Rule(Direction.North, failReq);

      ruleset.AddInRule(r1);
      ruleset.AddOutRule(r2);

      // Entity will spawn at this location.
      IEntity e = Substitute.For<IEntity>();
      IRollable roll = Substitute.For<IRollable>();
      Point p = new Point(2, 4);
      rea.Add(e, p);

      // And travel this direction twice.
      Direction d = Direction.North;
      rea.PointsToRuleSet[p + d] = ruleset;

      // Act
      rea.Move(e, d, roll);
      rea.Move(e, d, roll);

      // Assert
      var underlyingArea = (GridArea) rea;
      Assert.Equal(underlyingArea.Where(e), p + d);
    }

    [Fact]
    public void CopyTest()
    {
      // Arrange
      RuleEnforcedArea rea = new RuleEnforcedArea(10, 10);
      IEntity e = Substitute.For<IEntity>();
      Point p = new Point(2, 4);

      // Act
      rea.Add(e, p);
      var newRea = rea.DeepCopy();

      // Assert: entity is in the collection, and is at the point p.
      Assert.True(newRea.Contains(e));
      Assert.Contains(e, newRea.At(p));
    }
  }
}

using System.Collections.Generic;
using System.Linq;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Geo.Grids;
using EvolutionSimulator.Models.Rules.RuleTypes;
using EvolutionSimulator.Services.Rolling;
using NSubstitute;
using Xunit;

namespace GurpsEngine.Tests.Models.Geo.Grids
{

  public class RuleBasedAreaTests
  {
    #region Test Data Objects
    public static IEnumerable<object[]> MoveData =>
      new List<object[]>
      {
        new object[] { new Point(1,1), Direction.East, new Point(2, 1), Direction.East, MoveType.In, false},
        new object[] { new Point(1,1), Direction.East, new Point(1, 1), Direction.East, MoveType.Out, false},
        new object[] { new Point(1,1), Direction.East, new Point(2, 1), Direction.West, MoveType.In, true},
        new object[] { new Point(1,1), Direction.East, new Point(1, 1), Direction.West, MoveType.Out, true},
      };

    public static IEnumerable<object[]> ObservationData =>
      new List<object[]>
      {
        new object[] { Direction.East, true },
      };
    #endregion

    [Theory]
    [MemberData(nameof(MoveData))]
    public void MovementRuleDirectionTest(Point start, Direction moveDirection, Point ruleLocation,
      Direction ruleDirection, MoveType type, bool allowed)
    {
      // Arrange
      var rollable = Substitute.For<IRollable>();
      var e = Substitute.For<IEntity>();

      // Two rules, allow entry via east, deny exit via east.
      MovementRule rule = Substitute.For<MovementRule>(ruleDirection, type, 0);
      rule.TrySatisfy(Arg.Any<IRollable>()).Returns(allowed);

      RuleBasedArea ruleBasedArea = new RuleBasedArea(10, 10);
      ruleBasedArea.RulesForPoints[ruleLocation].Add(rule);

      var gridArea = (GridArea)ruleBasedArea;

      ruleBasedArea.Add(e, start);

      // Act & Assert
      ruleBasedArea.Move(e, moveDirection, rollable);
      Assert.Equal(gridArea.Where(e).Equals(start + moveDirection), allowed);
    }

    [Theory]
    [MemberData(nameof(ObservationData))]
    public void AtObservationTest(Direction ruleDirection, bool allowed)
    {
      // Arrange
      var rollable = Substitute.For<IRollable>();
      var e = Substitute.For<IEntity>();

      // Entities at the location.
      Point location = new Point(1, 1);

      RuleBasedArea ruleBasedArea = new RuleBasedArea(10, 10);
      var gridArea = (GridArea)ruleBasedArea;

      var e1 = Substitute.For<IEntity>();
      gridArea.Add(e1, location);
      DirectObservationRule rule1 = Substitute.For<DirectObservationRule>(ruleDirection, 0, e1);
      ruleBasedArea.RulesForPoints[location].Add(rule1);
      rule1.TrySatisfy(Arg.Any<IRollable>()).Returns(allowed);

      var e2 = Substitute.For<IEntity>();
      gridArea.Add(e2, location);
      DirectObservationRule rule2 = Substitute.For<DirectObservationRule>(ruleDirection, 0, e2);
      ruleBasedArea.RulesForPoints[location].Add(rule2);
      rule2.TrySatisfy(Arg.Any<IRollable>()).Returns(!allowed);

      var realContents = ruleBasedArea.At(location, rollable).ToList();

      // Act & Assert
      var observedContents = ruleBasedArea.At(location).ToList();
      var diff = realContents.Except(observedContents);
      Assert.Contains(e1, observedContents);
    }
  }
}

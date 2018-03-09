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

namespace GurpsEngine.Tests.Models.Rules
{

  public class LocationRuleSetTests
  {
    #region
    public static IEnumerable<object[]> MoveData =>
      new List<object[]>
      {
        new object[] { new Point(1,1), Direction.East, MoveType.Out, true},
        new object[] { new Point(1,1), Direction.East, MoveType.In, false},
      };
    #endregion

    [Theory]
    [MemberData(nameof(MoveData))]
    public void MovementRuleDirectionTest(Point start, Direction d, MoveType type, bool allowed)
    {
      // Arrange
      var rollable = Substitute.For<IRollable>();
      var e = Substitute.For<IEntity>();

      // Two rules, allow entry via east, deny exit via east.
      MovementRule trueRule = Substitute.For<MovementRule>(d, type, 0);
      trueRule.TrySatisfy(Arg.Any<IRollable>()).Returns(allowed);

      RuleBasedArea ruleBasedArea = new RuleBasedArea(10, 10);
      ruleBasedArea.RulesForPoints[start + d].Add(trueRule);

      var gridArea = (GridArea) ruleBasedArea;

      ruleBasedArea.Add(e, start);

      // Act & Assert
      ruleBasedArea.Move(e, Direction.East, rollable);
      Assert.Equal(gridArea.Where(e).Equals(start + d), allowed);
    }
  }
}

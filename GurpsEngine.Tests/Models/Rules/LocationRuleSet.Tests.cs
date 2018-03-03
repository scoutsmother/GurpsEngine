using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Rules;
using EvolutionSimulator.Models.Rules.RuleTypes;
using EvolutionSimulator.Services.Rolling;
using NSubstitute;
using Xunit;

namespace GurpsEngine.Tests.Models.Rules
{
  public class LocationRuleSetTests
  {
    [Fact]
    public void TryEnter()
    {
      // Arrange
      var rollable = Substitute.For<IRollable>();

      var trueReq = Substitute.For<IRuleRequirement>();
      trueReq.TrySatisfy(Arg.Any<IRollable>()).Returns(true);

      var falseReq = Substitute.For<IRuleRequirement>();
      falseReq.TrySatisfy(Arg.Any<IRollable>()).Returns(false);

      var trueRule = new Rule(Direction.South, trueReq);
      var falseRule = new Rule(Direction.North, falseReq);

      var rs = new LocationRuleSet(new HashSet<Rule>() { trueRule }, new HashSet<Rule>() { falseRule });

      // Act & Assert
      Assert.False(rs.TryLeave(Direction.North, rollable));
      Assert.True(rs.TryEnter(Direction.South, rollable));
    }
  }
}

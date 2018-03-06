using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Services.Rolling;
using EvolutionSimulator.Services.Rolling.RollTypes;
using NSubstitute;
using Xunit;

namespace GurpsEngine.Tests.Services.Rolling
{
  public class QuickContestTests
  {

    [Fact]
    public void RollTest()
    {
      // Arrange
      IRollable src = Substitute.For<IRollable>();
      IRollable targ = Substitute.For<IRollable>(); 
      QuickContest qc = new QuickContest(src, targ);

      IEnumerable<(RollResult, double)> srcRolls = new List<(RollResult, double)>()
        {(RollResult.Success, 1), (RollResult.Success, 1), (RollResult.Success, 2)};

      IEnumerable<(RollResult, double)> targRolls = new List<(RollResult, double)>()
        {(RollResult.Success, 1), (RollResult.Success, 1), (RollResult.Success, 1)};

      src.Roll().Returns((RollResult.Success, 1));
      targ.Roll().Returns((RollResult.Success, 1));

      // Act
      var result = qc.Roll();

      // Assert
      Assert.Equal((RollResult.Success, 1), result);
    }
  }
}

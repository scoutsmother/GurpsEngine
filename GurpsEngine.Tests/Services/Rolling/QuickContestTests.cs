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

    [Theory]
    [InlineData(RollResult.Success, 1, RollResult.Success, 1, RollResult.None, 0)]
    [InlineData(RollResult.Success, 1, RollResult.Success, 2, RollResult.Faliure, -1)]
    [InlineData(RollResult.Success, 2, RollResult.Success, 1, RollResult.Success, 1)]
    [InlineData(RollResult.Success, 7, RollResult.Success, 1, RollResult.CriticalSuccess, 6)]
    [InlineData(RollResult.Success, 1, RollResult.Success, 7, RollResult.CriticalFailure, -6)]
    public void RollTest(RollResult srcResult, double srcMargin, RollResult targResult, double targMargin, 
      RollResult expectedResult, double expectedMargin)
    {
      // Arrange
      IRollable src = Substitute.For<IRollable>();
      IRollable targ = Substitute.For<IRollable>(); 
      QuickContest qc = new QuickContest(src, targ);

      src.Roll().Returns((srcResult, srcMargin));
      targ.Roll().Returns((targResult, targMargin));

      // Act
      var result = qc.Roll();

      // Assert
      Assert.Equal((expectedResult, expectedMargin), result);
    }
  }
}

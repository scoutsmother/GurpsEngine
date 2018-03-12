using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Geo.Grids;
using EvolutionSimulator.Models.Rules;
using NSubstitute;
using Xunit;

namespace GurpsEngine.Tests.Models.Geo.Grids
{
  public class GameStateGridAreaTests
  {
    [Fact]
    public void AddTest()
    {
      // Arrange
      GameStateGridArea gsge = new GameStateGridArea(10, 10);
      Point pt = new Point(2,2);
      IRuleEnabledEntity ree = Substitute.For<IRuleEnabledEntity>();

      var ruleSet = new HashSet<IRuleRequirement>()
      {
        Substitute.For<IRuleRequirement>(),
        Substitute.For<IRuleRequirement>(),
      };

      ree.EntityBoundRules.Returns(ruleSet);

      // Act
      gsge.AddEntity(ree, pt);

      // Assert
      var rba = (RuleBasedArea) gsge;
      var ruleCollection = rba.RulesForPoints[pt];

      // Assert that the rules where put into the set correctly.
      Assert.True(ruleSet.Intersect(ruleCollection).SequenceEqual(ruleSet));
    }

    [Fact]
    public void RemoveTest()
    {
      // Arrange
      GameStateGridArea gsge = new GameStateGridArea(10, 10);
      var rba = (RuleBasedArea)gsge;

      Point pt = new Point(2, 2);
      IRuleEnabledEntity ree = Substitute.For<IRuleEnabledEntity>();

      var ruleSet = new HashSet<IRuleRequirement>()
      {
        Substitute.For<IRuleRequirement>(),
        Substitute.For<IRuleRequirement>(),
      };

      rba.RulesForPoints[pt].UnionWith(ruleSet);
      rba.Add(ree, pt);
      ree.EntityBoundRules.Returns(ruleSet);

      // Act
      gsge.RemoveEntity(ree);

      // Assert
      var ruleCollection = rba.RulesForPoints[pt];

      // Assert that the rules where removed from the set correctly.
      Assert.True(ruleSet.Intersect(ruleCollection).SequenceEqual(new List<IRuleRequirement>()));
      // Assert the entity is no longer in the set.
      Assert.False(rba.Contains(ree));
    }

    [Fact]
    public void MoveTest()
    {
      // Arrange
      GameStateGridArea gsge = new GameStateGridArea(10, 10);
      var rba = (RuleBasedArea)gsge;

      Point pt = new Point(2, 2);
      Direction d = Direction.East;
      IRuleEnabledEntity ree = Substitute.For<IRuleEnabledEntity>();

      var ruleSet = new HashSet<IRuleRequirement>()
      {
        Substitute.For<IRuleRequirement>(),
        Substitute.For<IRuleRequirement>(),
      };

      rba.RulesForPoints[pt].UnionWith(ruleSet);
      rba.Add(ree, pt);
      ree.EntityBoundRules.Returns(ruleSet);

      // Act
      gsge.MoveEntity(ree, d);

      // Assert
      var prevCollection = rba.RulesForPoints[pt];
      var currCollection = rba.RulesForPoints[pt + d];

      // Assert that the rules where removed from the set correctly.
      Assert.True(ruleSet.Intersect(prevCollection).SequenceEqual(new List<IRuleRequirement>()));

      // Assert that the rules where removed from the set correctly.
      Assert.True(ruleSet.Intersect(currCollection).SequenceEqual(ruleSet));

      // Assert the entity is no longer in the set.
      Assert.Equal(rba.Where(ree), pt + d);
    }


  }
}

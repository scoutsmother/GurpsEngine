using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Models.Geo.Grids;
using NSubstitute;
using Xunit;

namespace GurpsEngine.Tests.Models.Geo.Grids
{
  public class GridAreaTests
  {
    [Fact]
    public void GridAreaInsert()
    {
      // Arrange
      GridArea ga = new GridArea(10, 10);
      IEntity e = Substitute.For<IEntity>();
      Point p = new Point(2, 4);

      // Act: Add point to the dictionary.
      ga.Add(e, p);

      // Assert: entity is in the collection, and is at the point p.
      Assert.True(ga.Contains(e));
      Assert.Contains(e, ga.At(p));
    }

    [Fact]
    public void GridAreaRemove()
    {
      // Arrange
      GridArea ga = new GridArea(10, 10);
      IEntity e = Substitute.For<IEntity>();
      Point p = new Point(2, 4);

      // Act: Add point to the dictionary.
      ga.Add(e, p);
      ga.Remove(e);

      // Assert: entity is in the collection, and is at the point p.
      Assert.False(ga.Contains(e));
      Assert.DoesNotContain(e, ga.At(p));
    }

    [Fact]
    public void CopyTest()
    {
      // Arrange
      GridArea ga = new GridArea(10, 10);
      IEntity e = Substitute.For<IEntity>();
      Point p = new Point(2, 4);

      // Act
      ga.Add(e, p);
      var newGa = ga.DeepCopy();

      // Assert: entity is in the collection, and is at the point p.
      Assert.True(newGa.Contains(e));
      Assert.Contains(e, newGa.At(p));
    }

    [Fact]
    public void GridAreaMove()
    {
      // Arrange
      GridArea ga = new GridArea(10, 10);
      IEntity e = Substitute.For<IEntity>();
      Point p = new Point(2, 4);
      Direction d = Direction.North;

      // Act: Add point to the dictionary.
      ga.Add(e, p);
      ga.Move(e, d);

      // Assert: entity is in the collection, and has moved to the point
      // p + d.
      Assert.True(ga.Contains(e));
      Assert.DoesNotContain(e, ga.At(p));
      Assert.Contains(e, ga.At(p + d));
    }
  }
}

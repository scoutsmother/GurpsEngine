using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Geo.Geometry;
using Xunit;

namespace GurpsEngine.Tests.Models.Geo.Geometry
{
  public class PointTests
  {
    [Fact]
    public void HashTest()
    {
      Point p1 = new Point(1,2);
      Point p2 = new Point(1,2);

      Assert.Equal(p1.GetHashCode(), p2.GetHashCode());
    }

    [Fact]
    public void DictionaryHashTest()
    {
      Point p1 = new Point(1, 1);
      Point p2 = new Point(1, 1);

      Dictionary<Point, object> mapping = new Dictionary<Point, object> {{p1, ""}};

      Assert.True(mapping.ContainsKey(p2));
    }
  }
}

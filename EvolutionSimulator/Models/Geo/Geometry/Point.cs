using System;

namespace EvolutionSimulator.Models.Geo.Geometry
{
  public class Direction : Point
  {
    public static readonly Direction North = new Direction(0, -1);
    public static readonly Direction South = new Direction(0, 1);
    public static readonly Direction East = new Direction(1, 0);
    public static readonly Direction West = new Direction(-1, 0);
    public static readonly Direction None = new Direction(0, 0);

    private Direction(int x, int y)
      : base(x, y)
    {

    }
  }

  public class Point
  {
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
      X = x;
      Y = y;
    }

    public override int GetHashCode()
    {
      return X.GetHashCode() ^ Y.GetHashCode();
    }

    public int ManhattanDistance(Point p)
    {
      return Math.Abs(this.X - p.X) + Math.Abs(this.Y - p.Y);
    }

    #region Operators

    public static Point operator +(Point p1, Point p2)
    {
      return new Point(p1.X + p2.X, p1.Y + p2.Y);
    }

    public static Point operator -(Point p1, Point p2)
    {
      return new Point(p1.X - p2.X, p1.Y - p2.Y);
    }

    public static bool operator ==(Point obj1, Point obj2)
    {
      return (obj1?.X == obj2?.X && obj1?.Y == obj2?.Y);
    }

    public static bool operator !=(Point obj1, Point obj2)
    {
      return (obj1?.X != obj2?.X || obj1?.Y != obj2?.Y);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Point);
    }

    public bool Equals(Point other)
    {
      return (X == other.X && Y == other.Y);
    }

    #endregion

    public override string ToString()
    {
      return "(" + X + "," + Y + ")";
    }
  }
}

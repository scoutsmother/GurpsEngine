using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;
using EvolutionSimulator.Utilities.DeepCopy;

namespace EvolutionSimulator.Models.Geo.Grids
{
  public class GridArea : IGrid, IDeepCopyable<GridArea>
  {
    // Point to Location mapping. 
    protected Dictionary<Point, HashSet<IEntity>> EntitiesFromPoint { get; set; }

    // Point mapping for a given entity.
    protected Dictionary<IEntity, Point> PointFromEntity { get; set; }

    protected List<Point> Points { get; }

    // Dimensions
    public int Width { get; private set; }
    public int Height { get; private set; }

    public GridArea(int width, int height)
    {
      Width = width;
      Height = height;

      // Generate all pairs of x,y points.
      EntitiesFromPoint = new Dictionary<Point, HashSet<IEntity>>();
      PointFromEntity = new Dictionary<IEntity, Point>();

      List<int> widthRange = Enumerable.Range(0, width).ToList();
      List<int> heightRange = Enumerable.Range(0, height).ToList();

      Points = (from x in widthRange
                   from y in heightRange
                   where !EntitiesFromPoint.ContainsKey((new Point(x, y)))
                   select new Point(x, y))
        .ToList();

      // Create locations for each point in the area.
      Points.ForEach(x => EntitiesFromPoint[x] = new HashSet<IEntity>());
    }

    /// <summary>
    /// Entity is present in the grid.
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public bool Contains(IEntity e)
    {
      if (e == null)
        throw new ArgumentException("Entity cannot be null.");

      return PointFromEntity.ContainsKey(e) &&
             EntitiesFromPoint[PointFromEntity[e]].Contains(e);
    }

    /// <summary>
    /// Point is not null and exists in the grid.
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public bool Valid(Point p)
    {
      if (p == null)
        throw new ArgumentException("Point cannot be null.");

      return EntitiesFromPoint.ContainsKey(p);
    }

    public virtual void Add(IEntity e, Point p)
    {
      if (Contains(e))
        throw new ArgumentException("Cannot add an entity more than once.");

      if (!Valid(p))
        throw new IndexOutOfRangeException("Cannot address a point outside the play area.");

      PointFromEntity.Add(e, p);
      EntitiesFromPoint[p].Add(e);
    }

    public virtual void Remove(IEntity e)
    {
      if (!Contains(e))
        throw new ArgumentException("Cannot remove an entity not contained in the grid.");

      var p = PointFromEntity[e];
      PointFromEntity.Remove(e);

      if (!EntitiesFromPoint[p].Contains(e))
        throw new ArgumentException("Entity contained in only one dictionary.");

      EntitiesFromPoint[p].Remove(e);
    }

    public virtual HashSet<IEntity> At(Point p)
    {
      if (!Valid(p))
        throw new IndexOutOfRangeException("Cannot address a point outside the play area.");

      return EntitiesFromPoint[p];
    }

    public virtual Point Where(IEntity e)
    {
      if (!Contains(e))
        throw new ArgumentException("Entity does not exist in the grid.");

      return PointFromEntity[e];
    }

    public virtual void Move(IEntity e, Direction d)
    {
      var pos = Where(e);
      if (!Valid(pos + d))
        throw new ArgumentException("Location cannot be moved to.");

      Remove(e);
      Add(e, pos + d);
    }

    public virtual GridArea DeepCopy()
    {
      var ga = CreateInstanceForBase();
      ga.EntitiesFromPoint = EntitiesFromPoint.ToDictionary(
        pair => pair.Key, pair => new HashSet<IEntity>(pair.Value));
      ga.PointFromEntity = PointFromEntity.ToDictionary(
        pair => pair.Key, pair => pair.Value);

      return ga;
    }

    public virtual GridArea CreateInstanceForBase()
    {
      return new GridArea(Width, Height);
    }
  }
}

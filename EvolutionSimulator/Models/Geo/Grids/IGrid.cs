using System.Collections.Generic;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.Geo.Geometry;

namespace EvolutionSimulator.Models.Geo.Grids
{
  public interface IGrid
  {
    /// <summary>
    /// Add an entity to the grid at a point location.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="p"></param>
    void Add(IEntity e, Point p);

    /// <summary>
    /// Remove an entity from the grid.
    /// </summary>
    /// <param name="e"></param>
    void Remove(IEntity e);

    /// <summary>
    /// Get the entity at a point.
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    HashSet<IEntity> At(Point p);

    /// <summary>
    /// Gets the point where the entity is.
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    Point Where(IEntity e);

    /// <summary>
    /// Move an entity using a cardinal direction.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="d"></param>
    void Move(IEntity e, Direction d);
  }
}

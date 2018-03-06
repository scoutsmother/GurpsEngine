using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionSimulator.Models.Actions.ActionTypes;
using EvolutionSimulator.Models.Entities;
using EvolutionSimulator.Models.State;
using EvolutionSimulator.Models.Geo.Geometry;

namespace EvolutionSimulator.Models.Actions.Movement
{
  public class MoveAction : EntityAction
  {
    public IEntity Subject;
    public Direction Vector { get; }

    public MoveAction(IEntity e, Direction d) : base(e)
    {
      Subject = e;
      Vector = d;
    }

    public override void ResolveAction(IGameState gs)
    {
      // Validate the move is valid.
      gs.Grid.Valid(Subject, Vector);


    }
  }
}

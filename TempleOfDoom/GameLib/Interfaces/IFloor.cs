using GameLib.Enums;
using GameLib.Models;

namespace GameLib.Interfaces;

public interface IFloor
{
    
    public Coords Coords { get; }
    public Direction Direction { get; }

    public Coords OnEnter(Coords currentCoords);
}
using CODE_TempleOfDoom_DownloadableContent;
using GameLib.Enums;
using GameLib.Interfaces;

namespace GameLib.Models;

public class ConveyorBeltFloor : IFloor
{
    public Coords Coords { get; }
    public Direction Direction { get; }
    public ConveyorBeltFloor(Coords coords, Direction direction)
    {
        Coords = coords;
        Direction = direction;
    }
    
    public Coords OnEnter(Coords currentCoords)
    {
        return currentCoords.NextCoords(Direction);
    }
    
    
}
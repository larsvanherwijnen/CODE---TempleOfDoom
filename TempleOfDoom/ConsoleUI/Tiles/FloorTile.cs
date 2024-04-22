using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models;

namespace Frontend.Tiles;

public class FloorTile : ITileView
{
    private readonly IFloor _floor;
    
    public FloorTile(IFloor floor)
    {
        _floor = floor;
    }
    public char GetIcon()
    {
        return _floor switch
        {
            ConveyorBeltFloor conveyorBeltFloor => conveyorBeltFloor.Direction switch
            {
                Direction.North => '^',
                Direction.East => '>',
                Direction.South => 'v',
                Direction.West => '<',
                _ => ' '
            },
            _ => ' '
        };
    }

    public ConsoleColor GetColor()
    {
        return ConsoleColor.White;
    }
}
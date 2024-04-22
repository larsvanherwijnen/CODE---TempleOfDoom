using GameLib.Enums;
using GameLib.Interfaces;

namespace GameLib.Models;

public class Connection
{
    public Room TargetRoom { get; }

    public Direction TargetDirection { get; }
    
    public IDoor Door { get; }
    
    public Connection(Room targetRoom, Direction targetDirection, IDoor door)
    {
        TargetRoom = targetRoom;
        TargetDirection = targetDirection;
        Door = door;
    }

    public Coords GetSpawnCoords(Direction direction)
    {
        int x, y;
        switch (direction)
        {
            case Direction.North:
                x = TargetRoom.Width / 2;
                y = TargetRoom.Height - 1;
                break;
            case Direction.South:
                x = TargetRoom.Width / 2;
                y = 0;
                break;
            case Direction.West:
                x = TargetRoom.Width - 1;
                y = TargetRoom.Height / 2;
                break;
            case Direction.East:
                x = 0;
                y = TargetRoom.Height / 2;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
        
        return new Coords(x, y);
    }
}
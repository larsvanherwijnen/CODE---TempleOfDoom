using GameLib.Enums;

namespace GameLib.Models;

public class Coords
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coords(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public Coords NextCoords(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new Coords(X, Y - 1);
            case Direction.South:
                return new Coords(X, Y + 1);
            case Direction.West:
                return new Coords(X - 1, Y);
            case Direction.East:
                return new Coords(X + 1, Y);
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

}
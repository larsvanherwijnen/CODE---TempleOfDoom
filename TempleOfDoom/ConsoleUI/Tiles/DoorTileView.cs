using GameLib.Decorators.DoorDecorators;
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models;

namespace Frontend.Tiles;

public class DoorTileView : ITileView
{
    private readonly Direction _direction;
    private readonly IDoor _doorType;
    public DoorTileView(IDoor door, Direction direction = Direction.North)
    {
        _doorType = door;
        _direction = direction;
    }

    public char GetIcon()
    {
        // Check the decorated door type
        BaseDoorDecorator? baseDoor = _doorType as BaseDoorDecorator;
        if (baseDoor != null && baseDoor._decoratee is not Door)
        {
            return GetIconString(baseDoor._decoratee);
        }

        return GetIconString(_doorType);
    }
    
    public char GetIconString(IDoor door)
    {
        return door switch
        {
            ClosingGateDecorator _ => '∩',
            ColoredDoorDecorator _ => _direction == Direction.North || _direction == Direction.South ? '=' : '|',
            ToggleDoorDecorator _ => '┻',
            _ => ' '
        };
    }

    public ConsoleColor GetColor()
    {
        if (_doorType == null)
        {
            return ConsoleColor.White;
        }
        
        return Enum.Parse<ConsoleColor>(_doorType.GetColor(), true);
    }
}
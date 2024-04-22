using DataReader.DTO;
using GameLib.Decorators.DoorDecorators;
using GameLib.Interfaces;
using GameLib.Models;

namespace DataReader.Factories;

public class DoorFactory
{
    public IDoor CreateDoor(ConnectionsDto connection)
    {
        IDoor door = new Door(false);

        foreach (DoorsDto connectionDoor in connection.doors)
        {
            door = DecorateDoor(door, connectionDoor.type, connectionDoor.color, connectionDoor.no_of_stones = 0);
        }
        
        return door;
    }
    
    public IDoor DecorateDoor(IDoor door, string type, string color, int noOfStones)
    {
        switch (type)
        {
            case "colored":
                return new ColoredDoorDecorator(door, color);
            case "toggle":
                return new ToggleDoorDecorator(door);
            case "closing gate":
                return new ClosingGateDecorator(door);
            case "open on odd":
                return new OpenOnOddDecorator(door);
            case "open on stones in room":
                return new OpenOnStonesInRoomDecorator(door, noOfStones);
            default:
                throw new ArgumentException("Ongeldig deurtype");
        }
    }
}
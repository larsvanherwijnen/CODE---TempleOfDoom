using DataReader.DTO;
using GameLib;
using GameLib.Interfaces;
using GameLib.Models;

namespace DataReader.Factories;

public class RoomFactory
{
    public Room CreateRoom(RoomsDto room)
    {
        switch (room.type)
        {
            case "room":
                return new Room(room.id, room.width, room.height);
            default:
                throw new NotImplementedException("This room is not implemented yet");
        }
    }
}
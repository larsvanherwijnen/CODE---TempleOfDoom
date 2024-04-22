using DataReader.DTO;
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models;

namespace DataReader.Factories;

public class FloorFactory
{
    public IFloor CreateFloor(SpecialFloorTilesDto floorDto)
    {
        IFloor floor;

        switch (floorDto.type)
        {
            case "conveyor belt":
                floor = new ConveyorBeltFloor(new Coords(floorDto.x, floorDto.y), Enum.Parse<Direction>(ConvertToTitleCase(floorDto.direction)));
                break;
            default:
                throw new NotImplementedException("This floor has not been implemented yet");
        }

        return floor;
    }
    
    static string ConvertToTitleCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        // Convert the first character to uppercase and the rest to lowercase
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }
}
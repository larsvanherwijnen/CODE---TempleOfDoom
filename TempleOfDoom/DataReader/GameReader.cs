using DataReader.DTO;
using DataReader.Factories;
using DataReader.Interface;
using GameLib.Adapters;
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models;
using Player = GameLib.Models.Player;

namespace DataReader;

public class GameReader
{
    private readonly DoorFactory _doorFactory;
    private readonly RoomFactory _roomFactory;
    private readonly ItemFactory _roomItemFactory;
    private readonly FloorFactory _floorFactory;
    private readonly EnemyFactory _enemyFactory;
    public GameReader(DoorFactory doorFactory, RoomFactory roomFactory, ItemFactory roomItemFactory, FloorFactory floorFactory, EnemyFactory enemyFactory)
    {
        _doorFactory = doorFactory;
        _roomFactory = roomFactory;
        _roomItemFactory = roomItemFactory;
        _floorFactory = floorFactory;
        _enemyFactory = enemyFactory;
    }

    public Game Read(string filePath)
    {
        IFileReader jsonReader = new FileReaderFactory().CreateFileReader(filePath);
        DataProcessor dataProcessor = new DataProcessor(jsonReader);


        GameObject gameData = dataProcessor.ProcessData(filePath);

        List<Room> rooms = CreateRooms(gameData.rooms);
        Player player = CreatePlayer(gameData.player, rooms);

        ApplyConnections(gameData.connections, rooms);

        return new Game(player, rooms, filePath);
    }

    private List<Room> CreateRooms(RoomsDto[] rooms)
    {
        List<Room> roomList = new List<Room>();

        foreach (RoomsDto room in rooms)
        {
            Room newRoom = _roomFactory.CreateRoom(room);
            newRoom.AddRoomItems(CreateItems(room.items));
            if (room.specialFloorTiles != null) newRoom.AddFloors(createFloors(room.specialFloorTiles));
            if (room.enemies != null) newRoom.AddEnemies(CreateEnemies(room.enemies));
            roomList.Add(newRoom);
        }

        return roomList;
    }

    private Player CreatePlayer(PlayerDto player, List<Room> rooms)
    {
        int startRoomId = player.startRoomId;
        int lives = player.lives;
        Coords coords = new Coords(player.startX, player.startY);
        Room room = rooms.First(room1 => room1.Id == startRoomId);

        return new Player(room, coords, lives);
    }

    private List<IItem> CreateItems(ItemsDto[]? items)
    {
        List<IItem> itemList = new List<IItem>();

        if (items != null)
        {
            foreach (ItemsDto item in items)
            {
                IItem newItem = _roomItemFactory.CreateItem(item);
                itemList.Add(newItem);
            }
        }

        return itemList;
    }
    
    private List<IFloor> createFloors(SpecialFloorTilesDto[] floors)
    {
        List<IFloor> floorList = new List<IFloor>();
        
        foreach (SpecialFloorTilesDto floor in floors)
        {
            IFloor newFloor = _floorFactory.CreateFloor(floor);
            floorList.Add(newFloor);
        }

        return floorList;
    }
    
    private List<EnemyAdapter> CreateEnemies(EnemiesDto[] enemies)
    {
        List<EnemyAdapter> enemyList = new List<EnemyAdapter>();

        if (enemies != null)
        {
            foreach (EnemiesDto enemy in enemies)
            {
                EnemyAdapter newEnemy = _enemyFactory.CreateEnemy(enemy);
                enemyList.Add(newEnemy);
            }
        }

        return enemyList;
    }

    private void ApplyConnections(ConnectionsDto[] gameDataConnections, List<Room> rooms)
    {
        foreach (ConnectionsDto connection in gameDataConnections)
        {
            
            if (connection.portal != null)
            {
                List<PortalDto> portals = connection.portal.ToList();
                
                Room roomOne = rooms.First(room => room.Id == portals.First().roomId);
                Room roomTwo = rooms.First(room => room.Id == portals.Last().roomId);
                
                Coords coordsOne = new Coords(portals.First().x, portals.First().y);
                Coords coordsTwo = new Coords(portals.Last().x, portals.Last().y);
                
                Portal portalRoomOne = new Portal(roomTwo, coordsTwo);
                Portal portalRoomTwo = new Portal(roomOne, coordsOne);
                
                roomOne.AddPortal(coordsOne, portalRoomOne);
                roomTwo.AddPortal(coordsTwo, portalRoomTwo);
            }
            else
            {
                IDoor door = connection.doors.Count() > 0 ? _doorFactory.CreateDoor(connection) : null;

                Dictionary<Direction, int> directions = CreateConnection(connection);

                Room roomOne = rooms.First(room => room.Id == directions.First().Value);
                Room roomTwo = rooms.First(room => room.Id == directions.Last().Value);

                // Each connection connects 2 rooms
                roomOne.AddConnection(directions.Last().Key, new Connection(roomTwo, directions.First().Key, door));
                
                roomTwo.AddConnection(directions.First().Key, new Connection(roomOne, directions.Last().Key, door));
            }
        }
    }

    private Dictionary<Direction, int> CreateConnection(ConnectionsDto connection)
    {
        Dictionary<Direction, int> directions = new Dictionary<Direction, int>();

        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            int directionValue = 0;

            // Access the property directly based on the direction
            switch (direction)
            {
                case Direction.North:
                    directionValue = connection.NORTH;
                    break;
                case Direction.South:
                    directionValue = connection.SOUTH;
                    break;
                case Direction.West:
                    directionValue = connection.WEST;
                    break;
                case Direction.East:
                    directionValue = connection.EAST;
                    break;
                // Add additional cases if you have more directions
            }

            // Only add the direction if its value is not equal to 0
            if (directionValue != 0)
            {
                directions.Add(direction, directionValue);
            }
        }

        return directions;
    }
}
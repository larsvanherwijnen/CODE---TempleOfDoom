using GameLib.Adapters;
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models.Items;

namespace GameLib.Models;

public class Room
{
    public int Id { get; }
    public int Width { get; }
    public int Height { get; }
    private List<IItem> Items { get; }
    private Dictionary<Direction, Connection?> Connections { get; }
    private Dictionary<Coords, Portal> Portals { get; }
    private List<EnemyAdapter> Enemies { get; }
    private List<IFloor> Floors { get; }

    public Room(int id, int width, int height)
    {
        Id = id;
        Width = width;
        Height = height;
        Items = new List<IItem>();
        Connections = new Dictionary<Direction, Connection?>();
        Portals = new Dictionary<Coords, Portal>();
        Floors = new List<IFloor>();
        Enemies = new List<EnemyAdapter>();
    }
    
    /*
     * Checks if the given coords are part of the border of the room
     * if so return true
     *
     * This function is used to draw the border of the room
     * and to prevent the player from moving outside the room
     */
    public bool IsPartOfBorder(Coords coords)
    {
        if (HasConnection(coords))
        {
            return false;
        }

        return coords.X >= Width - 1 || coords.X <= 0 || coords.Y >= Height - 1 || coords.Y <= 0;
    }

    public void AddRoomItems(List<IItem> items)
    {
        Items.AddRange(items);
    }

    public void AddConnection(Direction direction, Connection? connection)
    {
        Connections.Add(direction, connection);
    }

    public void AddPortal(Coords coords, Portal portal)
    {
        Portals.Add(coords, portal);
    }

    public void AddFloors(List<IFloor> floors)
    {
        Floors.AddRange(floors);
    }

    public void AddEnemies(List<EnemyAdapter> enemies)
    {
        Enemies.AddRange(enemies);
    }

    private bool HasConnection(Coords coords)
    {
        return HasConnection(coords, out _, out _);
    }
    
    public bool HasPortal(Coords coords)
    {
        return Portals.FirstOrDefault(portal => portal.Key.X == coords.X && portal.Key.Y == coords.Y).Value != null;
    }

    public bool HasSpecialFloor(Coords coords, out IFloor floor)
    {
        floor = Floors.FirstOrDefault(floor => floor.Coords.X == coords.X && floor.Coords.Y == coords.Y);
        return floor != null;
    }

    public bool HasPortal(Coords coords, out Portal portal)
    {
        portal = Portals.FirstOrDefault(portal => portal.Key.X == coords.X && portal.Key.Y == coords.Y).Value;
        return portal != null;
    }

    public bool HasItem(Coords coords, out IItem item)
    {
        item = Items.FirstOrDefault(item => item.Visible && item.Coords.X == coords.X && item.Coords.Y == coords.Y);
        return item != null;
    }

    public bool HasEnemy(Coords coords)
    {
        return HasEnemy(coords, out _);
    }

    private bool HasEnemy(Coords coords, out EnemyAdapter enemy)
    {
        enemy = Enemies.FirstOrDefault(enemy =>
            enemy.GetCurrentCoords().X == coords.X && enemy.GetCurrentCoords().Y == coords.Y && enemy.Lives > 0);
        return enemy != null;
    }

    public int GetStonesInRoom()
    {
        return Items.Count(item => item.GetItem() is SankaraStoneItem && item.Visible);
    }
    
    
    /*
     * Moves all the enemies to their next location.
     */
    public void MoveEnemies()
    {
        foreach (EnemyAdapter enemy in Enemies)
        {
            enemy.Move();
            Coords currentCoords = enemy.GetCurrentCoords();
            if (HasSpecialFloor(currentCoords, out IFloor floor))
            {
                enemy.SetCurrentCoords(floor.OnEnter(currentCoords));
            }
        }
    }

    /*
     * Checks if there is an enemy at the next coords based on the direction 
     * if so the enemy takes damage
     */
    public void Shoot(Coords coords)
    {
        foreach (Direction direction in Direction.GetValues(typeof(Direction)))
        {
            Coords newCoords = coords.NextCoords(direction);
            if (HasEnemy(newCoords, out EnemyAdapter enemy))
            {
                enemy.TakeDamage();
                return;
            }
        }
    }

   /*
    * Checks if there is a connection at the given coords if so return direction and connection
    */
    public bool HasConnection(Coords coords, out Direction direction, out Connection? connection)
    {
        direction = Direction.North;
        connection = null;

        if (coords.X == Width / 2)
        {
            if (coords.Y == 0 && Connections.TryGetValue(Direction.North, out connection))
            {
                direction = Direction.North;
                return true;
            }

            if (coords.Y == Height - 1 && Connections.TryGetValue(Direction.South, out connection))
            {
                direction = Direction.South;
                return true;
            }
        }
        else if (coords.Y == Height / 2)
        {
            if (coords.X == 0 && Connections.TryGetValue(Direction.West, out connection))
            {
                direction = Direction.West;
                return true;
            }

            if (coords.X == Width - 1 && Connections.TryGetValue(Direction.East, out connection))
            {
                direction = Direction.East;
                return true;
            }
        }

        return false;
    }
    public void ToggleToggleDoors()
    {
        foreach (Connection? connection in Connections.Values)
        {
            connection.Door.Toggle();
        }
    }
}

using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models.Items;


namespace GameLib.Models;

public class Player
{
    private Coords _startCoords;
    private Room _startRoom;
    public int Lives { get; private set; }
    public Room Room { get; private set; }
    public Coords Coords { get; private set; }

    public List<IItem> Items { get; }

    public int Stones => Items.Count(item => item.GetItem() is SankaraStoneItem);
    public string[] Keys => Items.Where(item => item.GetItem() is KeyItem)
        .Select(item => ((KeyItem)item.GetItem()).Color).ToArray();

    public Player(Room startRoom, Coords coords, int lives)
    {
        Room = _startRoom = startRoom;
        Coords = _startCoords = coords;
        Lives = lives;

        Items = new List<IItem>();
    }
    
    public bool IsOnCoords(Coords coords)
    {
        return Coords.X == coords.X && Coords.Y == coords.Y;
    }
    
    /*
     * Move the player in the given direction updates the coords and possibly the room
     * if the player can move to the next coords
     */
    public void Move(Direction direction)
    {
        Coords coords = Coords.NextCoords(direction); 

        if (Room.HasConnection(coords, out Direction doorDirection, out Connection connection))
        {
            if (connection.Door != null && !connection.Door.IsOpen(this))
            {
                return;
            }

            Room = connection.TargetRoom;
            Coords = connection.GetSpawnCoords(direction);

            if (connection.Door != null)
            {
                connection.Door.AfterUse(this);
            }
            
            return;
        }

        if (Room.HasItem(coords, out IItem item))
        {
            item.Interaction(this);
        }
        
        if (Room.IsPartOfBorder(coords))
        {
            return;
        }
        


        if (Room.HasPortal(coords, out Portal portal))
        {
            portal.GetSpawnCoords(out Room room, out Coords newCoords);
            Room = room;                
            Coords = newCoords;

            return;
        }
        
        if (Room.HasSpecialFloor(coords, out IFloor floor))
        {
            Coords = floor.OnEnter(coords);
            return;
        }

        Coords = coords;
    }

    public void TakeDamage(int damage)
    {
        Lives -= damage;
    }

    public void AddItem(IItem item)
    {
        Items.Add(item);
    }
}
using GameLib.Enums;
using GameLib.Interfaces;

namespace GameLib.Models;

public class Game
{
    private bool _active;
    private bool _playerHasWon;

    public Player Player { get; }
    public List<Room> Rooms { get; }
    public string Level { get; }

    private List<IGameObserver> observers = new();

    public bool Active
    {
        get => _active;
        private set
        {
            _active = value;
            NotifyObservers();
        }
    }

    public Game(Player player, List<Room> rooms, string level)
    {
        Player = player;
        Rooms = rooms;
        Level = level;
    }

    public int StonesNeeded { get; private set; } = 5;

    public void Move(Direction direction)
    {
        Player.Move(direction);
        
        Player.Room.MoveEnemies();

        if (Player.Room.HasEnemy(Player.Coords))
        {
            Player.TakeDamage(1);
        }
        
        if (Player.Stones >= StonesNeeded)
        {
            Active = true;
            _playerHasWon = true;
        }

        if (Player.Lives <= 0)
        {
            Active = true;
            _playerHasWon = false;
        }
        
        NotifyObservers();
    }
    
    
    public void Shoot()
    {
        Player.Room.Shoot(Player.Coords);
        NotifyObservers();
    }

    public void AddObserver(IGameObserver observer)
    {
        observers.Add(observer);
    }
  
    private void NotifyObservers()
    {
        foreach (IGameObserver observer in observers)
        {
            observer.Update(this);
        }
    }
    
    public bool PlayerHasWon()
    {
        return _playerHasWon;
    }
}
using Frontend.Tiles;
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models;

namespace Frontend;

public class GameView : IGameObserver
{
    public void Draw(Game game)
    {
        Player player = game.Player;
        Room room = game.Player.Room;

        Console.Clear();

        Console.WriteLine("Welcome to the Temple of Doom!");

        Console.WriteLine($"Current level: {game.Level}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine("\n");

        for (int y = 0; y < room.Height; y++)
        {
            for (int x = 0; x < room.Width; x++)
            {
                ITileView tileView = new EmptyTileView();

                if (player.IsOnCoords(new Coords(x, y)))
                {
                    tileView = new PlayerTileView();
                }
                else if (room.IsPartOfBorder(new Coords(x, y)))
                {
                    tileView = new BorderTileView();
                }
                else if (room.HasConnection(new Coords(x, y), out Direction direction, out Connection? connection))
                {
                    tileView = new DoorTileView(connection.Door, direction);
                }
                else if (room.HasItem(new Coords(x, y), out IItem item))
                {
                    tileView = new ItemTileView(item);
                }
                else if (room.HasPortal(new Coords(x, y)))
                {
                    tileView = new PortalTileView();
                }
                else if (room.HasSpecialFloor(new Coords(x, y), out IFloor floor))
                {
                    tileView = new FloorTile(floor);
                }
                else if (room.HasEnemy(new Coords(x, y)))
                {
                    tileView = new EnemyTileView();
                }

                tileView.Draw();
            }

            Console.WriteLine();
        }

        Console.WriteLine("\n");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Lives:  {player.Lives}");
        Console.WriteLine($"Stones: {player.Stones}/{game.StonesNeeded}");
        Console.WriteLine($"Keys:   {string.Join(", ", player.Keys)}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("A game for the course CODE (22/23) by Lars van Herwijnen and Mike de Groot");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("--------------------------------------------------");
    }

    public void Update(Game game)
    {
        Draw(game);
    }
}
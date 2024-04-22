using GameLib.Enums;
using GameLib.Models;

namespace Frontend;

public class InputReader
{
    
    private readonly Game _game;
    
    public InputReader(Game game)
    {
        _game = game;
    }

    public void Input()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.UpArrow:
                _game.Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                _game.Move(Direction.South);
                break;
            case ConsoleKey.LeftArrow:
                _game.Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                _game.Move(Direction.East);
                break;
            case ConsoleKey.Spacebar:
                _game.Shoot();
                break;
        }
    }
}
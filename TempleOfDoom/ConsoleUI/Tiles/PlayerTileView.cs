namespace Frontend.Tiles;

public class PlayerTileView : ITileView
{
    public char GetIcon()
    {
        return 'X';
    }
    public ConsoleColor GetColor()
    {
        return ConsoleColor.Cyan;
    }
}
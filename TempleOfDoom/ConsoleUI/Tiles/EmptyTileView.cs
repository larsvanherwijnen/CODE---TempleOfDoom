namespace Frontend.Tiles;

public class EmptyTileView : ITileView
{
    public char GetIcon()
    {
        return ' ';
    }

    public ConsoleColor GetColor()
    {
        return ConsoleColor.White;
    }
}
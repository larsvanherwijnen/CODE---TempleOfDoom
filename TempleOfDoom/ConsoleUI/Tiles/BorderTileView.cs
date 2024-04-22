namespace Frontend.Tiles;

public class BorderTileView : ITileView
{
    public char GetIcon()
    {
        return '#';
    }
    public ConsoleColor GetColor()
    {
        return ConsoleColor.Yellow;
    }
}
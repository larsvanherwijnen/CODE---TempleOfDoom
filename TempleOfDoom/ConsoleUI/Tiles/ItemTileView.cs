using GameLib.Decorators.ItemDecorators;
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models.Items;

namespace Frontend.Tiles;

public class ItemTileView : ITileView
{
    private readonly IItem _item;

    public ItemTileView(IItem item)
    {
        _item = item;
    }

    public char GetIcon()
    {
        return _item.GetItem() switch
        {
            KeyItem => 'K',
            SankaraStoneItem => 'S',
            BoobietrapItem => 'O',
            DisappearingItemDerocator => '@',
            PressurePlateItem => 'T',
            _ => ' '
        };
    }

    public ConsoleColor GetColor()
    {
        return _item.GetItem() switch
        {
            KeyItem keyItem => Enum.Parse<ConsoleColor>(keyItem.Color, true),
            SankaraStoneItem _ => ConsoleColor.Yellow,
            _ => ConsoleColor.White
        };
    }
}
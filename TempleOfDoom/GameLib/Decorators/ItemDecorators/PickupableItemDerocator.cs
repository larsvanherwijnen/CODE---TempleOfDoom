using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.ItemDecorators;

public class PickupableItemDerocator : BaseItemDecorator
{
    
    private readonly IItem _item;    
    public PickupableItemDerocator(IItem item) : base(item)
    {
        _item = item;
    }
    
    public override void Interaction(Player player)
    {
        base.Interaction(player);
        player.AddItem(_item);
    }
    

}
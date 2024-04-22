using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.ItemDecorators;

public class DisappearingItemDerocator: BaseItemDecorator
{
    public DisappearingItemDerocator(IItem item) : base(item)
    {
    }
    
    public override void Interaction(Player player)
    {
        base.Interaction(player);
        Visible = false;
    }
}
using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.ItemDecorators;

public class DamageItemDecorator : BaseItemDecorator
{
    private int _damage { get; }
    
    public DamageItemDecorator(IItem item, int damage) : base(item)
    {
        _damage = damage;
    }
    
    public override void Interaction(Player player)
    {
        player.TakeDamage(_damage);
    }
}
using GameLib.Enums;
using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.ItemDecorators;

public class BaseItemDecorator : IItem
{
    private IItem _decoratee;
    public BaseItemDecorator(IItem item)
    {
        _decoratee = item;
    }
    
    public virtual Coords Coords
    {
        get => _decoratee.Coords;
        set => _decoratee.Coords = value;
    }
    
    public bool Visible
    {
        get => _decoratee.Visible;
        set => _decoratee.Visible = value;
    }
    public virtual void Interaction(Player player)
    {
        _decoratee.Interaction(player);
    }
    
    public IItem GetItem()
    {
        return _decoratee.GetItem();
    }
}
using System.Drawing;
using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.DoorDecorators;

public class BaseDoorDecorator : IDoor
{
    public readonly IDoor _decoratee;
    public BaseDoorDecorator(IDoor decoratee)
    {
        _decoratee = decoratee;
    }
    public virtual bool IsOpen(Player player) => _decoratee.IsOpen(player);

    public virtual void AfterUse(Player player) => _decoratee.AfterUse(player);
    public virtual string GetColor() => _decoratee.GetColor();
    
    public virtual void Toggle()
    {
        _decoratee.Toggle();
    }

}
using System.Drawing;
using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.DoorDecorators;

public class ColoredDoorDecorator : BaseDoorDecorator
{
    private readonly string _color;

    private readonly IDoor _decoratee;
    public ColoredDoorDecorator(IDoor decoratee, string color) : base(decoratee)
    {
        _decoratee = decoratee;
        _color = color;
    }

    public override bool IsOpen(Player player)
    {
        bool hasKey = player.Keys.Contains(_color);

        if (_decoratee is Door)
        {
            return hasKey;
        }
        
        return hasKey && _decoratee.IsOpen(player);
    }

    public override void AfterUse(Player player)
    {
    }
    
    public override string GetColor() => _color;
}
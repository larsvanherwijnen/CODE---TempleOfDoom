using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.DoorDecorators;

public class OpenOnOddDecorator : BaseDoorDecorator
{
    private readonly IDoor _decoratee;

    public OpenOnOddDecorator(IDoor decoratee) : base(decoratee)
    {
        _decoratee = decoratee;
    }

    public override bool IsOpen(Player player)
    {
        bool odd = player.Lives % 2 == 1;
        
        if (_decoratee is Door)
        {
            return odd;
        }

        return odd && _decoratee.IsOpen(player);
    }

    public override void AfterUse(Player player)
    {
    }
}
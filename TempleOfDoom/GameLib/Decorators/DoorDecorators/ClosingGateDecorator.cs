using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.DoorDecorators;

public class ClosingGateDecorator : BaseDoorDecorator
{
    private bool _open;
    private readonly IDoor _decoratee;

    public ClosingGateDecorator(IDoor decoratee) : base(decoratee)
    {
        _decoratee = decoratee;
        _open = true;
    }

    public override bool IsOpen(Player player)
    {
        if (_decoratee is Door)
        {
            return _open;
        }
        
        return _open && _decoratee.IsOpen(player);
    }

    public override void AfterUse(Player player)
    {
        _open = false;
    }
}
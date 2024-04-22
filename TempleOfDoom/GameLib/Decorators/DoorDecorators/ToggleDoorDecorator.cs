using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.DoorDecorators;

public class ToggleDoorDecorator : BaseDoorDecorator
{
    private readonly IDoor _decoratee;
    private bool _open;
    public ToggleDoorDecorator(IDoor decoratee) : base(decoratee)
    {
        _decoratee = decoratee;
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
    }

    public override void Toggle()
    {
        _open = !_open;
    }
}
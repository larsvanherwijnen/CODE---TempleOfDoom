using GameLib.Interfaces;
using GameLib.Models;

namespace GameLib.Decorators.DoorDecorators;

public class OpenOnStonesInRoomDecorator : BaseDoorDecorator
{
    private readonly int _numberOfStones;
    private readonly IDoor _decoratee;
    public OpenOnStonesInRoomDecorator(IDoor decoratee, int numberOfStones) : base(decoratee)
    {
        _decoratee = decoratee;
        _numberOfStones = numberOfStones;
    }

    public override bool IsOpen(Player player)
    {
        bool hasRequiredStones = player.Room.GetStonesInRoom() == _numberOfStones;
    
        if (_decoratee is Door)
        {
            return hasRequiredStones;
        }
        
        return hasRequiredStones && _decoratee.IsOpen(player);
    }

    public override void AfterUse(Player player)
    {
    }
}
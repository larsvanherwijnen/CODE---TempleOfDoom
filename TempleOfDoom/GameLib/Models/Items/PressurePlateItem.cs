using GameLib.Interfaces;

namespace GameLib.Models.Items;

public class PressurePlateItem : IItem
{
    public Coords Coords { get; set; }
    public bool Visible { get; set; } = true;
    
    public PressurePlateItem(Coords coords)
    {
        Coords = coords;
    }
    public void Interaction(Player player)
    {
        player.Room.ToggleToggleDoors();
    }
}
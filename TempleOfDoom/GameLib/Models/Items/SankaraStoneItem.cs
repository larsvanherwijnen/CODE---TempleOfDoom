using GameLib.Interfaces;

namespace GameLib.Models.Items;

public class SankaraStoneItem : IItem
{
    public Coords Coords { get; set; }
    public bool Visible { get; set; } = true;
    
    public SankaraStoneItem(Coords coords)
    {
        Coords = coords;
    }
    public void Interaction(Player player)
    {
    }
}
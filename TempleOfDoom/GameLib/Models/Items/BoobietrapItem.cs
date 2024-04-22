using GameLib.Interfaces;

namespace GameLib.Models.Items;

public class BoobietrapItem : IItem
{
    public Coords Coords { get; set; }
    public bool Visible { get; set; }  = true;
    
    public BoobietrapItem(Coords coords)
    {
        Coords = coords;
    }
    public void Interaction(Player player)
    {
        
    }
}
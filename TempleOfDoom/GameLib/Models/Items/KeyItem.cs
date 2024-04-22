using GameLib.Interfaces;

namespace GameLib.Models.Items;

public class KeyItem : IItem
{
    public Coords Coords { get; set; }
    public bool Visible { get; set; } = true;
    public string Color { get; set; }
    
    public KeyItem(Coords coords, string color)
    {
        Coords = coords;
        Color = color;
    }
    public void Interaction(Player player)
    {
    }
}
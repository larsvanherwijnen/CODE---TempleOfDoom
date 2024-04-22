using System.Net;
using GameLib.Enums;
using GameLib.Models;

namespace GameLib.Interfaces;

public interface IItem
{
    Coords Coords { get; set; }
    bool Visible { get; set; }
    public void Interaction(Player player);
    
    IItem GetItem()
    {
        return this;
    }
}
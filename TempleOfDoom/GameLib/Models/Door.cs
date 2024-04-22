using System.Drawing;
using GameLib.Interfaces;

namespace GameLib.Models;

public class Door : IDoor
{
    public bool Open { get; set; }
    public Door(bool isOpen)
    {
        Open = isOpen;
    }
    public bool IsOpen(Player player)
    {
        return Open;
    }

    public void AfterUse(Player player)
    {
        Open = !Open;
    }
    public string GetColor() => "white";

    public void Toggle() {}
}
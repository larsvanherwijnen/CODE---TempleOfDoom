using System.Drawing;
using GameLib.Models;

namespace GameLib.Interfaces;

public interface IDoor
{
    bool IsOpen(Player player);

    void AfterUse(Player player);
    public string GetColor();
    public void Toggle();
}
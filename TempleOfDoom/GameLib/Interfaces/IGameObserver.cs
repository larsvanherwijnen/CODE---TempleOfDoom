using GameLib.Models;

namespace GameLib.Interfaces;

public interface IGameObserver
{
    void Update(Game game);
}
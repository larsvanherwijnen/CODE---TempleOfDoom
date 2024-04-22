using CODE_TempleOfDoom_DownloadableContent;
using GameLib.Models;

namespace GameLib.Adapters;

public class EnemyAdapter
{
    private readonly Enemy _enemy;
    public int Lives => _enemy.NumberOfLives;

    public EnemyAdapter(Enemy enemy)
    {
        _enemy = enemy;
    }
    
    public void Move()
    {
        _enemy.CurrentField = new Field();
        _enemy.Move();
    }
    
    public Coords GetCurrentCoords()
    {
        return new Coords(_enemy.CurrentXLocation, _enemy.CurrentYLocation);
    }
    
    public void SetCurrentCoords(Coords coords)
    {
        _enemy.CurrentXLocation = coords.X;
        _enemy.CurrentYLocation = coords.Y;
    }
    
    
    public void TakeDamage()
    {
        _enemy.DoDamage(1);
    }
}
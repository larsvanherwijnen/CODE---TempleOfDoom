using CODE_TempleOfDoom_DownloadableContent;
using DataReader.DTO;
using GameLib.Adapters;


namespace DataReader.Factories;

public class EnemyFactory
{
    private const int EnemyLives = 1;

    public EnemyAdapter CreateEnemy(EnemiesDto enemy)
    {
        switch (enemy.type)
        {
            case "horizontal":
                return new EnemyAdapter(new HorizontallyMovingEnemy(EnemyLives, enemy.x, enemy.y, enemy.minX, enemy.minY));
            case "vertical":
                return new EnemyAdapter(new VerticallyMovingEnemy(EnemyLives, enemy.x, enemy.y, enemy.minX, enemy.minY));
            default:
                throw new NotImplementedException("This enemy has not been implemented yet");
        }
    }
}
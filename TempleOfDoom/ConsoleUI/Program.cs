using DataReader;
using DataReader.Factories;
using Frontend;
using GameLib.Models;
using Microsoft.Extensions.DependencyInjection;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddSingleton<RoomFactory>()
    .AddSingleton<ItemFactory>()
    .AddSingleton<DoorFactory>()
    .AddSingleton<FloorFactory>()
    .AddSingleton<EnemyFactory>()
    .AddSingleton<GameReader>()
    .BuildServiceProvider();

GameReader reader = serviceProvider.GetService<GameReader>();

Game game = reader.Read(@"./Levels/TempleOfDoom_Extended_B_2122.json");

InputReader inputView = new InputReader(game);
GameView gameView = new GameView();

game.AddObserver(gameView);
gameView.Draw(game);

while (!game.Active)
{
    inputView.Input();
}

Console.Clear();

Console.WriteLine($"You {(game.PlayerHasWon() ? "won the game!" : "have died PANCAKE!")} ");

Console.WriteLine("Thanks for playing Temple of Doom");
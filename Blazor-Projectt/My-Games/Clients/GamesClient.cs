using My_Games.Models;
namespace My_Games.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = [

        new(){
        Id = 1,
        Name = "Cyberpunk 2077",
        Genre = "RPG",
        Price = 59.99M,
        Release_Date = new DateOnly(2020, 12, 10)
        },
        new(){
        Id = 2,
        Name = "The Witcher 3: Wild Hunt",
        Genre = "RPG",
        Price = 29.99M,
        Release_Date = new DateOnly(2015, 5, 19)
        },
        new(){
        Id = 3,
        Name = "The Elder Scrolls V: Skyrim",
        Genre = "RPG",
        Price = 19.99M,
        Release_Date = new DateOnly(2011, 11, 11)
}
];

public GameSummary[] GetGames() => [.. games];

};



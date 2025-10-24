
using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpoint = nameof(GetGameEndpoint);

List<Game> games =
[
  new Game
    {
        Id = Guid.NewGuid(),
        Name = "The Witcher 3",
        Genre = "RPG",
        Price = 59.99M,
        ReleaseDate = DateOnly.FromDateTime(new DateTime(2015, 5, 19))
    },
  new Game
    {
        Id = Guid.NewGuid(),
        Name = "Red Dead Redemption 2",
        Genre = "Action-Adventure",
        Price = 59.99M,
        ReleaseDate = DateOnly.FromDateTime(new DateTime(2018, 10, 26))
    },
  new Game
    {
        Id = Guid.NewGuid(),
        Name = "The Legend of Zelda: Breath of the Wild",
        Genre = "Adventure",
        Price = 59.99M,
        ReleaseDate = DateOnly.FromDateTime(new DateTime(2017, 3, 3))
    },
  new Game
    {
        Id = Guid.NewGuid(),
        Name = "Minecraft",
        Genre = "Sandbox",
        Price = 0,
        ReleaseDate = DateOnly.FromDateTime(new DateTime(2011, 11, 18))
    },
  new Game
    {
        Id = Guid.NewGuid(),
        Name = "Fortnite",
        Genre = "Battle Royal",
        Price = 0,
        ReleaseDate = DateOnly.FromDateTime(new DateTime(2017, 7, 17))
    }
];

// app.MapGet("/", () => "Hello World!");
app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (Guid id) =>
{
    Game? game = games.Find(g => g.Id == id);
    
    if (game == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(game);
}).WithName(GetGameEndpoint);

app.MapPost("/games", (Game game) =>
{
    game.Id = Guid.NewGuid();
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpoint, new { id = game.Id }, game);
}).WithParameterValidation();

app.MapPut("/games/{id}", (Guid id, Game game) =>
{
    Game? existingGame = games.Find(g => g.Id == id);
    if (existingGame == null)
    {
        return Results.NotFound();
    }

    existingGame.Name = game.Name;
    existingGame.Genre = game.Genre;
    existingGame.Price = game.Price;
    existingGame.ReleaseDate = game.ReleaseDate;
    // return Results.CreatedAtRoute(GetGameEndpoint, new { id = existingGame.Id }, existingGame);
    return Results.NoContent();
});

app.MapDelete("/games/{id}", (Guid id) =>
{
    Game? game = games.Find(g => g.Id == id);
    if (game == null)
    {
        return Results.NotFound();
    }

    games.Remove(game);
    return Results.NoContent();
});


app.Run();

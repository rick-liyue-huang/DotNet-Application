using API.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = nameof(GetGameEndpointName);

List<Game> games =
[
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Witcher 3",
    Genre = "RPG",
    Price = 59.99M,
    ReleaseDate = new DateOnly(2015, 5, 19)
  },
  new Game 
  {
    Id = Guid.NewGuid(),
    Name = "Red Dead Redemption 2",
    Genre = "Action-Adventure",
    Price = 59.99M,
    ReleaseDate = new DateOnly(2019, 10, 26)
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Legend of Zelda: Breath of the Wild",
    Genre = "Adventure",
    Price = 59.99M,
    ReleaseDate = new DateOnly(2017, 3, 3)
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Call of Duty: Infinite Warfare",
    Genre = "First-Person Shooter",
    Price = 59.99M,
    ReleaseDate = new DateOnly(2016, 9, 13)
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Grand Theft Auto V",
    Genre = "Action-Adventure",
    Price = 59.99M,
    ReleaseDate = new DateOnly(2013, 9, 17)
  },
];

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (Guid id) =>
{
  Game? game = games.Find(g => g.Id == id);

  if (game is null)
  {
    return Results.NotFound();
  }
  else
  {
    return Results.Ok(game);
  }
}).WithName(GetGameEndpointName);

app.MapPost("/games", (Game game) =>
{
  game.Id = Guid.NewGuid();
  games.Add(game);
  return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
}).WithParameterValidation();


app.MapPut("/games/{id}", (Guid id, Game game) =>
{
  Game? existingGame = games.Find(g => g.Id == id);
  if (existingGame is null)
  {
    return Results.NotFound();
  }
  else
  {
    existingGame.Name = game.Name;
    existingGame.Genre = game.Genre;
    existingGame.Price = game.Price;
    existingGame.ReleaseDate = game.ReleaseDate;
    return Results.NoContent();
  }
}).WithParameterValidation();

app.MapDelete("/games/{id}", (Guid id) =>
{
  Game? game = games.Find(g => g.Id == id);
  if (game is null)
  {
    return Results.NotFound();
  }
  else
  {
    games.Remove(game);
  }
  return Results.NoContent();
});

app.Run();

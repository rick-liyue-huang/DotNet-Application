using API.Models;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

const string GetNameEndpointName = "/games/{id}";

List<Game> games =
[
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Witcher 3",
    Genre = "RPG",
    Price = 19.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Red Dead Redemption 2",
    Genre = "Action-Adventure",
    Price = 29.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Elder Scrolls V: Skyrim",
    Genre = "RPG",
    Price = 59.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  },
  new Game {
    Id = Guid.NewGuid(),
    Name = "Fallout 4",
    Genre = "Action-Adventure",
    Price = 39.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  }
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (Guid id) =>
{
  Game? game = games.FirstOrDefault(g => g.Id == id);
  return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetNameEndpointName);

// POST /games
app.MapPost("/games", (Game game) =>
{
  game.Id = Guid.NewGuid();
  games.Add(game);
  // return Results.Created($"/games/{game.Id}", game);
  return Results.CreatedAtRoute(GetNameEndpointName, new { id = game.Id }, game);
}).WithParameterValidation();


// PUT /games/{id}
app.MapPut("/games/{id}", (Guid id, Game game) =>
{
  Game? existingGame = games.FirstOrDefault(g => g.Id == id);
  if (existingGame is null)
  {
    return Results.NotFound();
  }

  existingGame.Name = game.Name;
  existingGame.Genre = game.Genre;
  existingGame.Price = game.Price;
  existingGame.ReleaseDate = game.ReleaseDate;
  return Results.NoContent();

}).WithParameterValidation();

// DELETE /games/{id}
app.MapDelete("/games/{id}", (Guid id) =>
{
  Game? game = games.FirstOrDefault(g => g.Id == id);
  if (game is null)
  {
    return Results.NotFound();
  }

  games.Remove(game);
  return Results.NoContent();
});

app.Run();

using API.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

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

app.Run();

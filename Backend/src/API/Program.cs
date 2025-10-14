using API.Dtos;
using API.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = nameof(GetGameEndpointName);

List<Genre> genres =
[
  new Genre
  {
    Id = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
    Name = "Action"
  },
  new Genre
  {
    Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
    Name = "Adventure"
  },
  new Genre
  {
    Id = new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"),
    Name = "RPG"
  },
  new Genre
  {
    Id = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
    Name = "First-Person Shooter"
  },
];


List<Game> games =
[
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Witcher 3",
    Genre = genres[0],
    Price = 59.99M,
    ReleaseDate = new DateOnly(2015, 5, 19), 
    Description = "A story-driven, action-adventure RPG set in the fictional kingdom of Sildur."
  },
  new Game 
  {
    Id = Guid.NewGuid(),
    Name = "Red Dead Redemption 2",
    Genre = genres[1],
    Price = 59.99M,
    ReleaseDate = new DateOnly(2019, 10, 26),
    Description = "A third-person, action-adventure game set in a post-apocalyptic world."
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Legend of Zelda: Breath of the Wild",
    Genre = genres[1],
    Price = 59.99M,
    ReleaseDate = new DateOnly(2017, 3, 3), 
    Description = "A 3D action-adventure game set in the fictional kingdom of Hyrule."
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Call of Duty: Infinite Warfare",
    Genre = genres[2],
    Price = 59.99M,
    ReleaseDate = new DateOnly(2016, 9, 13), 
    Description = "A first-person shooter game set in a post-apocalyptic world."
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Grand Theft Auto V",
    Genre = genres[3],
    Price = 59.99M,
    ReleaseDate = new DateOnly(2013, 9, 17), 
    Description = "A third-person, action-adventure game set in the fictional city of Los Santos."
  },
];

app.MapGet("/games", () => games.Select(g => new GameSummaryDto(
  g.Id,
  g.Name,
  g.Genre.Name,
  g.Price,
  g.ReleaseDate
)));

app.MapGet("/games/{id}", (Guid id) =>
{
  Game? game = games.Find(g => g.Id == id);

  if (game is null)
  {
    return Results.NotFound();
  }
  else
  {
    return Results.Ok(new GameDetailsDto(
      game.Id,
      game.Name,
      game.Genre.Id,
      game.Price,
      game.ReleaseDate,
      game.Description
    ));
  }
}).WithName(GetGameEndpointName);

app.MapPost("/games", (CreateGameDto gameDto) =>
{
  var genre = genres.Find(g => g.Id == gameDto.GenreId);

  if (genre is null)
  {
    return Results.BadRequest("Invalid genre.");
  }

  var game = new Game
  {
    Id = Guid.NewGuid(),
    Name = gameDto.Name,
    Genre = genre,
    Price = gameDto.Price,
    ReleaseDate = gameDto.ReleaseDate,
    Description = gameDto.Description
  };
  games.Add(game);

  return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, new GameDetailsDto(
    game.Id,
    game.Name,
    game.Genre.Id,
    game.Price,
    game.ReleaseDate,
    game.Description
  ));

}).WithParameterValidation();


app.MapPut("/games/{id}", (Guid id, UpdateGameDto gameDto) =>
{
  var existingGame = games.Find(g => g.Id == id);
  if (existingGame is null)
  {
    return Results.NotFound();
  }

  var genre = genres.Find(g => g.Id == gameDto.GenreId);

  if (genre is null)
  {
    return Results.BadRequest("Invalid genre.");
  }
  
  existingGame.Name = gameDto.Name;
  existingGame.Genre = genre;
  existingGame.Price = gameDto.Price;
  existingGame.ReleaseDate = gameDto.ReleaseDate;
  existingGame.Description = gameDto.Description;

  return Results.NoContent();
  
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


app.MapGet("/genres", () => genres.Select(g => new GenreDto(g.Id, g.Name)));

app.Run();

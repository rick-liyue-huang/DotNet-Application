
using API.Models;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string getGameEndpoint = nameof(getGameEndpoint);

List<Genre> genres =
[
  new Genre
  {
    Id = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
    Name = "Action-Adventure"
  },
  new Genre
  {
    Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
    Name = "Adventure"
  },
  new Genre
  {
    Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
    Name = "RPG"
  },
  new Genre
  {
    Id = new Guid("8f6b3c1f-4e2a-4b3c-9d7e-3f2a1b4c5d6e"),
    Name = "Sandbox"
  },
  new Genre
  {
    Id = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-e1f2a3b4c5d6"),
    Name = "Battle Royal"
  }
];

List<Game> games =
[
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Witcher 3",
    Genre = genres[2],
    Price = 59.99M,
    ReleaseDate = DateOnly.FromDateTime(new DateTime(2015, 5, 19)),
    Description =
      "The Witcher 3 is a 2015 action-adventure game developed by CD Projekt Red and published by CD Projekt Red."
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Red Dead Redemption 2",
    Genre = genres[0],
    Price = 59.99M,
    ReleaseDate = DateOnly.FromDateTime(new DateTime(2018, 10, 26)),
    Description =
      "Red Dead Redemption 2 is a 2018 action-adventure game developed by Rockstar North and published by Rockstar Games."
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Legend of Zelda: Breath of the Wild",
    Genre = genres[1],
    Price = 59.99M,
    ReleaseDate = DateOnly.FromDateTime(new DateTime(2017, 3, 3)),
    Description =
      "The Legend of Zelda: Breath of the Wild is a 2017 action-adventure game developed by Nintendo and published by Nintendo."
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Minecraft",
    Genre = genres[3],
    Price = 0,
    ReleaseDate = DateOnly.FromDateTime(new DateTime(2011, 11, 18)),
    Description = "Minecraft is a sandbox video game developed by Mojang Studios and published by Mojang Studios."
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Fortnite",
    Genre = genres[4],
    Price = 0,
    ReleaseDate = DateOnly.FromDateTime(new DateTime(2017, 7, 17)),
    Description =
      "Fortnite is a multiplayer online battle royale video game developed by Epic Games and published by Epic Games."
  }
];

// app.MapGet("/", () => "Hello World!");
app.MapGet("/games", 
  () => games.Select(
    game => new GameSummaryDto(
      game.Id, 
      game.Name, 
      game.Genre.Name, 
      game.Price, 
      game.ReleaseDate, 
      game.Description)
    )
  );

app.MapGet("/games/{id}", (Guid id) =>
{
  Game? game = games.Find(g => g.Id == id);

  if (game == null)
  {
    return Results.NotFound();
  }

  return Results.Ok(
    new GameDetailsDto(
      game.Id,
      game.Name,
      game.Genre.Id,
      game.Price,
      game.ReleaseDate,
      game.Description
    )
  );

}).WithName(getGameEndpoint);

app.MapPost("/games", (CreateGameDto gameDto) =>
{

  var genre = genres.Find(g => g.Id == gameDto.GenreId);
  if (genre == null)
  {
    return Results.BadRequest("Invalid genre");
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
  return Results.CreatedAtRoute(getGameEndpoint, new { id = game.Id }, new GameDetailsDto(
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

  var genre = genres.Find(g => g.Id == gameDto.GenreId);
  if (genre == null)
  {
    return Results.BadRequest("Invalid genre");
  }
  
  Game? existingGame = games.Find(g => g.Id == id);
  if (existingGame == null)
  {
    return Results.NotFound();
  }

  existingGame.Name = gameDto.Name;
  existingGame.Genre = genre;
  existingGame.Price = gameDto.Price;
  existingGame.ReleaseDate = gameDto.ReleaseDate;
  existingGame.Description = gameDto.Description;
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

app.MapGet("/genres", () => genres.Select(genre => new GenreDto(genre.Id, genre.Name)));


app.Run();


public record GameDetailsDto(
  Guid Id,
  string Name,
  Guid GenreId,
  decimal Price,
  DateOnly ReleaseDate,
  string Description
);

public record GameSummaryDto(
  Guid Id,
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate,
  string Description
);

public record CreateGameDto(
  [Required][StringLength(100)]
  string Name,
  Guid GenreId,
  [Range(0, 10000)]
  decimal Price,
  DateOnly ReleaseDate,
  [Required][StringLength(1000)]
  string Description
);

public record UpdateGameDto(
  [Required][StringLength(100)]
  string Name,
  Guid GenreId,
  [Range(0, 10000)]
  decimal Price,
  DateOnly ReleaseDate,
  [Required][StringLength(1000)]
  string Description
);

public record GenreDto(
  Guid Id,
  string Name
);
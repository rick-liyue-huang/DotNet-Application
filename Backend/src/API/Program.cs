using API.Models;
using API.Dtos;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

const string GetNameEndpointName = "/games/{id}";

List<Genre> genres =
[
  new Genre
  {
    Id = new Guid("585d475f-e82d-48bb-bf1a-be3717f70c7b"),
    Name = "Action-Adventure"
  },
  new Genre
  {
    Id = new Guid("f7f5c0c9-b5c7-4f0d-a5c5-f7f5c0c9b5c7"),
    Name = "RPG"
  },
  new Genre{
    Id = new Guid("f7f5c0c9-b5c7-4f0d-a5c5-f7f5c0c9b5c8"),
    Name = "Shooter"
  },
  new Genre{
    Id = new Guid("f7f5c0c9-b5c7-4f0d-a5c5-f7f5c0c9b5c9"),
    Name = "Strategy"
  }
];

List<Game> games =
[
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Witcher 3",
    Description = "The Witcher is an action-adventure RPG set in a world where merpeople, dragons, and other fantastic beasts roam the world. You play Geralt of Rivia, a monster slayer who travels the world in search of a child who has been turned into a monster by a cruel sorcerer.",
    Genre = genres[0],
    Price = 19.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "Red Dead Redemption 2",
    Description = "Red Dead Redemption 2 is an action-adventure game set in a world where the main character, Arthur Morgan, is a member of the Van der Linde gang. He must deal with the other members of the gang, the authorities, and the elements of the game world.",
    Genre = genres[3],
    Price = 29.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  },
  new Game
  {
    Id = Guid.NewGuid(),
    Name = "The Elder Scrolls V: Skyrim",
    Description = "The Elder Scrolls V: Skyrim is an action-adventure game set in a world where the main character, player character, is a werewolf. He must deal with the other members of the werewolf pack, the authorities, and the elements of the game world.",
    Genre = genres[2],
    Price = 59.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  },
  new Game {
    Id = Guid.NewGuid(),
    Name = "Fallout 4",
    Description = "Fallout 4 is an action-adventure game set in a world where the main character, player character, is a werewolf. He must deal with the other members of the werewolf pack, the authorities, and the elements of the game world.",
    Genre = genres[1],
    Price = 39.99m,
    ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
  }
];

// GET /games
app.MapGet("/games", () => {
  return Results.Ok(
    games.Select(game => new GameSummaryDto(
      game.Id,
      game.Name,
      game.Genre.Name,
      game.Price,
      game.ReleaseDate
    ))
  );
});

// GET /games/{id}
app.MapGet("/games/{id}", (Guid id) =>
{
  Game? game = games.FirstOrDefault(g => g.Id == id);
  return game is null ? Results.NotFound() : Results.Ok(
    new GameDetailsDto(
      game.Id,
      game.Name,
      game.Description,
      game.Genre.Id,
      game.Price,
      game.ReleaseDate
    )
  );
}).WithName(GetNameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto gameDto) =>
{
  var genre = genres.FirstOrDefault(g => g.Id == gameDto.GenreId);
  if (genre is null)
  {
    return Results.BadRequest("Invalid genre");
  }
  var game = new Game
  {
    Id = Guid.NewGuid(),
    Name = gameDto.Name,
    Description = gameDto.Description,
    Genre = genre,
    Price = gameDto.Price,
    ReleaseDate = gameDto.ReleaseDate
  };
  games.Add(game);
  // return Results.Created($"/games/{game.Id}", game);
  return Results.CreatedAtRoute(GetNameEndpointName, new { id = game.Id }, new GameDetailsDto(
    game.Id,
    game.Name,
    game.Description,
    game.Genre.Id,
    game.Price,
    game.ReleaseDate
  ));
}).WithParameterValidation();


// PUT /games/{id}
app.MapPut("/games/{id}", (Guid id, UpdateGameDto gameDto) =>
{
  Game? existingGame = games.FirstOrDefault(g => g.Id == id);
  if (existingGame is null)
  {
    return Results.NotFound();
  }

  var genre = genres.FirstOrDefault(g => g.Id == gameDto.GenreId);
  if (genre is null)
  {
    return Results.BadRequest("Invalid genre");
  }

  existingGame.Name = gameDto.Name;
  existingGame.Genre = genre;
  existingGame.Price = gameDto.Price;
  existingGame.ReleaseDate = gameDto.ReleaseDate;
  existingGame.Description = gameDto.Description;
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


// GET /genres
app.MapGet("/genres", () => {
  return Results.Ok(
    genres.Select(genre => new GenreDto(
      genre.Id,
      genre.Name
    ))
  );
});

app.Run();

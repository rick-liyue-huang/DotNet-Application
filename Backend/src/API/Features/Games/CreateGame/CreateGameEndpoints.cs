using API.Data;
using API.Features.Games.Constants;
using API.Models;

namespace API.Features.Games.CreateGameEndpoint;

public static class CreateGameEndpoints
{
  public static void MapCreateGame(this IEndpointRouteBuilder app, GameStoreData data)
  { 
    app.MapPost("/", (CreateGameDto gameDto) =>
      {
        // var genre = genres.FirstOrDefault(g => g.Id == gameDto.GenreId);
        var genre = data.GetGenreById(gameDto.GenreId);
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
        // games.Add(game);
        data.AddGame(game);

        // return Results.Created($"/games/{game.Id}", game);
        return Results.CreatedAtRoute(EndpointNames.GetNameEndpointName, new { id = game.Id }, new GameDetailsDto(
          game.Id,
          game.Name,
          game.Description,
          game.Genre.Id,
          game.Price,
          game.ReleaseDate
        ));
      }).WithParameterValidation();
  }
}

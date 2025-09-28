using API.Data;
using API.Features.Games.Constants;
using API.Features.Games.CreateGameEndpoint;
using API.Models;

namespace API.Features.Games.CreateGame;

public static class CreateGameEndpoints
{
  public static void MapCreateGame(this IEndpointRouteBuilder app/*, GameStoreData data*/)
  { 
    app.MapPost("/",
    async (
      CreateGameDto gameDto,
      // GameStoreData data,
      GameStoreContext gameStoreContext,
      GameDataLogger logger) =>
      {
        // var genre = genres.FirstOrDefault(g => g.Id == gameDto.GenreId);
        // var genre = data.GetGenreById(gameDto.GenreId);
        // if (genre is null)
        // {
        //   return Results.BadRequest("Invalid genre");
        // }
        
        var game = new Game
        {
          // Id = Guid.NewGuid(),
          Name = gameDto.Name,
          Description = gameDto.Description,
          // Genre = genre,
          GenreId = gameDto.GenreId,
          Price = gameDto.Price,
          ReleaseDate = gameDto.ReleaseDate
        };
        // games.Add(game);
        // data.AddGame(game);
        gameStoreContext.Games.Add(game);
        logger.PrintGames();
        await gameStoreContext.SaveChangesAsync();

        // return Results.Created($"/games/{game.Id}", game);
        return Results.CreatedAtRoute(EndpointNames.GetNameEndpointName, new { id = game.Id }, new GameDetailsDto(
          game.Id,
          game.Name,
          game.Description,
          game.GenreId,
          game.Price,
          game.ReleaseDate
        ));
      }).WithParameterValidation();
  }
}

using API.Data;
using API.Features.Games.Constants;
using API.Models;

namespace API.Features.Games.GetGameById;

public static class GetGameByIdEndpoint
{
  public static void MapGetGameById(this IEndpointRouteBuilder app/*, GameStoreData data*/)
  {
    app.MapGet("/{id}",
    async (
      // GameStoreData data,
      GameStoreContext gameStoreContext,
      Guid id) =>
    {
      // Game? game = games.FirstOrDefault(g => g.Id == id);
      // Game? game = data.GetGameById(id);
      // Game? game = gameStoreContext.Games.Find(id);
      // Task<Game?> findGameTask = gameStoreContext.Games.FindAsync(id).AsTask();
      Game? game = await gameStoreContext.Games.FindAsync(id);

      // return findGameTask.ContinueWith(task =>
      // {
      //   Game? game = task.Result;

      //   return game is null ? Results.NotFound() : Results.Ok(
      //     new GameDetailsDto(
      //       game.Id,
      //       game.Name,
      //       game.Description,
      //       game.GenreId,
      //       game.Price,
      //       game.ReleaseDate
      //     )
      //   );
      // });
      
      return game is null ? Results.NotFound() : Results.Ok(
        new GameDetailsDto(
          game.Id,
          game.Name,
          game.Description,
          game.GenreId,
          game.Price,
          game.ReleaseDate
        )
      );
    }).WithName(EndpointNames.GetNameEndpointName);
  }
}

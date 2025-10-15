
using API.Data;
using API.Features.Games.Constants;
using API.Models;


namespace API.Features.Games.GetGameById;

public static class GetGameByIdEndpoint
{
  public static void MapGetGameById(this IEndpointRouteBuilder app, GameStoreData data)
  {
    app.MapGet("/{id}", (Guid id) =>
    {
      Game? game = data.GetGameById(id);

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
    }).WithName(GameConstant.GetGameEndpointName);
  }
}

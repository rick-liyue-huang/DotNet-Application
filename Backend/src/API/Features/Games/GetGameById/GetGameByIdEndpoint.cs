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
    // Game? game = games.FirstOrDefault(g => g.Id == id);
      Game? game = data.GetGameById(id);
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
      }).WithName(EndpointNames.GetNameEndpointName);
  }
}

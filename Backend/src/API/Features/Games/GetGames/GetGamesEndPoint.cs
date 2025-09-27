using API.Data;

namespace API.Features.Games.GetGames;

public static class GetGamesEndPoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app, GameStoreData data)
    {
      app.MapGet("/", () => {
        return Results.Ok(
          data.GetGames().Select(game => new GameSummaryDto(
            game.Id,
            game.Name,
            game.Genre.Name,
            game.Price,
            game.ReleaseDate
          ))
        );
      });
    }
}

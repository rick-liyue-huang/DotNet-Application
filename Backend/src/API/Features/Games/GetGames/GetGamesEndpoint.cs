
using API.Data;

namespace API.Features.Games.GetGames;

public static class GetGamesEndpoint
{
  public static void MapGetGames(this IEndpointRouteBuilder app/*, GameStoreData data*/)
  {
    app.MapGet("/", 
      (GameStoreData data) => data.GetGames().Select(g => new GameSummaryDto(
        g.Id,
        g.Name,
        g.Genre.Name,
        g.Price,
        g.ReleaseDate
      )));
  }
}

using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Games.GetGames;

public static class GetGamesEndPoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app/*, GameStoreData data*/)
    {
      app.MapGet("/", async (
        // GameStoreData data
        GameStoreContext gameStoreContext
        ) => {
        return Results.Ok(
          await /*data.GetGames()*/gameStoreContext.Games
          .Include(game => game.Genre)
          .Select(game => new GameSummaryDto(
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
          )).AsNoTracking().ToListAsync()
        );
      });
    }
}

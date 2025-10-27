using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Games.GetGames;

public static class GetGamesEndpoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", 
            async (
                // GameStoreData data
                GameStoreContext dbContext
                ) => 
                // data.GetGames()
                await dbContext.Games
                    .Include(game => game.Genre)
                    .Select(game => new GameSummaryDto(
                        game.Id,
                        game.Name,
                        game.Genre!.Name,
                        game.Price,
                        game.ReleaseDate,
                        game.Description
                    )).AsNoTracking().ToListAsync());
    }
}
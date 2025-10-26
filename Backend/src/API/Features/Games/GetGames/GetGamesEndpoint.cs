using API.Data;

namespace API.Features.Games.GetGames;

public static class GetGamesEndpoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", 
            (GameStoreData data) => data.GetGames().Select(game => new GameSummaryDto(
                game.Id,
                game.Name,
                game.Genre.Name,
                game.Price,
                game.ReleaseDate,
                game.Description
            )));
    }
}
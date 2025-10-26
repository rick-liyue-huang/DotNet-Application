using API.Data;
using API.Features.Games.CreateGame;
using API.Features.Games.DeleteGameById;
using API.Features.Games.GetGameById;
using API.Features.Games.GetGames;
using API.Features.Games.UpdateGameById;

namespace API.Features.Games;

public static class GamesEndpoints
{
    // public static void MapGamesEndpoints(this IEndpointRouteBuilder app, GameStoreData data)
    public static void MapGamesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/games");
        
        group.MapGetGames();

        group.MapGetGameById();

        group.MapCreateGame();

        group.MapUpdateGameById();

        group.MapDeleteGameById();
    }
}
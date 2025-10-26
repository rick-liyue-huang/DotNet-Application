using API.Data;
using API.Features.Games.CreateGame;
using API.Features.Games.DeleteGameById;
using API.Features.Games.GetGameById;
using API.Features.Games.GetGames;
using API.Features.Games.UpdateGameById;

namespace API.Features.Games;

public static class GamesEndpoints
{
    public static void MapGamesEndpoints(this IEndpointRouteBuilder app, GameStoreData data)
    {
        var group = app.MapGroup("/games");
        
        group.MapGetGames(data);

        group.MapGetGameById(data);

        group.MapCreateGame(data);

        group.MapUpdateGameById(data);

        group.MapDeleteGameById(data);
    }
}
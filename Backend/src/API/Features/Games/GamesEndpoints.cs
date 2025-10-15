
using API.Data;
using API.Features.Games.CreateGame;
using API.Features.Games.DeleteGame;
using API.Features.Games.GetGameById;
using API.Features.Games.GetGames;
using API.Features.Games.UpdateGame;

namespace API.Features.Games;

public static class GamesEndpoints
{
  public static void MapGames(this IEndpointRouteBuilder app, GameStoreData data)
  {
    var group = app.MapGroup("/games");

    group.MapGetGames(data);

    group.MapGetGameById(data);

    group.MapCreateGame(data);

    group.MapUpdateGame(data);

    group.MapDeleteGame(data);
  }
}

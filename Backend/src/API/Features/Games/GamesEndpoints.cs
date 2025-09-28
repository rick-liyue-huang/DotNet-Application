using System;
using API.Data;
using API.Features.Games.CreateGameEndpoint;
using API.Features.Games.DeleteGame;
using API.Features.Games.GetGameById;
using API.Features.Games.GetGames;
using API.Features.Games.UpdateGame;

namespace API.Features.Games;

public static class GamesEndpoints
{
  public static void MapGamesEndpoints(this IEndpointRouteBuilder app/*, GameStoreData data*/)
  {

    var group = app.MapGroup("/games");
     // GET /games
    group.MapGetGames();

    // GET /games/{id}
    group.MapGetGameById();

    // POST /games
    group.MapCreateGame();

    // PUT /games/{id}
    group.MapUpdateGame();

    // DELETE /games/{id}
    group.MapDeleteGame();
  }

}

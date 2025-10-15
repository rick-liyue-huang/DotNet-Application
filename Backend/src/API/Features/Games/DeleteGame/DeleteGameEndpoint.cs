using System;
using API.Data;
using API.Models;

namespace API.Features.Games.DeleteGame;

public static class DeleteGameEndpoint
{
  public static void MapDeleteGame(this IEndpointRouteBuilder app, GameStoreData data)
  {
    app.MapDelete("/{id}", (Guid id) =>
    {
      Game? game = data.GetGameById(id);
      if (game is null)
      {
        return Results.NotFound();
      }
      else
      {
        data.RemoveGame(id);
      }
      return Results.NoContent();
    });

  }
}

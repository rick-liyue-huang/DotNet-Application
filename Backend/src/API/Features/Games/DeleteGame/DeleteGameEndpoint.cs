using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Games.DeleteGame;

public static class DeleteGameEndpoint
{
    public static void MapDeleteGame(this IEndpointRouteBuilder app)
    { 
      app.MapDelete("/{id}", (
        Guid id,
        // GameStoreData data
        GameStoreContext gameStoreContext
        ) =>
      {
        // data.RemoveGame(id);
        gameStoreContext.Games.Where(g => g.Id == id).ExecuteDelete();
        gameStoreContext.SaveChanges();
        return Results.NoContent();
      });
    }
}

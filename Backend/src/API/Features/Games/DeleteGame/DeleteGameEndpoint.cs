using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Games.DeleteGame;

public static class DeleteGameEndpoint
{
    public static void MapDeleteGame(this IEndpointRouteBuilder app)
    { 
      app.MapDelete("/{id}", async (
        Guid id,
        // GameStoreData data
        GameStoreContext gameStoreContext
        ) =>
      {
        // data.RemoveGame(id);
        await gameStoreContext.Games.Where(g => g.Id == id).ExecuteDeleteAsync();
        // await gameStoreContext.SaveChangesAsync();
        return Results.NoContent();
      });
    }
}

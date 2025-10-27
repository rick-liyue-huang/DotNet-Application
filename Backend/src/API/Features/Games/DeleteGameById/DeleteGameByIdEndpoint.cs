using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Games.DeleteGameById;

public static class DeleteGameByIdEndpoint
{
    public static void MapDeleteGameById(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", 
            async (
                Guid id, 
                // GameStoreData data
                GameStoreContext dbContext
                ) =>
        {
            // Game? game = data.GetGame(id);
            // Game? game = dbContext.Games.Find(id);
            // if (game == null)
            // {
            //     return Results.NotFound();
            // }

            // data.RemoveGame(id);
            dbContext.Games.Where(game => game.Id == id).ExecuteDelete();
            await dbContext.SaveChangesAsync();
            
            return Results.NoContent();
        });
    }
}
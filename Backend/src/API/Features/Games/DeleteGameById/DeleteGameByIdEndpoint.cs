using API.Data;
using API.Models;

namespace API.Features.Games.DeleteGameById;

public static class DeleteGameByIdEndpoint
{
    public static void MapDeleteGameById(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", (Guid id, GameStoreData data) =>
        {
            Game? game = data.GetGame(id);
            if (game == null)
            {
                return Results.NotFound();
            }

            data.RemoveGame(id);
            return Results.NoContent();
        });
    }
}
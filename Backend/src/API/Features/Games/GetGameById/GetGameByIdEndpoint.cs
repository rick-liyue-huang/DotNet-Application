using API.Data;
using API.Models;
using API.Features.Games.Constants;


namespace API.Features.Games.GetGameById;

public static class GetGameByIdEndpoint
{
    public static void MapGetGameById(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", 
            (
                Guid id, 
                // GameStoreData data
                GameStoreContext DbContext
                ) =>
        {
            // Game? game = data.GetGame(id);
            Game? game = DbContext.Games.Find(id);

            if (game == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(
                new GameDetailsDto(
                    game.Id,
                    game.Name,
                    game.GenreId,
                    game.Price,
                    game.ReleaseDate,
                    game.Description
                )
            );

        }).WithName(EndpointName.GetGameEndpoint);
    }
}
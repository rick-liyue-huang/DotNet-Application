using API.Data;
using API.Models;
using API.Features.Games.Constants;


namespace API.Features.Games.GetGameById;

public static class GetGameByIdEndpoint
{
    public static void MapGetGameById(this IEndpointRouteBuilder app, GameStoreData data)
    {
        app.MapGet("/{id}", (Guid id) =>
        {
            Game? game = data.GetGame(id);

            if (game == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(
                new GameDetailsDto(
                    game.Id,
                    game.Name,
                    game.Genre.Id,
                    game.Price,
                    game.ReleaseDate,
                    game.Description
                )
            );

        }).WithName(EndpointName.GetGameEndpoint);
    }
}
using API.Data;
using API.Models;

namespace API.Features.Games.UpdateGameById;

public static class UpdateGameByIdEndpoint
{
    public static void MapUpdateGameById(this IEndpointRouteBuilder app, GameStoreData data)
    {
        app.MapPut("/{id}", (Guid id, UpdateGameDto gameDto) =>
        {

            var genre = data.GetGenre(gameDto.GenreId);
            if (genre == null)
            {
                return Results.BadRequest("Invalid genre");
            }

            Game? existingGame = data.GetGame(id);
            if (existingGame == null)
            {
                return Results.NotFound();
            }

            existingGame.Name = gameDto.Name;
            existingGame.Genre = genre;
            existingGame.Price = gameDto.Price;
            existingGame.ReleaseDate = gameDto.ReleaseDate;
            existingGame.Description = gameDto.Description;
            // return Results.CreatedAtRoute(GetGameEndpoint, new { id = existingGame.Id }, existingGame);
            return Results.NoContent();
        });
    }
}
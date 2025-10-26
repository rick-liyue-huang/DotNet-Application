using API.Data;
using API.Models;

namespace API.Features.Games.UpdateGameById;

public static class UpdateGameByIdEndpoint
{
    public static void MapUpdateGameById(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", 
            (
                Guid id, 
                UpdateGameDto gameDto, 
                // GameStoreData data
                GameStoreContext DbContext
                ) =>
        {

            // var genre = data.GetGenre(gameDto.GenreId);
            // if (genre == null)
            // {
            //     return Results.BadRequest("Invalid genre");
            // }

            // Game? existingGame = data.GetGame(id);
            Game? existingGame = DbContext.Games.Find(id);
            if (existingGame == null)
            {
                return Results.NotFound();
            }

            existingGame.Name = gameDto.Name;
            // existingGame.Genre = genre;
            existingGame.GenreId = gameDto.GenreId;
            existingGame.Price = gameDto.Price;
            existingGame.ReleaseDate = gameDto.ReleaseDate;
            existingGame.Description = gameDto.Description;
            // return Results.CreatedAtRoute(GetGameEndpoint, new { id = existingGame.Id }, existingGame);
            
            DbContext.SaveChanges();
            
            return Results.NoContent();
        });
    }
}
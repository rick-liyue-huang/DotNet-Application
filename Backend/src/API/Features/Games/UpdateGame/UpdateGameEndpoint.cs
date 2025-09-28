using API.Data;
using API.Models;

namespace API.Features.Games.UpdateGame;

public static class UpdateGameEndpoint
{
  public static void MapUpdateGame(this IEndpointRouteBuilder app/*, GameStoreData data*/)
  {
    app.MapPut("/{id}", (
      Guid id,
      UpdateGameDto gameDto,
      GameStoreContext gameStoreContext
      // GameStoreData data
      ) =>
      {
        // Game? existingGame = games.FirstOrDefault(g => g.Id == id);
        // Game? existingGame = data.GetGameById(id);
        Game? existingGame = gameStoreContext.Games.Find(id);
        if (existingGame is null)
        {
          return Results.NotFound();
        }

        // var genre = genres.FirstOrDefault(g => g.Id == gameDto.GenreId);
        // var genre = data.GetGenreById(gameDto.GenreId);
        // if (genre is null)
        // {
        //   return Results.BadRequest("Invalid genre");
        // }

        existingGame.Name = gameDto.Name;
        // existingGame.Genre = genre;
        existingGame.GenreId = gameDto.GenreId;
        existingGame.Price = gameDto.Price;
        existingGame.ReleaseDate = gameDto.ReleaseDate;
        existingGame.Description = gameDto.Description;

        gameStoreContext.SaveChanges();
        
        return Results.NoContent();

      }).WithParameterValidation();
  }
}

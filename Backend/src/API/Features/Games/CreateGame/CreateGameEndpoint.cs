using API.Data;
using API.Features.Games.Constants;
using API.Models;

namespace API.Features.Games.CreateGame;

public static class CreateGameEndpoint
{
    public static void MapCreateGame(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", (CreateGameDto gameDto, GameStoreData data, GameDataLogger logger) =>
        {

            var genre = data.GetGenre(gameDto.GenreId);
            if (genre == null)
            {
                return Results.BadRequest("Invalid genre");
            }

            var game = new Game
            {
                Id = Guid.NewGuid(),
                Name = gameDto.Name,
                Genre = genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                Description = gameDto.Description
            };
    
            data.AddGame(game);
            logger.PrintGames();
            
            return Results.CreatedAtRoute(EndpointName.GetGameEndpoint,new { id = game.Id }, new GameDetailsDto(
                game.Id,
                game.Name,
                game.Genre.Id,
                game.Price,
                game.ReleaseDate,
                game.Description
            ));

        }).WithParameterValidation();
    }
}
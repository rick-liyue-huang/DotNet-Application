using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
    public static void MapGetGenres(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (/*GameStoreData data*/ GameStoreContext dbContext) => 
            // data.GetGenres()
            dbContext.Genres
                .Select(genre => new GenreDto(genre.Id, genre.Name))
                .AsNoTracking()
            );
    }
}
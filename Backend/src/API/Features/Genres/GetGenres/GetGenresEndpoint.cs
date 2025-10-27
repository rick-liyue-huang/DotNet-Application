using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
    public static void MapGetGenres(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (/*GameStoreData data*/ GameStoreContext dbContext) => 
            // data.GetGenres()
            await dbContext.Genres
                .Select(genre => new GenreDto(genre.Id, genre.Name))
                .AsNoTracking().ToListAsync()
            );
    }
}
using API.Data;
using API.Features.Genres.GetGenres;

namespace API.Features.Genres
{
    public static class GenresEndpoints
    {
      public static void MapGenresEndpoints(this IEndpointRouteBuilder app/*, GameStoreData data*/)
      {

        var group = app.MapGroup("/genres");
        // GET /genres
        group.MapGetGenres();
      }
    }
}
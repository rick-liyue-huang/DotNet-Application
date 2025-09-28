using System;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
  public static void MapGetGenres(this IEndpointRouteBuilder app/*, GameStoreData data*/)
  { 
    app.MapGet("/", (/*GameStoreData data*/GameStoreContext gameStoreContext) => {
      return Results.Ok(
        gameStoreContext.Genres.Select(genre => new GenreDto(
          genre.Id,
          genre.Name
        )).AsNoTracking()
      );
    });
  }
}

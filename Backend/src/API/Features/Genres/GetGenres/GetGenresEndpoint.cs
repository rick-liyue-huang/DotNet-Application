using System;
using API.Data;

namespace API.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
  public static void MapGetGenres(this IEndpointRouteBuilder app, GameStoreData data)
  { 
    app.MapGet("/", () => {
      return Results.Ok(
        data.GetGenres().Select(genre => new GenreDto(
          genre.Id,
          genre.Name
        ))
      );
    });
  }
}

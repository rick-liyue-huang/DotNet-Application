using System;

namespace API.Features.Games.GetGameById;

public record GameDetailsDto(
  Guid Id,
  string Name,
  string Description,
  Guid GenreId,
  decimal Price,
  DateOnly ReleaseDate
);

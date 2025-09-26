using System;

namespace API.Dtos;

public record GameDetailsDto(
  Guid Id,
  string Name,
  string Description,
  Guid GenreId,
  decimal Price,
  DateOnly ReleaseDate
);

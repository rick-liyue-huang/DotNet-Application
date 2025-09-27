using System;
using System.ComponentModel.DataAnnotations;

namespace API.Features.Games.CreateGameEndpoint;

public record CreateGameDto(
  [Required][MaxLength(50)]string Name,
  [Required][MaxLength(500)]string Description,
  Guid GenreId,
  [Range(1, 200)]decimal Price,
  DateOnly ReleaseDate
);

public record GameDetailsDto(
  Guid Id,
  string Name,
  string Description,
  Guid GenreId,
  decimal Price,
  DateOnly ReleaseDate
);

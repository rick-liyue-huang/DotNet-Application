using System;
using System.ComponentModel.DataAnnotations;

namespace API.Features.Games.CreateGame;

public record CreateGameDto(
  [Required][StringLength(50)]string Name,
  Guid GenreId,
  [Required][StringLength(500)]string Description,
  [Range(0, 1000)]decimal Price,
  DateOnly ReleaseDate
);

public record GameDetailsDto(
  Guid Id,
  string Name,
  Guid GenreId,
  decimal Price,
  DateOnly ReleaseDate,
  string Description
);



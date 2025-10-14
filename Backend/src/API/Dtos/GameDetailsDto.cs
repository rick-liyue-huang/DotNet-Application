
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public record GameDetailsDto(
  Guid Id,
  string Name,
  Guid GenreId,
  decimal Price,
  DateOnly ReleaseDate,
  string Description
);


public record GameSummaryDto(
  Guid Id,
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate
);


public record CreateGameDto(
  [Required][StringLength(50)]string Name,
  Guid GenreId,
  [Required][StringLength(500)]string Description,
  [Range(0, 1000)]decimal Price,
  DateOnly ReleaseDate
);

public record UpdateGameDto(
  [Required][StringLength(50)]string Name,
  Guid GenreId,
  [Required][StringLength(500)]string Description,
  [Range(0, 1000)]decimal Price,
  DateOnly ReleaseDate
);
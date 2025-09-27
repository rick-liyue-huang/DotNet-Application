using System.ComponentModel.DataAnnotations;

namespace API.Features.Games.UpdateGame;

public record UpdateGameDto(
  [Required][MaxLength(50)]string Name,
  [Required][MaxLength(500)]string Description,
  Guid GenreId,
  [Range(1, 200)]decimal Price,
  DateOnly ReleaseDate
);


using System.ComponentModel.DataAnnotations;

namespace API.Features.Games.UpdateGame;

public record UpdateGameDto(
  [Required][StringLength(50)]string Name,
  Guid GenreId,
  [Required][StringLength(500)]string Description,
  [Range(0, 1000)]decimal Price,
  DateOnly ReleaseDate
);

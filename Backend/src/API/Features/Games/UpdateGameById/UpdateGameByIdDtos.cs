using System.ComponentModel.DataAnnotations;

namespace API.Features.Games.UpdateGameById;

public record UpdateGameDto(
    [Required][StringLength(100)]
    string Name,
    Guid GenreId,
    [Range(0, 10000)]
    decimal Price,
    DateOnly ReleaseDate,
    [Required][StringLength(1000)]
    string Description
);

public record GameDetailsDto(
    Guid Id,
    string Name,
    Guid GenreId,
    decimal Price,
    DateOnly ReleaseDate,
    string Description
);
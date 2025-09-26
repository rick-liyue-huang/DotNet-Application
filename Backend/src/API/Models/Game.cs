using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Game
{
    public Guid Id { get; set; }

    [Required][MaxLength(50)]
    public required string Name { get; set; } = string.Empty;

    [Required][MaxLength(20)]
    public required string Genre { get; set; }

    [Range(1, 200)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

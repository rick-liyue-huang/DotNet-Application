
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Game
{
    public Guid Id { get; set; }
    [Required][StringLength(50)]
    public required string Name { get; set; }
    [Required][MaxLength(50)]
    public required string Genre { get; set; }
    [Range(0, 1000)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

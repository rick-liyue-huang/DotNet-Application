
// using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Game
{
  // [Required]
  public Guid Id { get; set; }
  
  // [Required][StringLength(100)]
  public required string Name { get; set; } = string.Empty;

  // [Required][StringLength(100)]
  public Genre? Genre { get; set; }

  // [Range(0, 10000)]
  public decimal Price { get; set; }

  public DateOnly ReleaseDate { get; set; }

  public required string Description { get; set; } = string.Empty;

  public Guid GenreId { get; set; }
}

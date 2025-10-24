
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Game
{
  [Required]
  public Guid Id { get; set; }
  
  [Required][StringLength(100)]
  public required string Name { get; set; } = string.Empty;

  [Required][StringLength(100)]
  public required string Genre { get; set; } = string.Empty;

  [Range(0, 10000)]
  public decimal Price { get; set; }

  public DateOnly ReleaseDate { get; set; }
}

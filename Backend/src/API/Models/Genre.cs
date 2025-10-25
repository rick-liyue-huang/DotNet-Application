// using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Genre
{
  public Guid Id { get; set; }
  // [Required] [StringLength(100)] 
  public required string Name { get; set; } = string.Empty;
}
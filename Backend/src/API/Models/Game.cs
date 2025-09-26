using System;

namespace API.Models;

public class Game
{
    public Guid Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

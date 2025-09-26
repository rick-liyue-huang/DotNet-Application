
namespace API.Models;

public class Game
{
    public Guid Id { get; set; }

    public required string Name { get; set; } = string.Empty;

    public required string Description { get; set; } = string.Empty;

    public required Genre Genre { get; set; }

    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

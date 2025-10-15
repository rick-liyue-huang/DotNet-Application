
using API.Models;

namespace API.Data;

public class GameStoreData
{
    private readonly List<Genre> genres =
    [
      new Genre
      {
        Id = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
        Name = "Action"
      },
      new Genre
      {
        Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
        Name = "Adventure"
      },
      new Genre
      {
        Id = new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"),
        Name = "RPG"
      },
      new Genre
      {
        Id = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
        Name = "First-Person Shooter"
      },
    ];

    private readonly List<Game> games;

    public GameStoreData()
    {
      games = 
      [
        new Game
        {
          Id = Guid.NewGuid(),
          Name = "The Witcher 3",
          Genre = genres[0],
          Price = 59.99M,
          ReleaseDate = new DateOnly(2015, 5, 19), 
          Description = "A story-driven, action-adventure RPG set in the fictional kingdom of Sildur."
        },
        new Game 
        {
          Id = Guid.NewGuid(),
          Name = "Red Dead Redemption 2",
          Genre = genres[1],
          Price = 59.99M,
          ReleaseDate = new DateOnly(2019, 10, 26),
          Description = "A third-person, action-adventure game set in a post-apocalyptic world."
        },
        new Game
        {
          Id = Guid.NewGuid(),
          Name = "The Legend of Zelda: Breath of the Wild",
          Genre = genres[1],
          Price = 59.99M,
          ReleaseDate = new DateOnly(2017, 3, 3), 
          Description = "A 3D action-adventure game set in the fictional kingdom of Hyrule."
        },
        new Game
        {
          Id = Guid.NewGuid(),
          Name = "Call of Duty: Infinite Warfare",
          Genre = genres[2],
          Price = 59.99M,
          ReleaseDate = new DateOnly(2016, 9, 13), 
          Description = "A first-person shooter game set in a post-apocalyptic world."
        },
        new Game
        {
          Id = Guid.NewGuid(),
          Name = "Grand Theft Auto V",
          Genre = genres[3],
          Price = 59.99M,
          ReleaseDate = new DateOnly(2013, 9, 17), 
          Description = "A third-person, action-adventure game set in the fictional city of Los Santos."
        },
      ];
    }


    public IEnumerable<Game> GetGames() => games;

    public Game? GetGameById(Guid id) => games.Find(g => g.Id == id);

    public void AddGame(Game game)
    {
      game.Id = Guid.NewGuid();
      games.Add(game);
    }

    public void RemoveGame(Guid id)
    {
      games.RemoveAll(g => g.Id == id);
    }

    public IEnumerable<Genre> GetGenres() => genres;

    public Genre? GetGenreById(Guid id) => genres.Find(g => g.Id == id);
    
}

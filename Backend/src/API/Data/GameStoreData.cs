using API.Models;

namespace API.Data;

public class GameStoreData
{
    private readonly List<Genre> _genres =
    [
        new Genre
        {
            Id = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
            Name = "Action-Adventure"
        },
        new Genre
        {
            Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
            Name = "Adventure"
        },
        new Genre
        {
            Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
            Name = "RPG"
        },
        new Genre
        {
            Id = new Guid("8f6b3c1f-4e2a-4b3c-9d7e-3f2a1b4c5d6e"),
            Name = "Sandbox"
        },
        new Genre
        {
            Id = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-e1f2a3b4c5d6"),
            Name = "Battle Royal"
        }
    ];

    private readonly List<Game> _games;

    public GameStoreData()
    {
        _games = 
        [
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "The Witcher 3",
                Genre = _genres[2],
                Price = 59.99M,
                ReleaseDate = DateOnly.FromDateTime(new DateTime(2015, 5, 19)),
                Description =
                    "The Witcher 3 is a 2015 action-adventure game developed by CD Projekt Red and published by CD Projekt Red."
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Red Dead Redemption 2",
                Genre = _genres[0],
                Price = 59.99M,
                ReleaseDate = DateOnly.FromDateTime(new DateTime(2018, 10, 26)),
                Description =
                    "Red Dead Redemption 2 is a 2018 action-adventure game developed by Rockstar North and published by Rockstar Games."
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "The Legend of Zelda: Breath of the Wild",
                Genre = _genres[1],
                Price = 59.99M,
                ReleaseDate = DateOnly.FromDateTime(new DateTime(2017, 3, 3)),
                Description =
                    "The Legend of Zelda: Breath of the Wild is a 2017 action-adventure game developed by Nintendo and published by Nintendo."
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Minecraft",
                Genre = _genres[3],
                Price = 0,
                ReleaseDate = DateOnly.FromDateTime(new DateTime(2011, 11, 18)),
                Description = "Minecraft is a sandbox video game developed by Mojang Studios and published by Mojang Studios."
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Fortnite",
                Genre = _genres[4],
                Price = 0,
                ReleaseDate = DateOnly.FromDateTime(new DateTime(2017, 7, 17)),
                Description =
                    "Fortnite is a multiplayer online battle royale video game developed by Epic Games and published by Epic Games."
            }
        ];
    }
    
    public IEnumerable<Game> GetGames() => _games;
    
    public Game? GetGame(Guid id) => _games.Find(g => g.Id == id);
    
    public void AddGame(Game game)
    {
        game.Id = Guid.NewGuid();
        _games.Add(game);
    }

    public void RemoveGame(Guid id)
    {
        _games.RemoveAll(game => game.Id == id);
    }
    
    public IEnumerable<Genre> GetGenres() => _genres;
    
    public Genre? GetGenre(Guid id) => _genres.Find(g => g.Id == id);
}
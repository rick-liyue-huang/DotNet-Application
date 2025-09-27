using System;
using API.Models;

namespace API.Data;

public class GameStoreData
{
  private readonly List<Genre> _genres =
    [
      new Genre
      {
        Id = new Guid("585d475f-e82d-48bb-bf1a-be3717f70c7b"),
        Name = "Action-Adventure"
      },
      new Genre
      {
        Id = new Guid("f7f5c0c9-b5c7-4f0d-a5c5-f7f5c0c9b5c7"),
        Name = "RPG"
      },
      new Genre{
        Id = new Guid("f7f5c0c9-b5c7-4f0d-a5c5-f7f5c0c9b5c8"),
        Name = "Shooter"
      },
      new Genre{
        Id = new Guid("f7f5c0c9-b5c7-4f0d-a5c5-f7f5c0c9b5c9"),
        Name = "Strategy"
      }
    ];


  private readonly List<Game> _games;

  public GameStoreData()
  {
    _games = [
      new Game
      {
        Id = Guid.NewGuid(),
        Name = "The Witcher 3",
        Description = "The Witcher is an action-adventure RPG set in a world where merpeople, dragons, and other fantastic beasts roam the world. You play Geralt of Rivia, a monster slayer who travels the world in search of a child who has been turned into a monster by a cruel sorcerer.",
        Genre = _genres[0],
        Price = 19.99m,
        ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
      },
      new Game
      {
        Id = Guid.NewGuid(),
        Name = "Red Dead Redemption 2",
        Description = "Red Dead Redemption 2 is an action-adventure game set in a world where the main character, Arthur Morgan, is a member of the Van der Linde gang. He must deal with the other members of the gang, the authorities, and the elements of the game world.",
        Genre = _genres[3],
        Price = 29.99m,
        ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
      },
      new Game
      {
        Id = Guid.NewGuid(),
        Name = "The Elder Scrolls V: Skyrim",
        Description = "The Elder Scrolls V: Skyrim is an action-adventure game set in a world where the main character, player character, is a werewolf. He must deal with the other members of the werewolf pack, the authorities, and the elements of the game world.",
        Genre = _genres[2],
        Price = 59.99m,
        ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
      },
      new Game {
        Id = Guid.NewGuid(),
        Name = "Fallout 4",
        Description = "Fallout 4 is an action-adventure game set in a world where the main character, player character, is a werewolf. He must deal with the other members of the werewolf pack, the authorities, and the elements of the game world.",
        Genre = _genres[1],
        Price = 39.99m,
        ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
      }
    ];
  }

  public IEnumerable<Game> GetGames() => _games;

  public Game? GetGameById(Guid id) => _games.FirstOrDefault(g => g.Id == id);

  public void AddGame(Game game)
  {
    game.Id = Guid.NewGuid();
    _games.Add(game);
  }

  public void RemoveGame(Guid id)
  {
    _games.RemoveAll(g => g.Id == id);
  }

  public IEnumerable<Genre> GetGenres() => _genres;

  public Genre? GetGenreById(Guid id) => _genres.FirstOrDefault(g => g.Id == id);
}

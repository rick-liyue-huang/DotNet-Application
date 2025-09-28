using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class DataExtensions
{

  public static void InitialDb(this WebApplication app)
  {
    app.MigrateDb();
    app.SeedDb();
  }

  // use to replace with 'dotnet ef database update'
  private static void MigrateDb(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    dbContext.Database.Migrate();
  }

  private static void SeedDb(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();

    if (!dbContext.Genres.Any())
    {
      dbContext.Genres.AddRange(
        new Genre() { Name = "Action" },
        new Genre() { Name = "Adventure" },
        new Genre() { Name = "RPG" },
        new Genre() { Name = "Sports" },
        new Genre() { Name = "Strategy" }
      );
      dbContext.SaveChanges();
    }

    if (!dbContext.Games.Any())
    { 
    }

  }
}

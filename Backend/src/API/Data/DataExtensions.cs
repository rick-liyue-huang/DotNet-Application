using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class DataExtensions
{

  public static async Task InitialDbAsync(this WebApplication app)
  {
    await app.MigrateDbAsync();
    await app.SeedDbAsync();
  }

  // use to replace with 'dotnet ef database update'
  private static async Task MigrateDbAsync(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    // dbContext.Database.Migrate();
    await dbContext.Database.MigrateAsync();
  }

  private static async Task SeedDbAsync(this WebApplication app)
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
      await dbContext.SaveChangesAsync();
    }

    if (!dbContext.Games.Any())
    { 
    }

  }
}

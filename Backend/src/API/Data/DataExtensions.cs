using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class DataExtensions
{
    public static void InitializeDb(this WebApplication app)
    {
        app.MigrateDb();
        app.SeedDb();
    }
    private static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate(); // will create the database similar as `dotnet ef database update`
    }


    private static void SeedDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();

        if (!dbContext.Genres.Any())
        {
            dbContext.Genres.AddRange(
                new Genre
                {
                    Name = "Action"
                },
                new Genre
                {
                    Name = "Adventure"
                },
                new Genre
                {
                    Name = "RPG"
                },
                new Genre
                {
                    Name = "Sandbox"
                },
                new Genre
                {
                    Name = "Battle Royal"
                });
            dbContext.SaveChanges();
        }
    }
}
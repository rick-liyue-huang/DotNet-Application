using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this WebApplication app)
    {
        await app.MigrateDbAsync();
        await app.SeedDbAsync();
        
        app.Logger.LogInformation(18, "Database is ready"); // LogError, LogWarning,
    }
    private static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync(); // will create the database similar as `dotnet ef database update`
    }


    private static async Task SeedDbAsync(this WebApplication app)
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
            await dbContext.SaveChangesAsync();
        }
    }
}
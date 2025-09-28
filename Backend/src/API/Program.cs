using API.Data;
using API.Features.Games;
using API.Features.Genres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register services


// DbContext is designed to be a singleton and injected into the GameStoreData class
// DbContext created -> entity changes tracked -> save changes -> dispose
// Db connections are expensive.
// DbContext is not thread safe.
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<GameDataLogger>(); // logger for transient scope
builder.Services.AddScoped<GameStoreData>(); // data for scoped scope

var app = builder.Build();

// GameStoreData data = new();

// group all endpoints in /games
app.MapGamesEndpoints();
// group all endpoints in /genres
app.MapGenresEndpoints();

app.InitialDb();

app.Run();

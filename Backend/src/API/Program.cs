
using API.Data;
using API.Features.Games;
using API.Features.Genres;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<GameStoreData>();
builder.Services.AddTransient<GameDataLogger>();

var app = builder.Build();


// GameStoreData data = new();

// app.MapGet("/", () => "Hello World!");

app.MapGamesEndpoints(); // dismiss data

app.MapGenresEndpoints();


app.Run();









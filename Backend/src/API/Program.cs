
using API.Data;
using API.Features.Games;
using API.Features.Genres;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

GameStoreData data = new();

// app.MapGet("/", () => "Hello World!");

app.MapGamesEndpoints(data);

app.MapGenresEndpoints(data);


app.Run();









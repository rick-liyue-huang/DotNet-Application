using API.Data;
using API.Features.Games;
using API.Features.Genres;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

GameStoreData data = new();

// group all endpoints in /games
app.MapGamesEndpoints(data);
// group all endpoints in /genres
app.MapGenresEndpoints(data);

app.Run();

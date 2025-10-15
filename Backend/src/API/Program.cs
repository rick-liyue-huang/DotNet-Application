using API.Data;
using API.Features.Games;
using API.Features.Genres;



var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = nameof(GetGameEndpointName);

GameStoreData data = new();

app.MapGames(data);

app.MapGenres(data);

app.Run();

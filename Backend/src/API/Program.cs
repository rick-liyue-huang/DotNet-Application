using API.Data;
using API.Features.Games;
using API.Features.Genres;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<GameDataLogger>();
builder.Services.AddSingleton<GameStoreData>();

var app = builder.Build();

const string GetGameEndpointName = nameof(GetGameEndpointName);

// GameStoreData data = new();

app.MapGames();

app.MapGenres(); //remove data

app.Run();

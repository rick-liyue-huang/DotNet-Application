
using API.Data;
using API.Features.Games;
using API.Features.Genres;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStoreDbString");

/*
 What service lifetime to use for the service?
 DbContext is designed to be used as a single Unit of Work.
 DbContext created -> entity changes tracked -> SaveChanges() -> changes saved to database -> disposed;
 DB connection is expensive;
 DbContext is not thread safe;
 Increased memory usage due to change tracking;
 
 - Singleton - one instance of the service is created and shared across all requests.
 - Transient - a new instance of the service is created for each request.
 - Scoped - a new instance of the service is created for each request. so we use it.
 There is only one thread executing each client request at a given time.
 Ensure each request gets a separate DbContext instance.
 */

// builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlite(connString));
builder.Services.AddSqlite<GameStoreContext>(connString);

// builder.Services.AddSingleton<GameStoreData>();
// builder.Services.AddTransient<GameDataLogger>();

var app = builder.Build();


// GameStoreData data = new();

// app.MapGet("/", () => "Hello World!");

app.MapGamesEndpoints(); // dismiss data

app.MapGenresEndpoints();

await app.InitializeDbAsync();


app.Run();









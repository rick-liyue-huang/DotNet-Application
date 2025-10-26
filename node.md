add some notes here


1:-

这里 games 是一个集合（可能是 List<T> 或其他实现了 IEnumerable<T> 的类型），FirstOrDefault 用于查找 Id 等于传入 id 的第一个元素。如果没有找到匹配的元素，FirstOrDefault 返回 null（对于引用类型）或默认值（对于值类型）。
使用 Find 代替 FirstOrDefault
如果 games 是一个 List<T>，你可以使用 List<T>.Find 方法来替代 FirstOrDefault，因为 Find 是 List<T> 提供的一个方法，功能类似，但性能可能略有优势。Find 同样返回匹配条件的第一个元素，如果没有找到则返回 null（对于引用类型）或默认值（对于值类型）。

App.MapGet, App.MapPost, App.MapPut, App.MapDelete, App.MapPatch,

App.MapController

1. app.MapGet

定义：app.MapGet 是 ASP.NET Core 提供的一种**最小 API（Minimal API）**方法，用于直接映射 HTTP GET 请求到指定的处理程序（handler）。
用途：用于快速定义轻量级的 API 端点，通常用于简单的、无需复杂控制器结构的场景。
特点：

直接路由：通过 app.MapGet 可以直接在 Program.cs 或启动代码中定义路由和处理逻辑，无需创建单独的控制器类。
简洁：适合小型项目或微服务，代码更简洁，减少样板代码。
灵活性：处理程序可以是 lambda 表达式、委托或方法，逻辑直接内联。
示例：
csharpapp.MapGet("/games/{id}", (Guid id) => games.Find(g => g.Id == id));
这段代码将 HTTP GET 请求 /games/{id} 映射到一个 lambda 表达式，用于查找 ID 匹配的游戏对象。
限制：

功能较为简单，适合轻量级场景。
不支持复杂的控制器功能（如依赖注入的复杂生命周期、过滤器、模型绑定等高级功能），需要手动实现。
不适合大型项目或需要大量重用逻辑的场景。





2. app.MapControllers

定义：app.MapControllers 是 ASP.NET Core 用于启用基于控制器的路由的方法，它会扫描应用程序中定义的所有控制器（Controller 类）并自动映射其路由。
用途：用于传统的 MVC 或 Web API 项目，适合需要复杂逻辑、结构化代码或大量端点的大型应用。
特点：

控制器驱动：需要定义继承自 ControllerBase 或 Controller 的控制器类，端点逻辑在控制器的方法（Action）中实现。
功能丰富：支持 ASP.NET Core 的高级功能，如模型绑定、验证、过滤器（Filter）、授权（Authorization）、依赖注入等。
结构化：代码组织更适合大型项目，控制器和操作方法可以复用逻辑，分层更清晰。 需要 `builder.Services.AddControllers();`


3:-
dotnet add package Microsoft.AspNetCore.Mvc.Core


Transient: 每次请求都创建新实例，适合无状态或独立的对象。
Scoped: 在同一作用域内重用实例，适合 HTTP 请求或特定上下文。
Singleton: 全局唯一实例，适合共享状态或资源，但需注意线程安全。


EF---------


// dotnet-ef from nuget.org : dotnet tool install --global dotnet-ef
// dotnet ef migrations add InitialCreate --output-dir Data/Migrations
// dotnet ef migrations add InitialCreate
// dotnet ef database update


// docker pull postgres
// docker run --name restaurantconnection -e POSTGRES_PASSWORD=mysecretpassword -p 5432:5432 -d postgres
// docker ps -a
// docker logs <containerId>

这是项目代码中的链接字符串
Host=localhost;Port=5432;Database=NewRestaurantDb;Username=postgres;Password=mysecretpassword

这是实际的数据库中查看数据的连接字符串
jdbc:postgresql://localhost:5432/NewRestaurantDb?user=postgres&password=mysecretpassword

另外需要注意的是：
这个项目中包括了不同的子项目: API, Infrastructure, Domain, Application,

并且 Infrastructure 依赖于 Domain, 并且 数据库的连接也是在这里，因此需要先导航到这里再运行 dotnet ef migrations add xxx,
并且链接数据库 dotnet ef database update的操作需要回到 主程序 API/program中运行 dotnet run 以后才可以操作。

Domain -> Application -> API
Domain -> Application -> Infrastructure
Infrastructure -> API




dotnet tool install --global dotnet-ef



Program.cs:
```using API.Data;
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

await app.InitialDbAsync();

app.Run();
```


MinimalApis.Extensions 需要额外安装：支持 [Required][StringLength()]... ,
并且需要加入 route(xxx).WithParameterValidation();

DTO is the contract between the client and the server.
#


#####################################

为什么这个案例符合 DIP？

高层模块不依赖低层模块：

Logger（高层模块）不直接依赖 FileLogWriter 或 DatabaseLogWriter（低层模块），而是依赖抽象接口 ILogWriter。
这使得 Logger 不关心具体的日志记录方式。


抽象不依赖细节，细节依赖抽象：

ILogWriter 接口是抽象的，不包含任何具体实现细节。
具体实现（如 FileLogWriter、DatabaseLogWriter）依赖于 ILogWriter 接口，通过实现接口来提供功能。


好处：

可扩展性：新增日志方式（如 CloudLogWriter）只需实现 ILogWriter，无需修改 Logger。
可测试性：在单元测试中，可以注入一个模拟的 ILogWriter（如使用 Moq 框架）来测试 Logger 的行为。
解耦：通过接口隔离，Logger 和具体的日志实现之间没有直接依赖。




实际应用场景
DIP 在以下场景中非常常见：

数据库访问：业务逻辑依赖 IRepository 接口，而不是具体的 SqlRepository 或 MongoRepository。
通知服务：发送通知的代码依赖 INotificationService，可以切换为 EmailNotificationService 或 SmsNotificationService。
支付系统：支付逻辑依赖 IPaymentProcessor，支持 PayPalProcessor 或 StripeProcessor。



333

Up: 前进，应用新的数据库更改（创建、修改）。
Down: 后退，撤销更改以恢复到上一个迁移状态。
一致性: Down 方法必须能够完全撤销 Up 方法的操作，确保迁移可逆。
数据库安全: 在生产环境中，执行 Down 方法要谨慎，因为它可能删除数据（例如，DropTable 会删除表及其数据）。
迁移顺序: EF Core 按迁移文件的创建时间戳（存储在 __EFMigrationsHistory 表中）按顺序执行 Up 或 Down。

模型快照（Snapshot） 是一个记录 EF Core 数据模型当前状态的 C# 文件，包含实体、属性、关系和配置的完整定义。
作用: 作为模型变更检测的基准，帮助 EF Core 生成增量迁移文件。


AsNoTracking() 的作用:

禁用 EF Core 的变更跟踪，使查询返回的实体不被 DbContext 跟踪，优化内存和性能。
适合只读场景，尤其是返回 DTO 的查询。


在代码中的意义:

在 GetGamesEndpoint 中，AsNoTracking() 优化了查询游戏列表的性能，因为结果被投影为 GameSummaryDto，无需跟踪实体。
结合 Include 和 Select，它确保高效加载和返回游戏数据。


好处:

减少内存占用，提升查询速度，适合 API 的 GET 请求。


限制:

不适合需要更新实体的场景，需谨慎选择使用。
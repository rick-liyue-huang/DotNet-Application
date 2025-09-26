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
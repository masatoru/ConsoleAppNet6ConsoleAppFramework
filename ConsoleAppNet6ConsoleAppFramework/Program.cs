// You can use full feature of Generic Host(same as ASP.NET Core).

using Microsoft.Extensions.DependencyInjection;
using ZLogger;

var builder = ConsoleApp.CreateBuilder(args);
var app = builder.ConfigureServices((ctx, services) =>
{
    // Register EntityFramework database context
    // services.AddDbContext<MyDbContext>();

    // Register appconfig.json to IOption<MyConfig>
    services.Configure<MyConfig>(ctx.Configuration);

    // Using Cysharp/ZLogger for logging to file
    services.AddLogging(logging =>
    {
        logging.AddZLoggerFile("log.txt");
    });
}).Build(); ;

// Commands:
//   hello (default)
//   world
app.AddCommands<MyCommands>();
app.Run();
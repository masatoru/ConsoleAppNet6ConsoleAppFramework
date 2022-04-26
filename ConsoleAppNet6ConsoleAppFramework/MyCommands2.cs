using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ZLogger;

public class MyCommands2 : ConsoleAppBase, IDisposable
{
    readonly ILogger<MyCommands2> logger;
    private readonly MyConfig _config;

    //  You can receive DI services in constructor.
    public MyCommands2(ILogger<MyCommands2> logger, IOptions<MyConfig> config)
    {
        this.logger = logger;
        _config = config.Value;
    }

    // All public methods is registred.

    // Using [RootCommand] attribute will be root-command
    // [RootCommand]
    public void Hello()
    {
        // Context has any useful information.
        Console.WriteLine("Hello from MyCommands2");
        Console.WriteLine($"Foo={_config.Foo} Bar={_config.Bar} from MyCommands2");
        Console.WriteLine(this.Context.Timestamp);

        logger.ZLogInformation($"ZLogger {this.Context.Timestamp}");
    }

    public async Task World2()
    {
        await Task.Delay(1000, this.Context.CancellationToken);
        Console.WriteLine("World from MyCommands2");
    }

    // If implements IDisposable, called for cleanup
    public void Dispose()
    {
    }
}
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ZLogger;

public class MyCommands : ConsoleAppBase, IDisposable
{
    readonly ILogger<MyCommands> logger;
    private readonly MyConfig _config;

    //  You can receive DI services in constructor.
    public MyCommands(ILogger<MyCommands> logger, IOptions<MyConfig> config)
    {
        this.logger = logger;
        _config = config.Value;
    }

    // All public methods is registred.

    // Using [RootCommand] attribute will be root-command
    [RootCommand]
    public void Hello()
    {
        // Context has any useful information.
        Console.WriteLine("Hello");
        Console.WriteLine($"Foo={_config.Foo} Bar={_config.Bar}");
        Console.WriteLine(this.Context.Timestamp);

        logger.ZLogInformation($"ZLogger {this.Context.Timestamp}");
    }

    public async Task World()
    {
        await Task.Delay(1000, this.Context.CancellationToken);
        Console.WriteLine("World");
    }

    // If implements IDisposable, called for cleanup
    public void Dispose()
    {
    }
}
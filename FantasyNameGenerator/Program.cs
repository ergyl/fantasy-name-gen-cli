using Microsoft.Extensions.DependencyInjection;
using FantasyNameGenerator.Application;
using appConfig = FantasyNameGenerator.Infrastructure.Configuration.ServiceConfigurator;
namespace FantasyNameGenerator;

public static class Program
{
    /// <summary>
    /// Very thin wrapper around the FantasyNameGeneratorApp to allow for dependency injection and service configuration.
    /// </summary>
    /// <param name="args">CLI arguments</param>
    /// <returns>Exit code</returns>
    public static int Main(string[] args)
    {
        var services = new ServiceCollection();
        appConfig.ConfigureServices(services);

        using var provider = services.BuildServiceProvider();
        var app = provider.GetRequiredService<FantasyNameGeneratorApp>();

        return app.Run(args);
    }
}
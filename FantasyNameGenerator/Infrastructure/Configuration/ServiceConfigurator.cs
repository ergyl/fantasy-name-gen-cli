using Microsoft.Extensions.DependencyInjection;
using FantasyNameGenerator.Application;
using FantasyNameGenerator.Presentation;

namespace FantasyNameGenerator.Infrastructure.Configuration
{
    public static class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
             // Application
             .AddSingleton<FantasyNameGeneratorApp>()

             // Presentation
             .AddSingleton<CliContract>()
             .AddSingleton<IPresenter, CliPresenter>()

             // Services
             .AddSingleton<INameGenerator, SimpleNameGenerator>()

             // Infrastructure
             .AddSingleton<ISeededRandom, SeededRandomProvider>()
             .BuildServiceProvider();
        }
    }
}
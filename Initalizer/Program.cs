using Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RavenDB;
using System;
using System.Threading.Tasks;

namespace Initalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            // Creating Configuration and checking for appsettings.json
            IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            // Creating a Database instance and adding it to the IServiceProvider
            Database DB = new(Config);

            // Dependency injection 
            IServiceProvider Services = new ServiceCollection()
                .AddSingleton(DB)
                .BuildServiceProvider();

            // Creating the DiscordClient 
            DiscordClientHandler Dclient = new DiscordClientHandler(Config, Services);
            await Dclient.RunAsync();
        }
    }
}

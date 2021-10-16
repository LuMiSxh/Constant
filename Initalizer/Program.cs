using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RavenDB;
using Client;
using System;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Configuration and checking for appsettings.json
            IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            // Creating a Database instance and adding it to the IServiceProvider
            Database db = new Database(Config);

            // Dependency injection 
            IServiceProvider Services = new ServiceCollection()
                .AddSingleton(db)
                .BuildServiceProvider();

            // Creating the DiscordClient 
            DiscordClientHandler Dclient = new DiscordClientHandler(Config, Services);

            Dclient.RunAsync().GetAwaiter().GetResult();
        }
    }
}

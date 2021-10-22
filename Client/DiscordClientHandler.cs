using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Client
{
    public class DiscordClientHandler
    {
        public readonly DiscordClient client;
        private readonly CommandsNextConfiguration SettingsNext;
        private readonly InteractivityConfiguration SettingsInter;

        public DiscordClientHandler(IConfiguration config, IServiceProvider services)
        {

            // DiscordSettings declaration
            var DiscordSettings = new DiscordConfiguration()
            {
                Token = config["Discord:Token"],
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            };

            // Creating the DiscordClient instance
            client = new DiscordClient(DiscordSettings);

            // CommandsNext declaration
            SettingsNext = new CommandsNextConfiguration
            {
                StringPrefixes = config.GetSection("Discord:Prefixes").Get<List<string>>(),
                Services = services
            };

            // InteractivtyConfiguration declaration
            SettingsInter = new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(3.5),
            };

            // Initiaalizing CommandsNext and Interactivity Modules
            var commands = client.UseCommandsNext(SettingsNext);

            var slash = client.UseSlashCommands();

            client.UseInteractivity(SettingsInter);

            // Registering Modules for Slash- and CommandsNext

            // Base functions 

            client.Ready += OnReady;
        }

        // Starting the client
        public async Task RunAsync()
        {
            await client.ConnectAsync();
            await Task.Delay(-1);

        }

        // OnReady
        private async Task OnReady(DiscordClient sender, ReadyEventArgs e)
        {
            Console.WriteLine("Constant is now Online");

            // Setting the client status

            await client.UpdateStatusAsync(new DiscordActivity("Settings.Status", ActivityType.Watching));
        }
    }
}

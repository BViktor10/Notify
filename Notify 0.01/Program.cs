using DSharpPlus;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using DSharpPlus.CommandsNext;

namespace Notify
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            string text = File.ReadAllText("config.json");
            var confingreader = JsonSerializer.Deserialize<ConfigReader>(text);  //Json file alakítás a structba

            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = confingreader.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All                                     //Jogok
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { confingreader.Prefix }
            });

            commands.RegisterCommands<Com>();

            

            /*
            discord.MessageCreated += async (s, e) =>                            // Message Lambda
            {
                if (e.Message.Content.ToLower().StartsWith("cock"))              // Ellenőrzi, hogy van-e benne ilyen karakterlánc
                    await e.Message.RespondAsync("");  // Válaszol rá
            };
            */


            /*
            string StringTemp = null;                                           //Temp változó a channel nevének

            discord.VoiceStateUpdated += async (s, e) =>                        //Voice Channel Lambda
            {
                var temp2 = e.After.Channel;                                    
                if (temp2 != null)
                    StringTemp = temp2.ToString();
                await Task.CompletedTask;
            };

            discord.MessageCreated += async (s, e) =>
            {
                if (StringTemp != null)
                    await e.Message.RespondAsync(StringTemp);
            };
          */
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}

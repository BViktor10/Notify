using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.IO;

namespace Notify
{
    public class Com : BaseCommandModule
    {
        string UserId;
        string CurrentUser;

        [Command("greet")]
        public async Task GreetCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("Greetings! Thank you for executing me!");
        }

        [Command("FVC")]
        public async Task Teszt(CommandContext ctx, DiscordMember member)
        {
            bool statement = false;
            CurrentUser = Convert.ToString(ctx.User.Id);
            UserId = Convert.ToString(member.Id);
            var temp1 = member.IsBot;
            if (temp1 == true) await ctx.RespondAsync("Bots aren't allowed to be followed which channels they join!\nPlease change the mention to a living creature!");
            else if(CurrentUser == UserId)
            {
                await ctx.RespondAsync("Silly you! You can't follow yourself! :heart:");
            }
            else
            {
                statement = true;
                await ctx.RespondAsync("You will now see " + member.Username + " if he/she joins a voice channel!");
            }

            if (statement == true)
            {
                var comconwriter = new ComConWriter
                {
                    User = CurrentUser,
                    DestinationUser = UserId
                };

                string jsonString = JsonSerializer.Serialize(comconwriter);
            }
        }

        [Command("FVC")]
        public async Task Teszt(CommandContext ctx)
        {
            await ctx.RespondAsync("Wrong argument!\nPlease state the following parts of the command:\n-fvc @mention");
        }

        [Command("IP")]                                                                                                           //Vicc
        public async Task tarja(CommandContext ctx, DiscordMember member)
        {
            Random vsz = new Random();

            bool booleantemp = true;
            int temp1 = 0;
            int temp2 = 192;
            int temp3 = 192;

            while(booleantemp == true)
            {
                temp1 = vsz.Next(192);
                while(temp2 > temp1)
                {
                    temp2 = vsz.Next(192);
                    while(temp3 > temp2 || temp3 == 0)
                    {
                        temp3 = vsz.Next(192);
                    }
                }
                booleantemp = false;
            }

            await ctx.RespondAsync(member.Username + "-nak az IP címe:\n192."+temp1+"."+temp2+"."+temp3);
        }
    }
}

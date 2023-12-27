using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public class DCommandYn : IDiscordCommand
    {
        public string Command => "yn";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            if (param == "")
            {
                await context.Channel.SendMessageAsync("Please provide a question.");
                return;
            }

            Random random = new Random();
            int randomnr = random.Next(100);

            await context.Channel.SendMessageAsync(randomnr > 50 ? "Yes" : "No");
        }
    }
}

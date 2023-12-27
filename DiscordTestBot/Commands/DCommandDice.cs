using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public class DCommandDice : IDiscordCommand
    {
        public string Command => "dice";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            Random random = new Random();
            if (param == "")
            {
                int rand = random.Next(1, 7);
                await context.Channel.SendMessageAsync(rand + "");
                return;
            }

            if (int.TryParse(param, out int maxValue))
            {
                int rand = random.Next(1, maxValue);
                await context.Channel.SendMessageAsync(rand + "");
            }
            else
            {
                await context.Channel.SendMessageAsync(param + " is not a number");
            }
        }
    }
}

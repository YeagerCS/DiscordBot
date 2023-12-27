using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public class DCommandCountdown : IDiscordCommand
    {
        public string Command => "countdown";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            if (param.Length > 0)
            {
                if (int.TryParse(param, out int countdownValue))
                {

                    for (int i = countdownValue; i > 0; i--)
                    {
                        await context.Channel.SendMessageAsync($"{i} {(i != 1 ? "seconds" : "second")} remaining...");

                        await Task.Delay(1000);
                    }

                    await context.Channel.SendMessageAsync("Countdown complete.");
                }
                else
                {
                    await context.Channel.SendMessageAsync("Invalid countdown value.");
                }
            }
        }
    }
}

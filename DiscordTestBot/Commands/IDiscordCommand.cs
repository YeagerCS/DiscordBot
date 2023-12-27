using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public interface IDiscordCommand
    {
        string Command { get; }
        Task ExecuteAsync(SocketCommandContext context, string param);
    }
}

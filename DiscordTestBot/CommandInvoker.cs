using Discord.Commands;
using Discord.WebSocket;
using DiscordTestBot.Commands;
using DiscordTestBot.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot
{
    public class CommandInvoker
    {
        public static Task<bool> ExecuteCommand(List<IDiscordCommand> commandInstances, string command, SocketCommandContext context, string param)
        {
            IDiscordCommand dcCommand = commandInstances.FirstOrDefault(cmd => cmd.Command.Equals(command, StringComparison.OrdinalIgnoreCase));
            if(dcCommand != null)
            {
                Task.Run(() => dcCommand.ExecuteAsync(context, param));
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}

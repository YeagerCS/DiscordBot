using Discord.Commands;
using Discord.WebSocket;
using DiscordTestBot.Commands;
using DiscordTestBot.Tools;
using IniParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiscordTestBot.Shell
{
    public class DiscordBotShell
    {
        private DiscordSocketClient client;
       
        private List<IDiscordCommand> commandInstances;
        public DiscordBotShell(DiscordSocketClient client)
        {
            this.client = client;

            IEnumerable<Type> commandTypes = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(type => typeof(IDiscordCommand).IsAssignableFrom(type) && !type.IsInterface);
            commandInstances = commandTypes.Select(type => (IDiscordCommand)Activator.CreateInstance(type)).ToList();

            ConfigureAPIKeys();
        }

        public async Task RunShell(SocketMessage arg)
        {
            if (arg.Author.IsBot)
                return;

            if (arg is SocketUserMessage userMessage && !string.IsNullOrWhiteSpace(arg.Content))
            {
                var channel = client.GetChannel(userMessage.Channel.Id) as SocketGuildChannel;

                var guild = channel.Guild;
                var user = guild.GetUser(arg.Author.Id);
                var context = new SocketCommandContext(client, userMessage);


                int argPos = 0;
                if (userMessage.HasStringPrefix("!", ref argPos))
                {
                    var command = userMessage.Content.Substring(argPos).ToLower();
                    var commandParts = command.Split(" ");
                    string commandString = commandParts[0];
                    string param = commandParts.Length > 1 ? Converter.SplitCommand(command)[0] : "";

                    Task<bool> executionTask = CommandInvoker.ExecuteCommand(commandInstances, commandString, context, param);
                    bool executionSuccessful = await executionTask;

                    if (!executionSuccessful)
                    {
                        await context.Channel.SendMessageAsync(commandString + " is not a valid command");
                    }
                }

            }
        }

        private void ConfigureAPIKeys()
        {
            ApiKeys.LoadKeys("config.ini");
        }

    }
}

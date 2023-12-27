using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordTestBot.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Bot
{
    public class Bot
    {
        private DiscordSocketClient client;
        private DiscordBotShell handler;

        public Bot()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            });

            handler = new DiscordBotShell(client);

            client.MessageReceived += Client_MessageReceived;
        }

        private async Task Client_MessageReceived(SocketMessage arg)
        {
            await handler.RunShell(arg);
        }

        public async Task RunBotAsync(string botToken)
        {
            await client.LoginAsync(TokenType.Bot, botToken);
            await client.StartAsync();

            await Task.Delay(-1);
        }
    }
}

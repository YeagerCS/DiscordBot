using DeepL;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordTestBot;
using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Text;
using HtmlAgilityPack;
using DiscordTestBot.Shell;
using DiscordTestBot.Bot;
using DiscordTestBot.Tools;

class Program
{
    private DiscordSocketClient client;

    static async Task Main(string[] args)
    {
        Bot bot = new Bot();
        await bot.RunBotAsync(ApiKeys.BotToken);
    }

}

using Discord.Commands;
using DiscordTestBot.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public class DCommandRandomGIF : IDiscordCommand
    {
        public string Command => "rgif";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            string apiKey = ApiKeys.Giphy;
            string uri = $"https://api.giphy.com/v1/gifs/random?api_key={apiKey}&tag=&rating=g";

            using (var httpClient = new HttpClient())
            {

                string result = await httpClient.GetStringAsync(uri);

                var json = JObject.Parse(result);

                string gif = json["data"]["url"].ToString();

                await context.Channel.SendMessageAsync(gif);
            }
        }
    }
}

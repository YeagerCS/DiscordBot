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
    public class DCommandWtime : IDiscordCommand
    {
        public string Command => "wtime";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            string apiKey = ApiKeys.OpenWeatherMap;
            string uri = $"https://api.openweathermap.org/data/2.5/weather?q={param}&appid={apiKey}";

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(uri);
                if (!result.IsSuccessStatusCode)
                {
                    await context.Channel.SendMessageAsync("Can't find the location " + param);
                    return;
                }

                string resultString = await httpClient.GetStringAsync(uri);

                try
                {
                    var json = JObject.Parse(resultString);

                    string timezoneoffset = json["timezone"]?.ToString();
                    string timeInzone = Converter.GetTimeByOffset(timezoneoffset);

                    if (!string.IsNullOrEmpty(timeInzone))
                    {
                        string outputString = $"Time in {param}:\n{timeInzone}";
                        await context.Channel.SendMessageAsync(outputString);
                    }
                    else
                    {
                        await context.Channel.SendMessageAsync("Something went wrong.");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        
    }
}

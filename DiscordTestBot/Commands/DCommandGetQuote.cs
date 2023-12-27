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
    public class DCommandGetQuote : IDiscordCommand
    {
        public string Command => "quote";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            if (param == "!info")
            {
                string[] categories = ParamOptions.categories;

                StringBuilder formattedCategories = new();
                foreach (string category in categories)
                {
                    formattedCategories.Append($"**{category}**\n");
                }

                string reply = "These are the categories to choose from: \n" + formattedCategories;
                await context.Channel.SendMessageAsync(reply);
                return;
            }

            string apiKey = ApiKeys.APINinjas;
            string uri = "https://api.api-ninjas.com/v1/quotes" + (!string.IsNullOrEmpty(param) ? $"?category={param}" : "");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                string result = await httpClient.GetStringAsync(uri);
                Console.WriteLine("Result: " + result);
                if (result == "[]" || string.IsNullOrEmpty(result))
                {
                    await context.Channel.SendMessageAsync("The category " + param + " doesn't exist. Try !quote !info");
                    return;
                }
                var json = JArray.Parse(result);

                string quote = json[0]["quote"].ToString() + " ~ " + json[0]["author"];

                await context.Channel.SendMessageAsync(quote);
            }
        }
    }
}

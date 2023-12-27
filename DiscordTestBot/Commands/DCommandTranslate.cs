using DeepL;
using Discord.Commands;
using DiscordTestBot.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public class DCommandTranslate : IDiscordCommand
    {
        public string Command => "translate";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            try
            {
                string authKey = ApiKeys.DeepL;
                Translator translator = new(authKey);

                var translation = await translator.TranslateTextAsync(param, null, "en-gb");
                await context.Channel.SendMessageAsync(translation.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

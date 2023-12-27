using Discord.Commands;
using DiscordTestBot.Tools;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public class DCommandFilter : IDiscordCommand
    {
        public string Command => "filter";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            var attachment = (context.Message.Attachments.FirstOrDefault()?.Url) ?? string.Empty;
            if (param == "!info")
            {
                string[] filters = ParamOptions.filterDictionary.Keys.ToArray();

                StringBuilder formattedFilters = new StringBuilder();
                foreach (var filter in filters)
                {
                    formattedFilters.Append($"**{filter}**\n");
                }

                string output = $"You can choose from the following filters:\n{formattedFilters}";

                await context.Channel.SendMessageAsync(output);
                return;
            }

            if (!string.IsNullOrEmpty(attachment))
            {
                using (var httpClient = new HttpClient())
                {
                    var stream = await httpClient.GetStreamAsync(attachment);
                    var image = SixLabors.ImageSharp.Image.Load(stream);

                    ApplyFilter(image, param);

                    using (var output = new MemoryStream())
                    {
                        image.Save(output, new JpegEncoder());
                        output.Position = 0;
                        await context.Channel.SendFileAsync(output, "filtered.jpg", "Filtered Image:");
                    }
                }
            }
            else
            {
                await context.Channel.SendMessageAsync("Please provide an image attachment with the command. Try !filter !info");
            }
        }

        private void ApplyFilter(SixLabors.ImageSharp.Image image, string filterName)
        {
            Dictionary<string, Action<IImageProcessingContext>> filterDictionary = ParamOptions.filterDictionary;
            if (filterDictionary.TryGetValue(filterName.ToLower(), out var filter))
            {
                image.Mutate(filter);
            }
            else
            {
                Console.WriteLine($"Filter '{filterName}' not found. Try !filter !info");
            }
        }
    }
}

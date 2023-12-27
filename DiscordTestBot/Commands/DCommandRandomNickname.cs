using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Commands
{
    public class DCommandRandomNickname : IDiscordCommand
    {
        public string Command => "rnick";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            var user = context.User as SocketGuildUser;
            var guild = (context.Channel as SocketGuildChannel).Guild;

            string newNickname = GetNickname();
            if (user != null)
            {
                Console.WriteLine($"User ID: {user.Id}");
                Console.WriteLine($"Guild ID: {guild.Id}");

                try
                {
                    await user.ModifyAsync(props => props.Nickname = newNickname);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error modifying nickname: {ex.Message}");
                }
            }
        }

        private string GetNickname()
        {
            string[] PotentialPrefixes = { "The", "The", "Notorious", "Brutal", "Merciless", "Ruthless", "Relentless", "Vicious", "Ferocious", "Inhumane" };
            string[] NicksFirst = { "Fortnite", "React", "Benjamin", "Chrome", "Firefox", "Esse", "Eat", "Opera", "JavaScript", "Angular", "Travis", "Fortnite", ".NET", "C#", "Java" };
            string[] NicksLast = { "Slayer", "Killer", "Exterminator", "Enjoyer", "Eater", "Slapper", "Erazer", "Eradicator", "Destroyer", "Demolisher", "Executor", "Maker", "Torturer", "Disintegrator", "Decapitator" };


            Random random = new Random();
            string first = NicksFirst[random.Next(NicksFirst.Length)];
            string last = NicksLast[random.Next(NicksLast.Length)];
            string prefix = "";

            if (random.Next(1, 7) == 1)
            {
                prefix = PotentialPrefixes[random.Next(PotentialPrefixes.Length)];
            }

            return prefix + first + last;
        }
    }
}

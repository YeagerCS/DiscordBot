using IniParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Tools
{
    public class ApiKeys
    {
        public static string APINinjas { get; set; }
        public static string Giphy { get; set; }
        public static string DeepL { get; set; }
        public static string OpenWeatherMap { get; set; }
        public static string BotToken { get; set; }


        public static void LoadKeys(string filePath)
        {
            var parser = new FileIniDataParser();
            var iniData = parser.ReadFile(filePath);

            ApiKeys apiKeys = new();

            foreach (var prop in typeof(ApiKeys).GetProperties())
            {
                if (!string.IsNullOrEmpty(iniData["ApiKeys"][prop.Name]))
                {
                    prop.SetValue(apiKeys, iniData["ApiKeys"][prop.Name]);
                }
            }
        }
    }
}

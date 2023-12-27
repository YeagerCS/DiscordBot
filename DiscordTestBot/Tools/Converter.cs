using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordTestBot.Tools
{
    public class Converter
    {
        public static float KelvinToCelsius(float kelvin)
        {
            return (float)Math.Round(kelvin - 273.15f, 2);
        }

        public static float CelsiusToFahrenheit(float celsius)
        {
            return (float)Math.Round(1.8f * celsius + 32f, 2);
        }

        public static string[] SplitCommand(string command)
        {
            List<string> parameters = new List<string>();
            var matches = Regex.Matches(command, @"(?<match>""(?:\\""|[^""])*"")|(\S+)");
            bool firstMatch = true;
            foreach (Match match in matches)
            {
                if (firstMatch)
                {
                    firstMatch = false;
                    continue;
                }
                parameters.Add(match.Groups["match"].Success ? match.Groups["match"].Value.Trim('"') : match.Value);
            }
            return parameters.ToArray();
        }

        public static string GetTimeByOffset(string timeZoneOffset)
        {
            if (int.TryParse(timeZoneOffset, out int offsetSeconds))
            {
                var localtime = DateTime.UtcNow.AddSeconds(offsetSeconds);
                return localtime.ToString("HH:mm:ss");
            }

            return "";
        }
    }
}

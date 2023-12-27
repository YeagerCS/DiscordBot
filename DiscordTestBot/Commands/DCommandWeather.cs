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
    public class DCommandWeather : IDiscordCommand
    {
        public string Command => "weather";

        public async Task ExecuteAsync(SocketCommandContext context, string param)
        {
            Dictionary<string, string> symbols = ParamOptions.weatherSymbols;

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

                    string symbol = symbols[json["weather"][0]["main"].ToString()];
                    string description = json["weather"][0]["description"].ToString();
                    float temperatureK = (float)Convert.ToDouble(json["main"]["temp"].ToString());
                    float temperatureC = Converter.KelvinToCelsius(temperatureK);
                    float temperatureF = Converter.CelsiusToFahrenheit(temperatureC);
                    float lat = (float)Convert.ToDouble(json["coord"]["lat"].ToString());
                    float lon = (float)Convert.ToDouble(json["coord"]["lon"].ToString());
                    string time = Converter.GetTimeByOffset(json["timezone"].ToString());

                    string outputString = $"Weather in {param}:\nlat, lon: {lat}, {lon}\n{description} {symbol}\nTemperature: {temperatureC}°C, {temperatureF}°F\nCurrent Time: {time}\n";
                    await context.Channel.SendMessageAsync(outputString);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}

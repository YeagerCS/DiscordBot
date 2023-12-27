# DiscordBot

## Description
Discord bot with different functionalities

## Commands
All commands have to be entered with a `!` prefix. Here is a list of all commands, with a description:
- `countdown x` => Starts a for x seconds, where x has to be an integer.
- `dice x` => Rolls the dice from 1 to x. If x is empty it rolls from 1 to 6.
-  `filter type` => Expects an image attachment and applies the given filter to the image. `!filter !info` shows all filters.  
  (With SixLabors.ImageSharp)
- `quote category` => Gives a random quote with the option to specify a category. Get all categories with `!quote !info`.  
  (With APINinjas)
- `rgif` => Returns a random GIF from giphy (With Giphy API)
- `rnick` => Applies a random gamertag like nickname to the user.
- `translate "text"` => Translates text from other languages to english. (With DeepL)
- `weather location` => Returns weather information about a specific location. For location with two strings like new york, input it like "new york".  
  (With OpenWeatherMap)
- `wtime location` => Returns the current time in a specific location. Same as `weather` command.
- `yn question` => randomly answers yes or no to your question.

## ApiKeys
For the commands which require an api, you also require an API key. (All used APIS are free). To specify your API keys, create a 'config.ini' file in the root of the program `\DiscordBot\bin\Debug\net7.0\config.ini` (or similar).  
You can use this ini file as a template: (BotToken is the token for your discord bot)
```ini
[ApiKeys]
APINinjas = YOUR_API_KEY
Giphy = YOUR_API_KEY
DeepL = YOUR_API_KEY
OpenWeatherMap = YOUR_API_KEY
BotToken = YOUR_API_KEY
```

using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Tools
{
    public class ParamOptions
    {
        public static Dictionary<string, Action<IImageProcessingContext>> filterDictionary = new Dictionary<string, Action<IImageProcessingContext>>
        {
            { "gray", x => x.Grayscale() },
            { "invert", x => x.Invert() },
            { "polaroid", x => x.Polaroid() },
            { "oil", x => x.OilPaint() },
            { "gblur", x => x.GaussianBlur() },
            { "pixel", x => x.Pixelate() },
            { "edge", x => x.DetectEdges() },
            { "rotate", x => x.Rotate(90) },
            { "flip", x => x.Rotate(180) },
            { "mirror", x => x.Flip(FlipMode.Horizontal) },
            { "sepia", x => x.Sepia() },
            { "vignette", x => x.Vignette() },
            { "quantize", x => x.Quantize() },
            { "lomograph", x => x.Lomograph() },
            { "glow", x => x.Glow() },
            { "koda", x => x.Kodachrome() },
        };

        public static Dictionary<string, string> weatherSymbols = new Dictionary<string, string>
        {
            { "Thunderstorm", "🌩" },
            { "Sand", "🌪" },
            { "Ash", "🌪" },
            { "Squall", "🌪" },
            { "Tornado", "🌪" },
            { "Mist", "🌫" },
            { "Smoke", "🌫" },
            { "Haze", "🌫" },
            { "Dust", "🌫" },
            { "Fog", "🌫" },
            { "Clouds", "☁" },
            { "Drizzle", "🌧" },
            { "Rain", "🌧" },
            { "Snow", "🌨" },
            { "Clear", "🌤" }
        };

        public static string[] categories = {
            "age", "alone", "amazing", "anger", "architecture",
            "art", "attitude", "beauty", "best", "birthday",
            "business", "car", "change", "communication", "computers",
            "cool", "courage", "dad", "dating", "death",
            "design", "dreams", "education", "environmental", "equality",
            "experience", "failure", "faith", "family", "famous",
            "fear", "fitness", "food", "forgiveness", "freedom",
            "friendship", "funny", "future", "god", "good",
            "government", "graduation", "great", "happiness", "health",
            "history", "home", "hope", "humor", "imagination",
            "inspirational", "intelligence", "jealousy", "knowledge", "leadership",
            "learning", "legal", "life", "love", "marriage",
            "medical", "men", "mom", "money", "morning",
            "movies", "success"
        };
    }
}

namespace MoreDotNet.Extentions.Transliteration.Providers
{
    using System.Collections.Generic;

    using MoreDotNet.Extentions.Transliteration.Models;
    using MoreDotNet.Extentions.Transliteration.Providers.Contracts;

    public class BulgarianTranslitarationProvider : ITransliterationProvider
    {
        public IEnumerable<SpecialProvision> GetSpecialProvisions()
        {
            var result = new List<SpecialProvision>
            {
                new SpecialProvision
                {
                    Condition = x => x.EndsWith("я"),
                    Transformation = x => (x.TrimEnd('я') + "ia")
                },
                new SpecialProvision
                {
                    Condition = x => x.EndsWith("Я"),
                    Transformation = x => (x.TrimEnd('Я') + "IA")
                }
            };

            return result;
        }


        public IDictionary<string, string> GetToEnglishMappings()
        {
            return new Dictionary<string, string>()
            {
                { "а", "a" },
                { "б", "b" },
                { "в", "v" },
                { "г", "g" },
                { "д", "d" },
                { "е", "e" },
                { "ж", "zh" },
                { "з", "z" },
                { "и", "i" },
                { "й", "y" },
                { "к", "k" },
                { "л", "l" },
                { "м", "m" },
                { "н", "n" },
                { "о", "o" },
                { "п", "p" },
                { "р", "r" },
                { "с", "s" },
                { "т", "t" },
                { "у", "u" },
                { "ф", "f" },
                { "х", "h" },
                { "ц", "ts" },
                { "ч", "ch" },
                { "ш", "sh" },
                { "щ", "sht" },
                { "ъ", "a" },
                { "ь", "y" },
                { "ю", "yu" },
                { "я", "ya" }
            };
        }
    }
}

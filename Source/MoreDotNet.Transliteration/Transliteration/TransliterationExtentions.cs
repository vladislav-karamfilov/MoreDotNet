namespace MoreDotNet.Transliteration.Transliteration
{
    using System.ComponentModel;
    using System.Text;

    using MoreDotNet.Extentions.Common;
    using MoreDotNet.Transliteration.Transliteration.Models;
    using MoreDotNet.Transliteration.Transliteration.Providers;
    using MoreDotNet.Transliteration.Transliteration.Providers.Contracts;

    public static class TransliterationExtentions
    {
        public static string Transliterate(this string input, TransliterationType type)
        {
            var provider = GetProvider(type);
            var result = ApplySpecialProvisions(input, provider);
            result = DoTransliteration(result, provider);

            return result;
        }

        private static ITransliterationProvider GetProvider(TransliterationType type)
        {
            switch (type)
            {
                case TransliterationType.Bulgarian:
                    return new BulgarianTranslitarationProvider();
                default:
                    throw new InvalidEnumArgumentException("No such provider exists");
            }
        }

        private static string ApplySpecialProvisions(string input, ITransliterationProvider provider)
        {
            var result = input;
            var specialProvisions = provider.GetSpecialProvisions();
            foreach (var specialProvision in specialProvisions)
            {
                if (specialProvision.Condition(result))
                {
                    result = specialProvision.Transformation(result);
                }
            }

            return result;
        }

        private static string DoTransliteration(string input, ITransliterationProvider provider)
        {
            var map = provider.GetToEnglishMappings();
            var result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                var isUpper = char.IsUpper(currentChar);
                var stringKey = currentChar.ToString().ToLower();
                string charResult;

                if (map.TryGetValue(stringKey, out charResult))
                {
                    result.Append(isUpper ? charResult.Capitalize() : charResult);
                    continue;
                }

                result.Append(currentChar);
            }

            return result.ToString();
        }
    }
}

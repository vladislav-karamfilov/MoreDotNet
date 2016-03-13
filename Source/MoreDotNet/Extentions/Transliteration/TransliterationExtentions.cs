namespace MoreDotNet.Extentions.Transliteration
{
    using System.ComponentModel;
    using System.Text;

    using MoreDotNet.Extentions.Common;
    using MoreDotNet.Extentions.Transliteration.Providers;
    using MoreDotNet.Extentions.Transliteration.Providers.Contracts;
    using MoreDotNet.Models;

    public static class TransliterationExtentions
    {
        public static string Transliterate(this string input, TransliterationType type)
        {
            var provider = GetProvider(type);
            var result = DoTransliteration(input, provider);

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

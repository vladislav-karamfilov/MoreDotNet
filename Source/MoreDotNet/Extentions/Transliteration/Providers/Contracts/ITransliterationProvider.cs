namespace MoreDotNet.Extentions.Transliteration.Providers.Contracts
{
    using System.Collections.Generic;

    public interface ITransliterationProvider
    {
        IDictionary<string, string> GetToEnglishMappings();

        ////IDictionary<string, string> GetToTransliterationLanguageMapings();
    }
}

namespace MoreDotNet.Transliteration.Transliteration.Providers.Contracts
{
    using System.Collections.Generic;

    using MoreDotNet.Transliteration.Transliteration.Models;

    public interface ITransliterationProvider
    {
        IDictionary<string, string> GetToEnglishMappings();

        IEnumerable<SpecialProvision> GetSpecialProvisions();

        ////IDictionary<string, string> GetToTransliterationLanguageMapings();
    }
}

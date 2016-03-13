namespace MoreDotNet.Extentions.Transliteration.Providers.Contracts
{
    using System.Collections.Generic;

    using MoreDotNet.Extentions.Transliteration.Models;

    public interface ITransliterationProvider
    {
        IDictionary<string, string> GetToEnglishMappings();

        IEnumerable<SpecialProvision> GetSpecialProvisions();

        ////IDictionary<string, string> GetToTransliterationLanguageMapings();
    }
}

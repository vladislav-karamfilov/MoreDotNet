namespace MoreDotNet.Transliteration.Transliteration.Models
{
    using System;

    public class SpecialProvision
    {
        public Func<string, bool> Condition { get; set; }

        public Func<string, string> Transformation { get; set; }
    }
}

namespace MoreDotNet.Runner
{
    using System;

    using MoreDotNet.Extentions.Common;
    using MoreDotNet.Models;
    using MoreDotNet.Transliteration.Transliteration;
    using MoreDotNet.Transliteration.Transliteration.Models;
    using MoreDotNet.Wrappers;

    public class Program
    {
        public static void Main(string[] args)
        {
            var sampleVariable = "Славея";

            Console.WriteLine(sampleVariable.Transliterate(TransliterationType.Bulgarian));
        }
    }
}

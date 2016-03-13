namespace MoreDotNet.Runner
{
    using System;

    using MoreDotNet.Extentions.Common;
    using MoreDotNet.Extentions.Transliteration;
    using MoreDotNet.Extentions.Transliteration.Models;
    using MoreDotNet.Models;
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

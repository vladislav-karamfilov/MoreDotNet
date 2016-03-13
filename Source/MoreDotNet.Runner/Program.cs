namespace MoreDotNet.Runner
{
    using System;

    using MoreDotNet.Extentions.Common;
    using MoreDotNet.Extentions.Transliteration;
    using MoreDotNet.Models;
    using MoreDotNet.Wrappers;

    public class Program
    {
        public static void Main(string[] args)
        {
            var sampleVariable = "Интересен експериемент с котка.";

            Console.WriteLine(sampleVariable.Transliterate(TransliterationType.Bulgarian));
        }
    }
}

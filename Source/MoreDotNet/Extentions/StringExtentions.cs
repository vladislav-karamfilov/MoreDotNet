namespace MoreDotNet.Extentions
{
    using System.Text.RegularExpressions;
    using System.Threading;

    public static class StringExtentions
    {
        public static string ToTitleCase(this string inputText)
        {
            if (inputText == null)
            {
                return null;
            }

            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;

            // TextInfo.ToTitleCase only operates on the string if is all lower case, otherwise it returns the string unchanged.
            return textInfo.ToTitleCase(inputText.ToLower());
        }

        public static string ToWords(this string camelCaseWord)
        {
            // if the word is all upper, just return it
            if (!Regex.IsMatch(camelCaseWord, "[a-z]"))
            {
                return camelCaseWord;
            }

            return string.Join(" ", Regex.Split(camelCaseWord, @"(?<!^)(?=[A-Z])"));
        }

        public static string Capitalize(this string word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1);
        }
    }
}

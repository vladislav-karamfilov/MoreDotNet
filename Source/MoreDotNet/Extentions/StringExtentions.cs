namespace MoreDotNet.Extentions
{
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
    }
}

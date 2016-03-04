namespace MoreDotNet.Extentions
{
    using System;
    using System.Globalization;
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

        /// <summary>
        /// Indicates whether the current string matches the supplied wildcard pattern.  Behaves the same
        /// as VB's "Like" Operator.
        /// </summary>
        /// <param name="s">The string instance where the extension method is called</param>
        /// <param name="wildcardPattern">The wildcard pattern to match.  Syntax matches VB's Like operator.</param>
        /// <returns>true if the string matches the supplied pattern, false otherwise.</returns>
        /// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx</remarks>
        public static bool IsLike(this string s, string wildcardPattern)
        {
            if (s == null || string.IsNullOrEmpty(wildcardPattern))
            {
                return false;
            }

            // turn into regex pattern, and match the whole string with ^$
            var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";

            // add support for ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            bool result;
            try
            {
                result = Regex.IsMatch(s, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(string.Format("Invalid pattern: {0}", wildcardPattern), ex);
            }

            return result;
        }


        // TODO: Review
        public static string ToReadableTime(this DateTime value)
        {
            TimeSpan span = DateTime.Now.Subtract(value);
            const string Plural = "s";


            if (span.Days > 7)
            {
                return value.ToShortDateString();
            }

            switch (span.Days)
            {
                case 0:
                    switch (span.Hours)
                    {
                        case 0:
                            if (span.Minutes == 0)
                            {
                                return span.Seconds <= 0
                                           ? "now"
                                           : string.Format(
                                               "{0} second{1} ago",
                                               span.Seconds,
                                               span.Seconds != 1 ? Plural : string.Empty);
                            }
                            return string.Format(
                                "{0} minute{1} ago",
                                span.Minutes,
                                span.Minutes != 1 ? Plural : string.Empty);
                        default:
                            return string.Format("{0} hour{1} ago", span.Hours, span.Hours != 1 ? Plural : string.Empty);
                    }
                default:
                    return string.Format("{0} day{1} ago", span.Days, span.Days != 1 ? Plural : string.Empty);
            }
        }

        public static string ToShortGuidString(this Guid value)
        {
            return Convert.ToBase64String(value.ToByteArray())
                .Replace("/", "_")
                .Replace("+", "-")
                .Substring(0, 22);
        }

        public static Guid FromShortGuidString(this string value)
        {
            return new Guid(Convert.FromBase64String(value.Replace("_", "/")
                                                         .Replace("-", "+") + "=="));
        }

        public static string ToStringMaximumLength(this string value, int maximumLength, string postFixText = "...")
        {
            if (string.IsNullOrWhiteSpace(postFixText))
            {
                throw new ArgumentNullException("postFixText");
            }

            if (value.Length > maximumLength)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}{1}",
                    value.Substring(0, maximumLength - postFixText.Length),
                    postFixText);
            }

            return value;
        }
    }
}

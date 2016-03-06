namespace MoreDotNet.Extentions
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;

    using MoreDotNet.Wrappers;

    public static class StringExtentions
    {
        /// <summary>
        /// Provides a title case of the supplied string.
        /// </summary>
        /// <param name="input">The string instance where the extension method is called.</param>
        /// <returns>The string in title case.</returns>
        public static string ToTitleCase(this string input)
        {
            if (input == null)
            {
                return null;
            }

            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;

            // TextInfo.ToTitleCase only operates on the string if is all lower case, otherwise it returns the string unchanged.
            return textInfo.ToTitleCase(input);
        }

        /// <summary>
        /// Transforms a pascal case or camel case string to separate words.
        /// </summary>
        /// <param name="input">The string instance where the extension method is called.</param>
        /// <returns>The separated words.</returns>
        public static string CaseToWords(this string input)
        {
            input.ThrowIfArgumentIsNull("input");

            // if the input is all upper, just return it
            if (!Regex.IsMatch(input, "[a-z]"))
            {
                return input;
            }

            return string.Join(" ", Regex.Split(input, @"(?<!^)(?=[A-Z])"));
        }

        /// <summary>
        /// Makes the first character of a string upper case.
        /// </summary>
        /// <param name="input">The string instance where the extension method is called.</param>
        /// <returns>The capitalized word.</returns>
        public static string Capitalize(this string input)
        {
            if (input.IsNullOrWhiteSpace())
            {
                return input;
            }

            return input[0].ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// Indicates whether the current string matches the supplied wild-card pattern.  Behaves the same
        /// as VB'input "Like" Operator.
        /// </summary>
        /// <param name="input">The string instance where the extension method is called</param>
        /// <param name="wildcardPattern">The wild-card pattern to match.  Syntax matches VB'input Like operator.</param>
        /// <returns>true if the string matches the supplied pattern, false otherwise.</returns>
        /// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx</remarks>
        public static bool IsLike(this string input, string wildcardPattern)
        {
            if (input == null || string.IsNullOrEmpty(wildcardPattern))
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
                result = Regex.IsMatch(input, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(string.Format("Invalid pattern: {0}", wildcardPattern), ex);
            }

            return result;
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

        public static int NthIndexOf(this string str, string match, int occurrence)
        {
            int i = 1;
            int index = 0;

            while (i <= occurrence &&
                (index = str.IndexOf(match, index + 1, StringComparison.Ordinal)) != -1)
            {

                if (i == occurrence)
                {
                    // Occurrence match found!
                    return index;
                }
                i++;
            }

            // Match not found
            return -1;
        }

        public static string RemoveLastCharacter(this string input)
        {
            return input.Substring(0, input.Length - 1);
        }

        public static string RemoveLast(this string input, int number)
        {
            return input.Substring(0, input.Length - number);
        }

        public static string RemoveFirstCharacter(this string input)
        {
            return input.Substring(1);
        }

        public static string RemoveFirst(this string input, int number)
        {
            return input.Substring(number);
        }

        // TODO: Test!
        public static bool IsValue<T>(this string input)
        {
            T temp;

            var type = typeof(T);
            var converter = TypeDescriptor.GetConverter(type);

            try
            {
                converter.ConvertFromInvariantString(input);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

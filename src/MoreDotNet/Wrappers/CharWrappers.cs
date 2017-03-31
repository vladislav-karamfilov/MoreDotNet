namespace MoreDotNet.Wrappers
{
    using System.Globalization;

    public static class CharWrappers
    {
        public static char ToLower(this char input)
        {
            return char.ToLower(input);
        }

        public static char ToLower(this char input, CultureInfo cultureInfo)
        {
            return char.ToLower(input, cultureInfo);
        }

        public static char ToLowerInvariant(this char input)
        {
            return char.ToLowerInvariant(input);
        }

        public static char ToUpper(this char input)
        {
            return char.ToUpper(input);
        }

        public static char ToUpper(this char input, CultureInfo cultureInfo)
        {
            return char.ToUpper(input, cultureInfo);
        }

        public static char ToUpperInvariant(this char input)
        {
            return char.ToUpperInvariant(input);
        }

        public static bool IsControl(this char input)
        {
            return char.IsControl(input);
        }

        public static bool IsDigit(this char input)
        {
            return char.IsDigit(input);
        }

        public static bool IsHighSurrogate(this char input)
        {
            return char.IsHighSurrogate(input);
        }

        public static bool IsLetter(this char input)
        {
            return char.IsLetter(input);
        }

        public static bool IsLetterOrDigit(this char input)
        {
            return char.IsLetterOrDigit(input);
        }

        public static bool IsLowSurrogate(this char input)
        {
            return char.IsLowSurrogate(input);
        }

        public static bool IsLower(this char input)
        {
            return char.IsLower(input);
        }

        public static bool IsNumber(this char input)
        {
            return char.IsNumber(input);
        }

        public static bool IsPunctuation(this char input)
        {
            return char.IsPunctuation(input);
        }

        public static bool IsSeparator(this char input)
        {
            return char.IsSeparator(input);
        }

        public static bool IsSurrogate(this char input)
        {
            return char.IsSurrogate(input);
        }

        public static bool IsSymbol(this char input)
        {
            return char.IsSymbol(input);
        }

        public static bool IsUpper(this char input)
        {
            return char.IsUpper(input);
        }

        public static bool IsWhiteSpace(this char input)
        {
            return char.IsWhiteSpace(input);
        }

        public static double GetNumericValue(this char input)
        {
            return char.GetNumericValue(input);
        }

        public static UnicodeCategory GetUnicodeCategory(this char input)
        {
            return char.GetUnicodeCategory(input);
        }
    }
}

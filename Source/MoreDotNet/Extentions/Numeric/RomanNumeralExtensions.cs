namespace MoreDotNet.Extentions.Numeric
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    using MoreDotNet.Extentions.Common;

    /// <summary>
    /// Roman numerals extensions.
    /// </summary>
    public static class RomanNumeralExtensions
    {
        private const int NumberOfRomanNumeralMaps = 13;

        private static readonly IDictionary<string, int> RomanNumerals =
            new Dictionary<string, int>(NumberOfRomanNumeralMaps)
            {
                { "M", 1000 },
                { "CM", 900 },
                { "D", 500 },
                { "CD", 400 },
                { "C", 100 },
                { "XC", 90 },
                { "L", 50 },
                { "XL", 40 },
                { "X", 10 },
                { "IX", 9 },
                { "V", 5 },
                { "IV", 4 },
                { "I", 1 }
            };

        private static readonly Regex ValidRomanNumeral = new Regex(
            "^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))"
            + "?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$",
            RegexOptions.Compiled);

        /// <summary>
        /// Check if a given string represents a valid roman numeral.
        /// </summary>
        /// <param name="input">The string being checked.</param>
        /// <returns>True if a given string represents a valid roman numeral. False otherwise.</returns>
        public static bool IsValidRomanNumeral(this string input)
        {
            return ValidRomanNumeral.IsMatch(input);
        }

        /// <summary>
        /// Converts a string representing a roman numeral to a decimal integer.
        /// </summary>
        /// <param name="input">The string being converted.</param>
        /// <returns>A <see cref="int"/> representing the roman numeral.</returns>
        public static int ParseRomanNumeral(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            input = input.ToUpperInvariant().Trim();

            var length = input.Length;

            if ((length == 0) || !input.IsValidRomanNumeral())
            {
                throw new ArgumentException("Empty or invalid Roman numeral string.", nameof(input));
            }

            var total = 0;
            var i = length;

            while (i > 0)
            {
                var digit = RomanNumerals[input[--i].ToString()];

                if (i > 0)
                {
                    var previousDigit = RomanNumerals[input[i - 1].ToString()];

                    if (previousDigit < digit)
                    {
                        digit -= previousDigit;
                        i--;
                    }
                }

                total += digit;
            }

            return total;
        }

        /// <summary>
        /// Converts a decimal integer to string representing a roman numeral.
        /// </summary>
        /// <param name="input">The integer being converted.</param>
        /// <returns>A string representing a valid roman numeral.</returns>
        public static string ToRomanNumeralString(this int input)
        {
            const int MinValue = 1;
            const int MaxValue = 3999;

            if ((input < MinValue) || (input > MaxValue))
            {
                throw new ArgumentOutOfRangeException("input", input, "Argument out of Roman numeral range.");
            }

            const int MaxRomanNumeralLength = 15;
            var sb = new StringBuilder(MaxRomanNumeralLength);

            foreach (var pair in RomanNumerals)
            {
                while (input / pair.Value > 0)
                {
                    sb.Append(pair.Key);
                    input -= pair.Value;
                }
            }

            return sb.ToString();
        }
    }
}

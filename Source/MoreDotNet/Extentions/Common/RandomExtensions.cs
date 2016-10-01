namespace MoreDotNet.Extentions.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Models;

    /// <summary>
    /// <see cref="Random"/> extensions.
    /// </summary>
    public static class RandomExtensions
    {
        // 10 digits vs. 52 alphabetic characters (upper & lower);
        // probability of being numeric: 10 / 62 = 0.1612903225806452
        private const double AlphanumericProbabilityNumericAny = 10.0 / 62.0;

        // 10 digits vs. 26 alphabetic characters (upper OR lower);
        // probability of being numeric: 10 / 36 = 0.2777777777777778
        private const double AlphanumericProbabilityNumericCased = 10.0 / 36.0;

        /// <summary>
        /// Chooses a random item form a sequence of items.
        /// </summary>
        /// <typeparam name="T">The item type of the items collection</typeparam>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="items">A sequence of items to choose from.</param>
        /// <returns>The random item.</returns>
        public static T OneOf<T>(this Random random, params T[] items)
        {
            int index = random.Next(0, items.Length);
            return items[index];
        }

        /// <summary>
        /// Chooses a random item form a enumeration of items.
        /// </summary>
        /// <typeparam name="T">The item type of the items collection</typeparam>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="items">A enumeration of items to choose from.</param>
        /// <returns>The random item.</returns>
        public static T OneOf<T>(this Random random, IEnumerable<T> items)
        {
            int index = random.Next(0, items.Count());
            return items.ElementAt(index);
        }

        /// <summary>
        /// Chooses a random boolean value depending on a given probability.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="probability">The probability for a true return.</param>
        /// <returns>A random boolean value.</returns>
        public static bool NextBool(this Random random, double probability = 0.5)
        {
            return random.NextDouble() <= probability;
        }

        /// <summary>
        /// Gets a random alphanumeric character.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <returns>An alphanumeric character.</returns>
        public static char NextChar(this Random random)
        {
            return random.NextChar(CharType.AlphanumericAny);
        }

        /// <summary>
        /// Gets a random character depending on a <see cref="CharType"/>.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="mode">The type of random character.</param>
        /// <returns>A random character.</returns>
        public static char NextChar(this Random random, CharType mode)
        {
            switch (mode)
            {
                case CharType.AnyUnicode:
                    return random.NextUnicodeChar();
                case CharType.AlphabeticAny:
                    return random.NextAlphabeticChar();
                case CharType.AlphabeticLower:
                    return random.NextAlphabeticChar(false);
                case CharType.AlphabeticUpper:
                    return random.NextAlphabeticChar(true);
                case CharType.AlphanumericAny:
                    return random.NextAlphanumericChar();
                case CharType.AlphanumericLower:
                    return random.NextAlphanumericChar(false);
                case CharType.AlphanumericUpper:
                    return random.NextAlphanumericChar(true);
                case CharType.Numeric:
                    return random.NextNumericChar();
                default:
                    return random.NextAlphanumericChar();
            }
        }

        /// <summary>
        /// Gets a random <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <returns>A <see cref="DateTime"/> value.</returns>
        public static DateTime NextDateTime(this Random random)
        {
            return random.NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// Gets a random <see cref="DateTime"/> value in a given range.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="minValue">The start of the range.</param>
        /// <param name="maxValue">The end of the range.</param>
        /// <returns>A random <see cref="DateTime"/> value.</returns>
        public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
        {
            return DateTime.FromOADate(random.NextDouble(minValue.ToOADate(), maxValue.ToOADate()));
        }

        /// <summary>
        /// A random <see cref="double"/> value in a given range.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="minValue">The start of the range.</param>
        /// <param name="maxValue">The end of the range.</param>
        /// <returns>A random <see cref="double"/> value.</returns>
        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            if (maxValue < minValue)
            {
                throw new ArgumentException("Minimum value must be less than maximum value.");
            }

            double difference = maxValue - minValue;
            if (!double.IsInfinity(difference))
            {
                return minValue + (random.NextDouble() * difference);
            }

            // to avoid evaluating to Double.Infinity, we split the range into two halves:
            var halfDifference = (maxValue * 0.5) - (minValue * 0.5);

            // 50/50 chance of returning a value from the first or second half of the range
            if (random.NextBool())
            {
                return minValue + (random.NextDouble() * halfDifference);
            }

            return (minValue + halfDifference) + (random.NextDouble() * halfDifference);
        }

        /// <summary>
        /// Gets a random alphanumeric <see cref="string"/> value.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="numChars">The number of characters in the string.</param>
        /// <returns>A random string.</returns>
        public static string NextString(this Random random, int numChars)
        {
            return random.NextString(numChars, CharType.AlphanumericAny);
        }

        /// <summary>
        /// Gets a random <see cref="string"/> value consisting of specific characters.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="numChars">The number of characters in the string.</param>
        /// <param name="mode">The type of characters for the string.</param>
        /// <returns>A random string.</returns>
        public static string NextString(this Random random, int numChars, CharType mode)
        {
            char[] chars = new char[numChars];

            for (int i = 0; i < numChars; ++i)
            {
                chars[i] = random.NextChar(mode);
            }

            return new string(chars);
        }

        /// <summary>
        /// Gets a random <see cref="TimeSpan"/> value.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <returns>A random <see cref="TimeSpan"/> value.</returns>
        public static TimeSpan NextTimeSpan(this Random random)
        {
            return random.NextTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue);
        }

        /// <summary>
        /// Gets a random <see cref="TimeSpan"/> value in a given range.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance on which the extension method is called.</param>
        /// <param name="minValue">The start of the range.</param>
        /// <param name="maxValue">The end of the range.</param>
        /// <returns>A random <see cref="TimeSpan"/> value.</returns>
        public static TimeSpan NextTimeSpan(this Random random, TimeSpan minValue, TimeSpan maxValue)
        {
            return TimeSpan.FromMilliseconds(random.NextDouble(minValue.TotalMilliseconds, maxValue.TotalMilliseconds));
        }

        private static char NextAlphanumericChar(this Random random, bool uppercase)
        {
            bool numeric = random.NextBool(AlphanumericProbabilityNumericCased);

            if (numeric)
            {
                return random.NextNumericChar();
            }

            return random.NextAlphabeticChar(uppercase);
        }

        private static char NextAlphanumericChar(this Random random)
        {
            bool numeric = random.NextBool(AlphanumericProbabilityNumericAny);

            if (numeric)
            {
                return random.NextNumericChar();
            }

            return random.NextAlphabeticChar(random.NextBool());
        }

        private static char NextAlphabeticChar(this Random random, bool uppercase)
        {
            if (uppercase)
            {
                return (char)random.Next(65, 91);
            }

            return (char)random.Next(97, 123);
        }

        private static char NextAlphabeticChar(this Random random)
        {
            return random.NextAlphabeticChar(random.NextBool());
        }

        private static char NextNumericChar(this Random random)
        {
            return (char)random.Next(48, 58);
        }

        private static char NextUnicodeChar(this Random random)
        {
            return (char)random.Next(0, 65536);
        }
    }
}

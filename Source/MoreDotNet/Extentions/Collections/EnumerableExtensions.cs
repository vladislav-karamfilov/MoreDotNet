namespace MoreDotNet.Extentions.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MoreDotNet.Extentions.Common;

    /// <summary>
    /// <see cref="IEnumerable{T}"/> extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Executes an <see cref="Action{T}"/> on every element of the <paramref name="items"/>.
        /// </summary>
        /// <typeparam name="T">The item type of the <see cref="items"/>.</typeparam>
        /// <param name="items">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <param name="mapFunction">The action to be executed.</param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> mapFunction)
        {
            foreach (var item in items)
            {
                mapFunction(item);
            }
        }

        /// <summary>
        /// Returns and empty <see cref="IEnumerable{T}"/> collection if <paramref name="items"/> is null.
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="items">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <returns>The <paramref name="items"/> collection or an empty <see cref="IEnumerable{T}"/> collection.</returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> items)
        {
            return items ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Shuffles the elements of a <see cref="IEnumerable{T}"/> collection.
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="items">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <returns>A new collection with the snuffled elements from <paramref name="items"/>.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
        {
            return items.Shuffle(new Random());
        }

        /// <summary>
        /// Shuffles the elements of a <see cref="IEnumerable{T}"/> collection using a random generator.
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="items">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <param name="randomGenerator">А <see cref="Random"/> instance, used to shuffle the elements.</param>
        /// <returns>A new collection with the snuffled elements from <paramref name="items"/>.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, Random randomGenerator)
        {
            items.ThrowIfArgumentIsNull("source");
            randomGenerator.ThrowIfArgumentIsNull("randomGenerator");

            return items.ShuffleIterator(randomGenerator);
        }

        /// <summary>
        /// Generates a string from the elements of an <see cref="IEnumerable{T}"/> using a given separator.
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="items">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <param name="separator">The string separation used when generation the string.</param>
        /// <returns>A string from the elements of an <see cref="IEnumerable{T}"/> using a given separator.</returns>
        public static string ToString<T>(this IEnumerable<T> items, string separator)
        {
            return ToString(items, t => t.ToString(), separator);
        }

        /// <summary>
        /// Generates a string from the transformed elements of an <see cref="IEnumerable{T}"/> using a given separator.
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="items">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <param name="stringElement">The function used to transform the elements of the <see cref="IEnumerable{T}"/>.</param>
        /// <param name="separator">The string separation used when generation the string.</param>
        /// <returns>A string from the transformed elements of an <see cref="IEnumerable{T}"/> using a given separator.</returns>
        public static string ToString<T>(this IEnumerable<T> items, Func<T, string> stringElement, string separator)
        {
            var output = new StringBuilder();
            foreach (var item in items)
            {
                output.Append(stringElement(item));
                output.Append(separator);
            }

            return output.ToString(0, Math.Max(0, output.Length - separator.Length));
        }

        /// <summary>
        /// Checks if the <see cref="IEnumerable{T}"/> is null or empty
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <returns>True if the collection is null or empty, false otherwise.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> items, Random rng)
        {
            var buffer = items.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}

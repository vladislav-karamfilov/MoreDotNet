namespace MoreDotNet.Extentions.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class EnumerableExtentions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> mapFunction)
        {
            foreach (var item in collection)
            {
                mapFunction(item);
            }
        }

        /// <summary>
        /// Checks if the <see cref="IEnumerable{T}"/> is null or empty.
        /// </summary>
        /// <typeparam name="T">The item type of the <param name="items"></param> enumeration.</typeparam>
        /// <param name="items">The <see cref="IEnumerable{T}"/> instance on which the extension method is called.</param>
        /// <returns>True of the <see cref="IEnumerable{T}"/> is null or empty. Otherwise - false.</returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> items)
        {
            return items ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random randomGenerator)
        {
            source.ThrowIfArgumentIsNull("source");
            randomGenerator.ThrowIfArgumentIsNull("randomGenerator");

            return source.ShuffleIterator(randomGenerator);
        }

        public static string ToString<T>(this IEnumerable<T> collection, string separator)
        {
            return ToString(collection, t => t.ToString(), separator);
        }

        public static string ToString<T>(this IEnumerable<T> collection, Func<T, string> stringElement, string separator)
        {
            var sb = new StringBuilder();
            foreach (var item in collection)
            {
                sb.Append(stringElement(item));
                sb.Append(separator);
            }

            return sb.ToString(0, Math.Max(0, sb.Length - separator.Length));
        }

        public static T ObjectWithMin<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> predicate)
            where T : class
            where TResult : IComparable
        {
            if (!sequence.Any())
            {
                return null;
            }

            // get the first object with its predicate value
            var seed = sequence.Select(x => new { Object = x, Value = predicate(x) }).FirstOrDefault();

            // compare against all others, replacing the accumulator with the lesser value
            // tie goes to first object found
            return sequence
                .Select(x => new { Object = x, Value = predicate(x) })
                .Aggregate(seed, (acc, x) => acc.Value.CompareTo(x.Value) <= 0 ? acc : x).Object;
        }

        public static T ObjectWithMax<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> predicate)
            where T : class
            where TResult : IComparable
        {
            if (!sequence.Any())
            {
                return null;
            }

            // get the first object with its predicate value
            var seed = sequence
                .Select(x => new { Object = x, Value = predicate(x) })
                .FirstOrDefault();

            // compare against all others, replacing the accumulator with the greater value
            // tie goes to last object found
            return sequence
                    .Select(x => new { Object = x, Value = predicate(x) })
                    .Aggregate(seed, (acc, x) => acc.Value.CompareTo(x.Value) > 0 ? acc : x).Object;
        }

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}

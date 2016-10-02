namespace MoreDotNet.Extensions.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// <see cref="ICollection{T}"/> extensions.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds a range of values to an ICollection.
        /// </summary>
        /// <typeparam name="T">The element type of the ICollection.</typeparam>
        /// <param name="items">The <see cref="ICollection{T}"/> instance on which the extension method is called.</param>
        /// <param name="values">The items we are adding to the ICollection.</param>
        public static void AddRange<T>(this ICollection<T> items, params T[] values)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (var value in values)
            {
                items.Add(value);
            }
        }

        /// <summary>
        /// Adds a range of values to an ICollection.
        /// </summary>
        /// <typeparam name="T">The element type of the ICollection.</typeparam>
        /// <param name="items">The <see cref="ICollection{T}"/> instance on which the extension method is called.</param>
        /// <param name="values">The items we are adding to the ICollection.</param>
        public static void AddRange<T>(this ICollection<T> items, IEnumerable<T> values)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (var value in values)
            {
                items.Add(value);
            }
        }
    }
}

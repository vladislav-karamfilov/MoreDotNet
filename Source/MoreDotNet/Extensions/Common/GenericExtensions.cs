namespace MoreDotNet.Extensions.Common
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Generic types extensions.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Checks if a <see cref="IComparable{T}"/> item is within a given range.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="actual">The item we are checking.</param>
        /// <param name="lowerBound">Range start.</param>
        /// <param name="upperBound">Range end.</param>
        /// <returns>True if the element is in the given range. False otherwise.</returns>
        public static bool IsBetween<T>(this T actual, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return actual.CompareTo(lowerBound) >= 0 && actual.CompareTo(upperBound) < 0;
        }

        /// <summary>
        /// Gets the name an object member as a <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <typeparam name="TResult">The member type.</typeparam>
        /// <param name="anyObject">The object itself.</param>
        /// <param name="expression">The expression for acquiring the member.</param>
        /// <returns>The name an object member as a <see cref="string"/>.</returns>
        public static string GetMemberName<T, TResult>(
            this T anyObject,
            Expression<Func<T, TResult>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return ((MemberExpression)expression.Body).Member.Name;
        }
    }
}

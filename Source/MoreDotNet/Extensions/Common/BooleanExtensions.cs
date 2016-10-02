namespace MoreDotNet.Extensions.Common
{
    using System;

    /// <summary>
    /// <see cref="bool"/> extensions.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Executes <see cref="Func{TResult}"/> and returns <see cref="TResult"/> if the input value is true.
        /// </summary>
        /// <typeparam name="TResult">Result type of the <see cref="Func{TResult}"/> execution.</typeparam>
        /// <param name="value">The <see cref="bool"/> instance on which the extension method is called.</param>
        /// <param name="expression"><see cref="Func{TResult}"/> to be executed.</param>
        /// <returns>A <see cref="TResult"/> value.</returns>
        public static TResult WhenTrue<TResult>(this bool value, Func<TResult> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return value ? expression() : default(TResult);
        }

        /// <summary>
        /// Returns a <see cref="TResult"/> if the input value is true.
        /// </summary>
        /// <typeparam name="TResult">The type to be returned.</typeparam>
        /// <param name="value">The <see cref="bool"/> instance on which the extension method is called.</param>
        /// <param name="content">Value to be returned if the input is true.</param>
        /// <returns>A <see cref="TResult"/> value.</returns>
        public static TResult WhenTrue<TResult>(this bool value, TResult content)
        {
            return value ? content : default(TResult);
        }

        /// <summary>
        /// Executes <see cref="Func{TResult}"/> and returns <see cref="TResult"/> if the input value is false.
        /// </summary>
        /// <typeparam name="TResult">Result type of the <see cref="Func{TResult}"/> execution.</typeparam>
        /// <param name="value">The <see cref="bool"/> instance on which the extension method is called.</param>
        /// <param name="expression"><see cref="Func{TResult}"/> to be executed.</param>
        /// <returns>A <see cref="TResult"/> value.</returns>
        public static TResult WhenFalse<TResult>(this bool value, Func<TResult> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return !value ? expression() : default(TResult);
        }

        /// <summary>
        /// Returns a <see cref="TResult"/> if the input value is false.
        /// </summary>
        /// <typeparam name="TResult">The type to be returned.</typeparam>
        /// <param name="value">The <see cref="bool"/> instance on which the extension method is called.</param>
        /// <param name="content">Value to be returned if the input is false.</param>
        /// <returns>A <see cref="TResult"/> value.</returns>
        public static TResult WhenFalse<TResult>(this bool value, TResult content)
        {
            return !value ? content : default(TResult);
        }
    }
}

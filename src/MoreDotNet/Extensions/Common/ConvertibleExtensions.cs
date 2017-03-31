namespace MoreDotNet.Extensions.Common
{
    using System;

    /// <summary>
    /// <see cref="IConvertible"/> extensions.
    /// </summary>
    public static class ConvertibleExtensions
    {
        /// <summary>
        /// Converts an <see cref="IConvertible"/> object to the <see cref="T"/> type.
        /// </summary>
        /// <typeparam name="T">Type to be converted to.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <returns>The converted object.</returns>
        public static T To<T>(this IConvertible obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        /// <summary>
        /// Converts an <see cref="IConvertible"/> object to the <see cref="T"/> type or returns the default value of the <see cref="T"/> type.
        /// </summary>
        /// <typeparam name="T">Type to be converted to.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <returns>The converted object or its default value.</returns>
        public static T ToOrDefault<T>(this IConvertible obj)
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Converts an <see cref="IConvertible"/> object to the <see cref="T"/> type and assigns it to the <paramref name="newObj"/> or assigns the default value of the <see cref="T"/> type.
        /// </summary>
        /// <typeparam name="T">Type to be converted to.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <param name="newObj">Object to which the result is assigned.</param>
        /// <returns>True if conversion is successful or false otherwise.</returns>
        public static bool ToOrDefault<T>(this IConvertible obj, out T newObj)
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = default(T);
                return false;
            }
        }

        /// <summary>
        /// Converts an <see cref="IConvertible"/> object to the <see cref="T"/> type or returns the <paramref name="other"/> object.
        /// </summary>
        /// <typeparam name="T">Type to be converted to.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <param name="other">Object to be returned in case of failure.</param>
        /// <returns>The converted object of type <see cref="T"/> or its alternative <paramref name="other"/></returns>
        public static T ToOrOther<T>(this IConvertible obj, T other)
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return other;
            }
        }

        /// <summary>
        /// Converts an <see cref="IConvertible"/> object to the <see cref="T"/> type and assigns it to the <paramref name="newObj"/>. If that is not possible assigns the <paramref name="other"/> to <paramref name="newObj"/>.
        /// </summary>
        /// <typeparam name="T">Type to be converted to.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <param name="newObj">Object to which the result is assigned.</param>
        /// <param name="other">Object to be assigned in case of failure.</param>
        /// <returns>True if conversion is successful or false otherwise.</returns>
        public static bool ToOrOther<T>(this IConvertible obj, out T newObj, T other)
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = other;
                return false;
            }
        }

        /// <summary>
        /// Converts an <see cref="IConvertible"/> object to the <see cref="T"/> type or returns null.
        /// </summary>
        /// <typeparam name="T">Type to be converted to.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <returns>The converted object or null.</returns>
        public static T ToOrNull<T>(this IConvertible obj)
            where T : class
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converts an <see cref="IConvertible"/> object to the <see cref="T"/> type and assigns the result to <paramref name="newObj"/>. If that is not possible assigns null.
        /// </summary>
        /// <typeparam name="T">Type to be converted to.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <param name="newObj">Object to which the result is assigned.</param>
        /// <returns>True if conversion is successful or false otherwise.</returns>
        public static bool ToOrNull<T>(this IConvertible obj, out T newObj)
            where T : class
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = null;
                return false;
            }
        }
    }
}

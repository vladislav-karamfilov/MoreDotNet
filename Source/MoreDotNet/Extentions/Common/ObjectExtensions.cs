namespace MoreDotNet.Extentions.Common
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// <see cref="object"/> extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Determents if the object <paramref name="item"/> is a <see cref="T"/> type.
        /// </summary>
        /// <typeparam name="T">The type to check for.</typeparam>
        /// <param name="item">The object being checked.</param>
        /// <returns>True if the object is a <see cref="T"/> type. False otherwise.</returns>
        public static bool Is<T>(this object item)
            where T : class
        {
            return item is T;
        }

        /// <summary>
        /// Determents if the object <paramref name="item"/> is not a <see cref="T"/> type.
        /// </summary>
        /// <typeparam name="T">The type to check for.</typeparam>
        /// <param name="item">The object being checked.</param>
        /// <returns>True if the object is not a <see cref="T"/> type. False otherwise.</returns>
        public static bool IsNot<T>(this object item)
            where T : class
        {
            return !item.Is<T>();
        }

        /// <summary>
        /// Casts the object <paramref name="item"/> to <see cref="T"/> type.
        /// </summary>
        /// <typeparam name="T">Type to be cast to.</typeparam>
        /// <param name="item">The object being cast.</param>
        /// <returns>The casted object or null.</returns>
        public static T As<T>(this object item)
            where T : class
        {
            return item as T;
        }

        /// <summary>
        /// Converts an object to a <see cref="IDictionary{TKey,TValue}"/> containing the properties names as keys and their contents as values.
        /// </summary>
        /// <param name="o">The object to convert.</param>
        /// <returns>A <see cref="IDictionary{TKey,TValue}"/> containing the properties names as keys and their contents as values.</returns>
        public static IDictionary<string, object> ToDictionary(this object o)
        {
            return o
                .GetType()
                .GetProperties()
                .Where(propertyInfo => propertyInfo.GetIndexParameters().Length == 0)
                .ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(o, null));
        }
    }
}

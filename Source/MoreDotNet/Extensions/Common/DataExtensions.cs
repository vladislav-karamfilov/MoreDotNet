namespace MoreDotNet.Extensions.Common
{
    using System;
    using System.Data;

    /// <summary>
    /// Data related extensions.
    /// </summary>
    public static class DataExtensions
    {
        /// <summary>
        /// Safely gets a value from a <see cref="IDataRecord"/> item.
        /// </summary>
        /// <typeparam name="T">Type of the requested item.</typeparam>
        /// <param name="dataRecord">The <see cref="IDataRecord"/> instance on which the extension method is called.</param>
        /// <param name="ordinal">The ordinal of the value we want to acquire.</param>
        /// <returns>The value corresponding to the given ordinal.</returns>
        public static T GetNullable<T>(this IDataRecord dataRecord, int ordinal)
        {
            if (dataRecord == null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            return dataRecord.IsDBNull(ordinal) ? default(T) : (T)dataRecord.GetValue(ordinal);
        }
    }
}

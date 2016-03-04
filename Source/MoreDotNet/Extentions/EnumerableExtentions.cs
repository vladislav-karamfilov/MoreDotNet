namespace MoreDotNet.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtentions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> mapFunction)
        {
            foreach (var item in collection)
            {
                mapFunction(item);
            }
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> pSeq)
        {
            return pSeq ?? Enumerable.Empty<T>();
        }
    }
}

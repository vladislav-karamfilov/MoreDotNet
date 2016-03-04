namespace MoreDotNet.Extentions
{
    using System;
    using System.Collections.Generic;

    public static class EnumerableExtentions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> mapFunction)
        {
            foreach (var item in collection)
            {
                mapFunction(item);
            }
        }
    }
}

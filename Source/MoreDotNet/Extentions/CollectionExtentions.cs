namespace MoreDotNet.Extentions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionExtentions
    {
        public static void AddRange<T, TS>(this ICollection<T> list, params TS[] values) where TS : T
        {
            foreach (var value in values)
            {
                list.Add(value);
            }
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> items)
        {
            return items == null || !items.Any();
        }
    }
}

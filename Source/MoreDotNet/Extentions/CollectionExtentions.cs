namespace MoreDotNet.Extentions
{
    using System.Collections.Generic;

    public static class CollectionExtentions
    {
        public static void AddRange<T, TS>(this ICollection<T> list, params TS[] values) where TS : T
        {
            foreach (var value in values)
            {
                list.Add(value);
            }
        }
    }
}

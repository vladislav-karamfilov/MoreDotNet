namespace MoreDotNet.Extentions
{
    using System;
    using System.Collections.Generic;

    public static class ListExtentions
    {
        public static T BinarySearch<T, TKey>(this IList<T> list, Func<T, TKey> keySelector, TKey key)
        where TKey : IComparable<TKey>
        {
            int min = 0;
            int max = list.Count;
            while (min < max)
            {
                int mid = (max + min) / 2;
                T midItem = list[mid];
                TKey midKey = keySelector(midItem);
                int comp = midKey.CompareTo(key);
                if (comp < 0)
                {
                    min = mid + 1;
                }
                else if (comp > 0)
                {
                    max = mid - 1;
                }
                else
                {
                    return midItem;
                }
            }

            if (min == max &&
                keySelector(list[min]).CompareTo(key) == 0)
            {
                return list[min];
            }

            throw new InvalidOperationException("Item not found");
        }
    }
}

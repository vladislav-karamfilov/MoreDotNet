namespace MoreDotNet.Extentions.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    public static class ListExtentions
    {
        /// <summary>
        /// Performs a binary search over a sorted <see cref="IList{T}"/>. If the item is not found throws an <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <typeparam name="T">The type of items in the list.</typeparam>
        /// <typeparam name="TKey">The type of the key we are searching for.</typeparam>
        /// <param name="list">The <see cref="IList{T}"/> instance on which the extension method is called.</param>
        /// <param name="keySelector">A function for selecting our key.</param>
        /// <param name="key">The key we are searching for.</param>
        /// <exception cref="InvalidOperationException">If the key is not found.</exception>
        /// <returns>The element containing our key.</returns>
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

        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        /// <typeparam name="T">The item type of the <see cref="IList{T}"/></typeparam>
        /// <param name="list">The <see cref="IList{T}"/> instance on which the extension method is called.</param>
        /// <returns>A <see cref="DataTable"/> with the contents of the <see cref="IList{T}"/></returns>
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = prop.PropertyType.GetCoreType();
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in list)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// Performs an insertion sort on this list.
        /// </summary>
        /// <typeparam name="T">The item type of the <see cref="IList{T}"/></typeparam>
        /// <param name="list">The <see cref="IList{T}"/> instance on which the extension method is called.</param>
        /// <param name="comparison">the method for comparison of two elements.</param>
        public static void InsertionSort<T>(this IList<T> list, Comparison<T> comparison)
        {
            for (int i = 2; i < list.Count; i++)
            {
                for (int j = i; j > 1 && comparison(list[j], list[j - 1]) < 0; j--)
                {
                    T tempItem = list[j];
                    list.RemoveAt(j);
                    list.Insert(j - 1, tempItem);
                }
            }
        }

        /// <summary>
        /// Inserts an Item into a list at the first place that the <paramref name="predicate"/> expression fails.  If it is true in all cases, then the item is appended to the end of the list.
        /// </summary>
        /// <typeparam name="T">The item type of the <see cref="IList{T}"/></typeparam>
        /// <param name="list">The <see cref="IList{T}"/> instance on which the extension method is called.</param>
        /// <param name="obj">Object being inserted.</param>
        /// <param name="predicate">The specified function that determines when the <paramref name="obj"/> should be added. </param>
        public static void InsertWhere<T>(this IList<T> list, T obj, Func<T, bool> predicate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // When the function first fails it inserts the obj parameter. 
                // For example, in a list myList of ordered Int32's {1,2,3,4,5,10,12}
                // Calling myList.InsertWhere( 8, x => 8 > x) inserts 8 once the list item becomes greater then or equal to it.
                if (!predicate(list[i]))
                {
                    list.Insert(i, obj);
                    return;
                }
            }

            list.Add(obj);
        }

        /// <summary>
        /// Removes all items from the provided <paramref name="instance"/> that match the<paramref name="predicate"/> expression.
        /// </summary>
        /// <typeparam name="T">The class type of the list items.</typeparam>
        /// <param name="instance">The list to remove items from.</param>
        /// <param name="predicate">The predicate expression to test against.</param>
        public static void RemoveAll<T>(this IList<T> instance, Predicate<T> predicate)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            if (instance is T[])
            {
                throw new NotSupportedException();
            }

            var list = instance as List<T>;
            if (list != null)
            {
                list.RemoveAll(predicate);
                return;
            }

            int writeIndex = 0;
            for (int readIndex = 0; readIndex < instance.Count; readIndex++)
            {
                var item = instance[readIndex];
                if (predicate(item))
                {
                    continue;
                }

                if (readIndex != writeIndex)
                {
                    instance[writeIndex] = item;
                }
                ++writeIndex;
            }

            if (writeIndex != instance.Count)
            {
                for (int deleteIndex = instance.Count - 1; deleteIndex >= writeIndex; --deleteIndex)
                {
                    instance.RemoveAt(deleteIndex);
                }
            }
        }
    }
}

namespace MoreDotNet.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RandomExtentions
    {
        public static bool NextBool(this Random randomGenerator)
        {
            return randomGenerator.NextDouble() < 0.5;
        }

        public static T OneOf<T>(this Random randomGenerator, params T[] items)
        {
            return OneOf(randomGenerator, items);
        }

        public static T OneOf<T>(this Random randomGenerator, IList<T> items)
        {
            return items[randomGenerator.Next(items.Count)];
        }

        public static T OneOf<T>(this Random randomGenerator, IEnumerable<T> items)
        {
            int index = randomGenerator.Next(0, items.Count());
            return items.ElementAt(index);
        }
    }
}

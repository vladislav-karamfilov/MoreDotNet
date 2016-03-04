namespace MoreDotNet.Extentions
{
    using System.Collections.Generic;

    public static class DictionaryExtentions
    {
        /// <summary>
        /// If a key exists in a dictionary, return its value, 
        /// otherwise return the default value for that type.
        /// </summary>
        public static TValue GetWithDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            return dict.GetWithDefault(key, default(TValue));
        }

        /// <summary>
        /// If a key exists in a dictionary, return its value,
        /// otherwise return the provided default value.
        /// </summary>
        public static TValue GetWithDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            TValue outValue;
            var hasValue = dict.TryGetValue(key, out outValue);

            if (hasValue)
            {
                return outValue;
            }

            return defaultValue;
        }
    }
}

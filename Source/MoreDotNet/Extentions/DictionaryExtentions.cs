namespace MoreDotNet.Extentions
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryExtentions
    {
        /// <summary>
        /// If a key exists in a dictionary, return its value, 
        /// otherwise return the default value for that type.
        /// </summary>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            return dict.GetOrDefault(key, default(TValue));
        }

        /// <summary>
        /// If a key exists in a dictionary, return its value,
        /// otherwise return the provided default value.
        /// </summary>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            TValue outValue;
            var hasValue = dict.TryGetValue(key, out outValue);

            if (hasValue)
            {
                return outValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the key using <paramref name="caseInsensitiveKey"/> from <paramref name="dictionary"/>.
        /// </summary>
        /// <typeparam name="T">The dictionary value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="caseInsensitiveKey">The case insensitive key.</param>
        /// <returns>
        /// An existing key; or <see cref="string.Empty"/> if not found.
        /// </returns>
        public static string GetKeyIgnoringCase<T>(this IDictionary<string, T> dictionary, string caseInsensitiveKey)
        {
            if (string.IsNullOrEmpty(caseInsensitiveKey))
            {
                return string.Empty;
            }

            foreach (string key in dictionary.Keys)
            {
                if (key.Equals(caseInsensitiveKey, StringComparison.InvariantCultureIgnoreCase))
                {
                    return key;
                }
            }

            return string.Empty;
        }
    }
}

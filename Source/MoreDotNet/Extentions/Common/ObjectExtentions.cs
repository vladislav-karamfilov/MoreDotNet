namespace MoreDotNet.Extentions.Common
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ObjectExtentions
    {
        public static bool Is<T>(this object item) where T : class
        {
            return item is T;
        }

        public static bool IsNot<T>(this object item) where T : class
        {
            return !item.Is<T>();
        }

        public static T As<T>(this object item) where T : class
        {
            return item as T;
        }

        public static IDictionary<string, object> ToDictionary(this object o)
        {
            return o
                .GetType()
                .GetProperties()
                .Where(propertyInfo => propertyInfo.GetIndexParameters().Length == 0)
                .ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(o, null));
        }
    }
}

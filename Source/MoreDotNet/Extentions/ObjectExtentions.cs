namespace MoreDotNet.Extentions
{
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
    }
}

namespace MoreDotNet.Extentions
{
    using System;

    public static class GenericExtentions
    {
        public static bool IsBetween<T>(this T actual, T lowerBound, T upperBound) where T : IComparable<T>
        {
            return actual.CompareTo(lowerBound) >= 0 && actual.CompareTo(upperBound) < 0;
        }
    }
}

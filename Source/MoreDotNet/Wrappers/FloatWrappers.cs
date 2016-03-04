namespace MoreDotNet.Wrappers
{
    public static class FloatWrappers
    {
        public static bool IsNaN(this float input)
        {
            return double.IsNaN(input);
        }

        public static bool IsInfinity(this double input)
        {
            return double.IsInfinity(input);
        }

        public static bool IsNegativeInfinity(this double input)
        {
            return double.IsNegativeInfinity(input);
        }

        public static bool IsPositiveInfinity(this double input)
        {
            return double.IsPositiveInfinity(input);
        }
    }
}

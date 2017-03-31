namespace MoreDotNet.Wrappers
{
    public static class FloatWrappers
    {
        public static bool IsNaN(this float input)
        {
            return float.IsNaN(input);
        }

        public static bool IsInfinity(this float input)
        {
            return float.IsInfinity(input);
        }

        public static bool IsNegativeInfinity(this float input)
        {
            return float.IsNegativeInfinity(input);
        }

        public static bool IsPositiveInfinity(this float input)
        {
            return float.IsPositiveInfinity(input);
        }
    }
}

namespace MoreDotNet.Extensions.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="int"/> extensions.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Creates a range of integers.
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range - inclusive</param>
        /// <param name="step">The iteration step</param>
        /// <returns>0..n-1</returns>
        public static IEnumerable<int> RangeTo(this int start, int end, int step = 1)
        {
            for (int i = start; i <= end; i += step)
            {
                yield return i;
            }
        }
    }
}

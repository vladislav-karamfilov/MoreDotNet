namespace MoreDotNet.Extentions.Common
{
    using System.Collections.Generic;

    public static class IntegerExtentions
    {
        /// <summary>
        /// Replace "Enumerable.Range(n)" with "n.Range()":
        /// </summary>
        /// <param name="n">End of range</param>
        /// <param name="step">The iteration step</param>
        /// <returns>0..n-1</returns>
        public static IEnumerable<int> Range(this int n, int step = 1)
        {
            for (int i = 0; i < n; i += step)
            {
                yield return i;
            }
        }
    }
}

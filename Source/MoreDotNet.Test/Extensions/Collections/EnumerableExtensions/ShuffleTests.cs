namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
{
    using System.Linq;
    using MoreDotNet.Extensions.Collections;
    using Xunit;

    public class ShuffleTests
    {
        [Fact]
        public void Shuffle_ShouldShuffle()
        {
            int[] input = Enumerable.Range(1, 100).ToArray();
            var actual = input.Shuffle();

            Assert.True(actual.Count() == input.Length);
            Assert.NotEqual(input, actual);

            foreach (var item in actual)
            {
                Assert.Contains(item, input);
            }

            foreach (var item in input)
            {
                Assert.Contains(item, actual);
            }
        }
    }
}
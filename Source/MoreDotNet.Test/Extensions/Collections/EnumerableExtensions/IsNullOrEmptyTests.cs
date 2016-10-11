namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
{
    using MoreDotNet.Extensions.Collections;
    using Xunit;

    public class IsNullOrEmptyTests
    {
        [Fact]
        public void IsNullOrEmpty_ShouldReturnFalseOnNonEmptyEnumerable()
        {
            int[] input = new[] { 1, 2, 3 };
            var actual = input.IsNullOrEmpty();
            Assert.False(actual);
        }

        [Fact]
        public void IsNullOrEmpty_ShouldReturnTrueOnEmptyEnumerable()
        {
            int[] input = new int[0];
            var actual = input.IsNullOrEmpty();
            Assert.True(actual);
        }

        [Fact]
        public void IsNullOrEmpty_ShouldReturnTrueOnNullEnumerable()
        {
            int[] input = null;
            var actual = input.IsNullOrEmpty();
            Assert.True(actual);
        }
    }
}
namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
{
    using MoreDotNet.Extensions.Collections;
    using Xunit;

    public class EmptyIfNullTests
    {
        [Fact]
        public void EmptyIfNull_NonEmptyEnumerableGiven_ShouldReturnEqualCollection()
        {
            int[] input = new[] { 1, 2, 3 };
            var actual = input.EmptyIfNull();
            Assert.Equal(input, actual);
        }

        [Fact]
        public void EmptyIfNull_NullEnumerableGiven_ShouldReturnEmpty()
        {
            int[] input = null;
            var actual = input.EmptyIfNull();
            Assert.Equal(new int[] { }, actual);
        }
    }
}
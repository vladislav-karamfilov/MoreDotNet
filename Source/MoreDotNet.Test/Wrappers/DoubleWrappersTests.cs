namespace MoreDotNet.Tests.Wrappers
{
    using MoreDotNet.Wrappers;

    using Xunit;

    public class DoubleWrappersTests
    {
        [Fact]
        public void IsNaN_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = double.NaN;

            var expected = double.IsNaN(input);
            var actual = input.IsNaN();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsInfinity_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = new[]
            {
                double.PositiveInfinity,
                double.NegativeInfinity
            };

            foreach (var testInput in input)
            {
                var expected = double.IsInfinity(testInput);
                var actual = testInput.IsInfinity();
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void IsNegativeInfinity_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = double.NegativeInfinity;

            var expected = double.IsNegativeInfinity(input);
            var actual = input.IsNegativeInfinity();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsPositiveInfinity_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = double.PositiveInfinity;

            var expected = double.IsPositiveInfinity(input);
            var actual = input.IsPositiveInfinity();
            Assert.Equal(expected, actual);
        }
    }
}

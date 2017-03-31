namespace MoreDotNet.Test.Wrappers
{
    using MoreDotNet.Wrappers;

    using Xunit;

    public class FloatWrappersTests
    {
        [Fact]
        public void IsNaN_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = float.NaN;

            var expected = float.IsNaN(input);
            var actual = input.IsNaN();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsInfinity_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = new[]
            {
                float.PositiveInfinity,
                float.NegativeInfinity
            };

            foreach (var testInput in input)
            {
                var expected = float.IsInfinity(testInput);
                var actual = testInput.IsInfinity();
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void IsNegativeInfinity_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = float.NegativeInfinity;

            var expected = float.IsNegativeInfinity(input);
            var actual = input.IsNegativeInfinity();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsPositiveInfinity_GivenSameInput_ShouldHaveSameBehavior()
        {
            var input = float.PositiveInfinity;

            var expected = float.IsPositiveInfinity(input);
            var actual = input.IsPositiveInfinity();
            Assert.Equal(expected, actual);
        }
    }
}

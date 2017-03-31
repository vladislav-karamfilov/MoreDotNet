namespace MoreDotNet.Test.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextBoolTests
    {
        private const int NumberOfTests = 10;

        [Fact]
        public void NextBool_RandomIsNull_ShouldThrowArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextBool());
        }

        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.NaN)]
        [InlineData(-NumberOfTests)]
        [InlineData(0)]
        public void NextBool_ArgumentValueNotPositive_ShouldReturnFalse(double param)
        {
            var random = new Random();
            var result = random.NextBool(param);

            Assert.False(result);
        }

        [Theory]
        [InlineData(double.PositiveInfinity)]
        [InlineData(NumberOfTests)]
        [InlineData(1)]
        public void NextBool_ArgumentValuePositive_ShouldReturnTrue(double param)
        {
            var random = new Random();
            var result = random.NextBool(param);

            Assert.True(result);
        }

        [Fact]
        public void NextBool_IteratesGenerations_ShouldReturnTrueOrFalseAtLeastOnce()
        {
            var random = new Random();
            int returnedTrueAsResult = 0;
            int returnedFalseAsResult = 0;
            for (int i = 0; i < NumberOfTests; i++)
            {
                if (random.NextBool())
                {
                    returnedTrueAsResult++;
                }
                else
                {
                    returnedFalseAsResult++;
                }
            }

            Assert.True(returnedTrueAsResult > 0);
            Assert.True(returnedFalseAsResult > 0);
        }
    }
}

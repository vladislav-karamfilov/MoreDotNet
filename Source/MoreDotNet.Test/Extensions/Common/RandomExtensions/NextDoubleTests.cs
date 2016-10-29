namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using Moq;
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextDoubleTests
    {
        private const int Counter = 1000;
        private const double DoubleResult = 0.15;
        private const double MinValue = -50;
        private const double MaxValue = 150;

        [Fact]
        public void NextDouble_RandomIsNull_ShouldThrow_NullReferenceException()
        {
            Random random = null;

            Assert.Throws<NullReferenceException>(() => random.NextDouble());
        }

        [Fact]
        public void NextDouble_ShouldReturnDouble_BetweenMinAndMaxValue()
        {
            var random = new Random();
            for (int i = 0; i < Counter; i++)
            {
                var result = random.NextDouble(MinValue, MaxValue);

                Assert.True(result >= MinValue && result < MaxValue);
            }
        }

        [Fact]
        public void NextDouble_MinValueIsGreaterThanMaxValue_ShouldThrow_ArgumentException()
        {
            var random = new Random();

            Assert.Throws<ArgumentException>(() => random.NextDouble(minValue: MaxValue, maxValue: MinValue));
        }

        [Fact]
        public void NextDouble_MockedRandom_ShouldReturn_PredifinedValue()
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.NextDouble()).Returns(DoubleResult);
            var actualResult = randomMock.Object.NextDouble(MinValue, MaxValue);
            var expectedResult = MinValue + (DoubleResult * (MaxValue - MinValue));

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(double.MinValue, double.MaxValue)]
        [InlineData(MinValue, MaxValue)]
        public void NextDouble_ShoulReturn_ValidResults(double min, double max)
        {
            var random = new Random();
            var result = random.NextDouble(min, max);

            Assert.True(result >= min && result < max);
        }

        [Theory]
        [InlineData(double.NaN, MaxValue)]
        [InlineData(MinValue, double.NaN)]
        [InlineData(double.NaN, double.NaN)]
        [InlineData(double.NegativeInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, MaxValue)]
        public void NextDouble_InfinityOrNanValuesParams_ShoulReturn_NaNValues(double min, double max)
        {
            var random = new Random();
            var result = random.NextDouble(min, max);

            Assert.Equal(double.NaN, result);
        }

        [Theory]
        [InlineData(MinValue, double.PositiveInfinity)]
        public void NextDouble_PositiveInfinity_ShoulReturn_PositiveInfinity(double min, double max)
        {
            var random = new Random();
            var result = random.NextDouble(min, max);

            Assert.Equal(double.PositiveInfinity, result);
        }
    }
}

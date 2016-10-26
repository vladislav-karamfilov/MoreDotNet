namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using Moq;
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextDoubleTests
    {
        [Fact]
        public void NextDouble_ShouldReturnDouble()
        {
            var random = new Random();
            var result = random.NextDouble(0, 10);

            Assert.IsType<double>(result);
        }

        [Fact]
        public void NextDouble_ShouldReturnDouble_BetweenZeroAndTen()
        {
            var random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var result = random.NextDouble(0, 10);

                Assert.True(result >= 0 && result < 10);
            }
        }

        [Fact]
        public void NextDouble_ShouldReturnDouble_Zero()
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.NextDouble()).Returns(0);
            var result = randomMock.Object.NextDouble(0, double.MaxValue);

            Assert.Equal(0, result);
        }

        [Fact]
        public void NextDouble_ShouldReturnDouble_PredifinedValue()
        {
            var mockedValue = 0.15;
            var minValue = 0;
            var maxValue = 30;

            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.NextDouble()).Returns(mockedValue);
            var result = randomMock.Object.NextDouble(minValue, maxValue);

            Assert.Equal(mockedValue * maxValue, result);
        }
    }
}

namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using Moq;
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextDoubleTests
    {
        [Fact]
        [MemberData(nameof(Random))]
        public void NextDouble_ShouldReturnDouble()
        {
            var random = new Random();
            var result = random.NextDouble(0, 10);

            Assert.IsType<double>(result);
        }

        [Fact]
        [MemberData(nameof(Random))]
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
        [MemberData(nameof(Random))]
        public void NextDouble_ShouldReturnDouble_Zero()
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.NextDouble()).Returns(0);
            var result = randomMock.Object.NextDouble(0, double.MaxValue);

            Assert.Equal(0, result);
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextDouble_ShouldReturnDouble_PredifinedValue()
        {
            var expectedResult = 12.8951;
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.NextDouble()).Returns(expectedResult);
            var result = randomMock.Object.NextDouble(0, double.MaxValue);

            Assert.Equal(expectedResult, result);
        }
    }
}

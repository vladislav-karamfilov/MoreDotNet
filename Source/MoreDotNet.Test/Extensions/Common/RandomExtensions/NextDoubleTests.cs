namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextDoubleTests
    {
        [Fact]
        public void NextDouble_ShouldReturnDoubleBetweenZeroAndTen()
        {
            var random = new Random();
            var result = random.NextDouble(0, 10);

            Assert.IsType<double>(result);
            Assert.True(result >= 0 && result < 10);
        }
    }
}

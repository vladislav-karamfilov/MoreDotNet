namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;
    using System.Linq;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextDateTime
    {
        private const int Counter = 1000;

        [Fact]
        public void NextDateTime_ShouldThrow_ArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextDateTime());
        }

		// TODO: minValue => null / maxValue => null ; 

        [Fact]
        public void NextDateTime_ShouldReturnDateTime()
        {
            var random = new Random();
            var result = random.NextDateTime();

            Assert.IsType<DateTime>(result);
        }

        [Fact]
        public void NextDateTime_ShouldReturnDateTime_OneHundredDistinctValues()
        {
            // TODO: Fix test
            var random = new Random();
            var dates = new DateTime[Counter];
            for (int i = 0; i < Counter; i++)
            {
                dates[i] = random.NextDateTime();
            }

            Assert.Equal(Counter, dates.Distinct().Count());
        }

        [Fact]
        public void NextDateTime_ShouldReturnDateTime_BetweenMinAndMaxValue()
        {
            var random = new Random();
            var mivValue = new DateTime(2016, 1, 1, 0, 0, 0);
            var maxValue = new DateTime(2018, 1, 1, 0, 0, 0);
            for (int i = 0; i < Counter; i++)
            {
                var result = random.NextDateTime(mivValue, maxValue);

                Assert.True(result >= mivValue && result < maxValue);
            }
        }
    }
}

namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;
    using System.Linq;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextDateTime
    {
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
            var counter = 100;
            var dates = new DateTime[counter];
            for (int i = 0; i < counter; i++)
            {
                dates[i] = random.NextDateTime();
            }

            Assert.Equal(counter, dates.Distinct().Count());
        }

        [Fact]
        public void NextDateTime_ShouldReturnDateTime_BetweenMinAndMaxValue()
        {
            var random = new Random();
            var mivValue = new DateTime(2016, 1, 1, 0, 0, 0);
            var maxValue = new DateTime(2018, 1, 1, 0, 0, 0);
            var result = random.NextDateTime(mivValue, maxValue);

            Assert.True(result >= mivValue && result < maxValue);
        }
    }
}

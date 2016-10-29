namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class NextDateTime
    {
        private const int Counter = 1000;
        private DateTime minDate = new DateTime(1999, 10, 31);
        private DateTime maxDate = new DateTime(1999, 10, 31);

        [Fact]
        public void NextDateTime_RandomIsNull_ShouldThrow_ArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextDateTime());
        }

        [Fact]
        public void NextDateTime_MinValueIsGreaterThanMaxValue_ShouldThrow_ArgumentException()
        {
            Random random = new Random();

            Assert.Throws<ArgumentException>(() => random.NextDateTime(this.maxDate, this.minDate));
        }

        [Fact]
        public void NextDateTime_ShouldReturnDateTime_99PercentOfTimes()
        {
            var random = new Random();
            var dates = new HashSet<DateTime>();
            for (int i = 0; i < Counter; i++)
            {
                dates.Add(random.NextDateTime());
            }

            Assert.True(dates.Count() >= (Counter * 99 / 100));
        }

        [Fact]
        public void NextDateTime_ShouldReturnDateTime_BetweenMinAndMaxValue()
        {
            var random = new Random();
            for (int i = 0; i < Counter; i++)
            {
                var result = random.NextDateTime(this.minDate, this.maxDate);

                Assert.True(result >= this.minDate && result < this.maxDate);
            }
        }
    }
}

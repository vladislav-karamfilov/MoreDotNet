namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class NextTimeSpanTests
    {
        private const int Counter = 1000;
        private readonly TimeSpan minTimeSpan = new TimeSpan(0, 0, 0, 0, 1);
        private readonly TimeSpan maxTimeSpan = new TimeSpan(1000, 59, 59, 59);

        [Fact]
        public void NextTimeSpan_NullInit_ShouldThow_ArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextTimeSpan());
        }

        [Fact]
        public void NextTimeSpan_MinIsGreaterThanMax_ShouldThow_ArgumentException()
        {
            Random random = new Random();

            Assert.Throws<ArgumentException>(() => random.NextTimeSpan(this.maxTimeSpan, this.minTimeSpan));
        }

        [Fact]
        public void NextTimeSpan_ShouldReturnTimeSpan_DistinctValues99PercentOfTimes()
        {
            var random = new Random();
            var dates = new HashSet<TimeSpan>();
            for (int i = 0; i < Counter; i++)
            {
                dates.Add(random.NextTimeSpan());
            }

            Assert.True(dates.Count() >= (Counter * 99 / 100));
        }

        [Fact]
        public void NextTimeSpan_ShouldReturn_TimeSpan()
        {
            var random = new Random();
            for (int i = 0; i < Counter; i++)
            {
                var result = random.NextTimeSpan(this.minTimeSpan, this.maxTimeSpan);

                Assert.True(result >= this.minTimeSpan && result < this.maxTimeSpan);
            }
        }
    }
}

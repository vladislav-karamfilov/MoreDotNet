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
        public void NextDateTime_ShouldReturnDateTime_NewYear()
        {
            var random = new Random();
            var counter = 100;
            var dates = new DateTime[counter];
            for (int i = 0; i < counter; i++)
            {
                dates[i] = random.NextDateTime();
            }

            Assert.Equal(counter, dates.Distinct().Count());
        }
    }
}

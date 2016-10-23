namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

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
    }
}

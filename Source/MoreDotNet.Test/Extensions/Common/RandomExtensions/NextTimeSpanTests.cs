namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextTimeSpanTests
    {
        [Fact]
        public void NextTimeSpan_ShouldReturnTimeSpan()
        {
            var random = new Random();
            var result = random.NextTimeSpan();

            Assert.IsType<TimeSpan>(result);
        }
    }
}

namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextTimeSpanTests
    {
        [Fact]
        public void NextTimeSpan_ShouldThow_ArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextTimeSpan());
        }
    }
}

namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextCharTests
    {
        [Fact]
        public void NextChar_ShouldReturnChar()
        {
            var random = new Random();
            var result = random.NextChar();

            Assert.IsType<char>(result);
        }
    }
}

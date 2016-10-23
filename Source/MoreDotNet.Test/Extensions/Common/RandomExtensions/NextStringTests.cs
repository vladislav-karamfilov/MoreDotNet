namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextStringTests
    {
        [Fact]
        public void NextString_ShouldReturnStringWithLenghtZero()
        {
            var zero = 0;
            var random = new Random();
            var result = random.NextString(zero);

            Assert.IsType<string>(result);
            Assert.Equal(zero, result.Length);
        }

        [Fact]
        public void NextString_ShouldReturnStringWithLenghtFiveChars()
        {
            var length = 5;

            var random = new Random();
            var result = random.NextString(length);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
        }

        [Fact]
        public void NextString_ShouldReturnStringContainingOnlyNumericsWithLenghtFiveChars()
        {
            var length = 5;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.Numeric);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                var currentChar = (char)result[i];
                Assert.True(currentChar > 48 && currentChar < 58);
            }
        }
    }
}

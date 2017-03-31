namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class RemoveLastTests
    {
        [Fact]
        public void RemoveLast_ParseNullInput_ShouldThrowException()
        {
            string input = null;
            Assert.Throws<ArgumentNullException>(() => input.RemoveLast(1));
        }

        [Fact]
        public void RemoveLast_ParseEmptyString_ShouldThrowException()
        {
            string input = string.Empty;
            Assert.Throws<ArgumentOutOfRangeException>(() => input.RemoveLast(1));
        }

        [Fact]
        public void RemoveLast_NegativeCharNumber_ShouldThrowException()
        {
            string input = "Greetings!";
            Assert.Throws<ArgumentOutOfRangeException>(() => input.RemoveLast(-11));
        }

        [Fact]
        public void RemoveLast_ParseSampleString_ShouldReturnTrimmedString()
        {
            var expected = "Greeting";
            var input = "Greetings!";
            var actual = input.RemoveLast(2);
            Assert.Equal(expected, actual);
        }
    }
}

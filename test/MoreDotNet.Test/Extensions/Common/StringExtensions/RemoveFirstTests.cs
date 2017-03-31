namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class RemoveFirstTests
    {
        [Fact]
        public void RemoveFirst_ParseNullInput_ShouldThrowException()
        {
            string input = null;
            Assert.Throws<ArgumentNullException>(() => input.RemoveFirst(1));
        }

        [Fact]
        public void RemoveFirst_ParseEmptyString_ShouldThrowException()
        {
            string input = string.Empty;
            Assert.Throws<ArgumentOutOfRangeException>(() => input.RemoveFirst(1));
        }

        [Fact]
        public void RemoveFirst_NegativeCharNumber_ShouldThrowException()
        {
            string input = "Greetings!";
            Assert.Throws<ArgumentOutOfRangeException>(() => input.RemoveFirst(-11));
        }

        [Fact]
        public void RemoveFirst_ParseSampleString_ShouldReturnTrimmedString()
        {
            var expected = "eetings!";
            var input = "Greetings!";
            var actual = input.RemoveFirst(2);
            Assert.Equal(expected, actual);
        }
    }
}

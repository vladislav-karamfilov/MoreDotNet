namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class RemoveLastCharacterTests
    {
        [Fact]
        public void RemoveLastCharacter_ParseNullInput_ShouldThrowException()
        {
            string input = null;
            Assert.Throws<ArgumentNullException>(() => input.RemoveLastCharacter());
        }

        [Fact]
        public void RemoveLastCharacter_ParseEmptyString_ShouldThrowException()
        {
            string input = string.Empty;
            Assert.Throws<ArgumentOutOfRangeException>(() => input.RemoveLastCharacter());
        }

        [Fact]
        public void RemoveLastCharacter_ParseSampleString_ShouldReturnTrimmedString()
        {
            var expected = "Greetings";
            var input = "Greetings!";
            var actual = input.RemoveLastCharacter();
            Assert.Equal(expected, actual);
        }
    }
}

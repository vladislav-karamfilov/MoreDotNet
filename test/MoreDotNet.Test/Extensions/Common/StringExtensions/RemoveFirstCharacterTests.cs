namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class RemoveFirstCharacterTests
    {
        [Fact]
        public void RemoveFirstCharacter_ParseNullInput_ShouldThrowException()
        {
            string input = null;
            Assert.Throws<ArgumentNullException>(() => input.RemoveFirstCharacter());
        }

        [Fact]
        public void RemoveFirstCharacter_ParseEmptyString_ShouldThrowException()
        {
            string input = string.Empty;
            Assert.Throws<ArgumentOutOfRangeException>(() => input.RemoveFirstCharacter());
        }

        [Fact]
        public void RemoveFirstCharacter_ParseSampleString_ShouldReturnTrimmedString()
        {
            var expected = "Greetings!";
            var input = "!Greetings!";
            var actual = input.RemoveFirstCharacter();
            Assert.Equal(expected, actual);
        }
    }
}

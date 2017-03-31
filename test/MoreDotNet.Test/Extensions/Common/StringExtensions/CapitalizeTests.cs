namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class CapitalizeTests
    {
        [Fact]
        public void Capitalize_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string input = string.Empty;
            string actual = input.Capitalize();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Capitalize_ParseStringWithSmallFirstLetter_ShouldReturnCapitalizedFirstLetter()
        {
            string expected = "FirstCapitalLetter";
            string input = "firstCapitalLetter";
            string actual = input.Capitalize();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Capitalize_ParseStringBeginWithSpace_ShouldReturnSameString()
        {
            string expected = " testString";
            string input = " testString";
            string actual = input.Capitalize();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Capitalize_ParseStringBeginWithCapitalLetter_ShouldReturnSameString()
        {
            string expected = "TestString";
            string input = "TestString";
            string actual = input.Capitalize();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Capitalize_ParseStringBeginWithSpecialSymbol_ShouldReturnSameString()
        {
            string expected = "@TestString";
            string input = "@TestString";
            string actual = input.Capitalize();
            Assert.Equal(expected, actual);
        }
    }
}

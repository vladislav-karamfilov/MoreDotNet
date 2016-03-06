namespace MoreDotNet.Test.Extentions.StringExtentions
{
    using MoreDotNet.Extentions;

    using Xunit;

    public class ToTitleCaseTests
    {
        [Fact]
        public void ToTitleCase_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string input = string.Empty;
            string actual = input.ToTitleCase();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToTitleCase_ParseStringBeginWithCyrillicSmallLetter_ShouldReturnCapitalizedFirstLetter()
        {
            string expected = "Академия";
            string input = "академия";
            string actual = input.ToTitleCase();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToTitleCase_ParseStringBeginWithCyrillicSmallLetter_ShouldReturnSameString()
        {
            string expected = "Академия";
            string input = "Академия";
            string actual = input.ToTitleCase();
            Assert.Equal(expected, actual);
        }
    }
}

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
    }
}

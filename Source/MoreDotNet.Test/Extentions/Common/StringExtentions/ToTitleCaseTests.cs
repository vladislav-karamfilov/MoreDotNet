namespace MoreDotNet.Tests.Extentions.Common.StringExtentions
{
    using MoreDotNet.Extentions.Common;

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

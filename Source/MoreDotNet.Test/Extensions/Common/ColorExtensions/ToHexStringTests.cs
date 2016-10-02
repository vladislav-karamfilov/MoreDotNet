namespace MoreDotNet.Tests.Extensions.Common.ColorExtensions
{
    using System.Drawing;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class ToHexStringTests
    {
        [Fact]
        public void ToHexString_ParseBlackColor_ShouldReturnBlackHex()
        {
            var input = Color.Black;
            var expected = "#000000";
            var actual = input.ToHexString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToHexString_ParseWhiteColor_ShouldReturnWhiteHex()
        {
            var input = Color.White;
            var expected = "#FFFFFF";
            var actual = input.ToHexString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToHexString_ParseRedColor_ShouldReturnRedHex()
        {
            var input = Color.Red;
            var expected = "#FF0000";
            var actual = input.ToHexString();
            Assert.Equal(expected, actual);
        }
    }
}

namespace MoreDotNet.Tests.Extentions.Common.ColorExtentions
{
    using System.Drawing;

    using MoreDotNet.Extentions.Common;

    using Xunit;

    public class ToRgbStringTests
    {
        [Fact]
        public void ToRgbString_ParseBlackColor_ShouldReturnBlackRgb()
        {
            var input = Color.Black;
            var expected = "RGB(0,0,0)";
            var actual = input.ToRgbString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToRgbString_ParseWhiteColor_ShouldReturnWhiteRgb()
        {
            var input = Color.White;
            var expected = "RGB(255,255,255)";
            var actual = input.ToRgbString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToRgbString_ParseRedColor_ShouldReturnRedRgb()
        {
            var input = Color.Red;
            var expected = "RGB(255,0,0)";
            var actual = input.ToRgbString();
            Assert.Equal(expected, actual);
        }
    }
}

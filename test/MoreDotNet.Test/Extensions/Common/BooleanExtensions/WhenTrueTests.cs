namespace MoreDotNet.Test.Extensions.Common.BooleanExtensions
{
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class WhenTrueTests
    {
        [Fact]
        public void WhenTrue_ParseTrueValue_ShouldReturnContent()
        {
            var input = true;
            var expected = "Hello Worlds!";
            var actual = input.WhenTrue(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenTrue_ParseFalseValue_ShouldReturnDefaultValueOfContent()
        {
            var input = true;
            var expected = default(string);
            var actual = input.WhenTrue(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenTrue_ParseTrueValue_ShouldExecuteAction()
        {
            var input = true;
            var expected = "Hello Worlds!";
            var actual = input.WhenTrue(() => "Hello Worlds!");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenTrue_ParseFalseValue_ShouldNotExecuteAction()
        {
            var input = false;
            var expected = default(string);
            var actual = input.WhenTrue(() => "Hello Worlds!");
            Assert.Equal(expected, actual);
        }
    }
}

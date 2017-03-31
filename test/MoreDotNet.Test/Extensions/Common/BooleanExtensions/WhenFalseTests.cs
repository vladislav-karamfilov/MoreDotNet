namespace MoreDotNet.Test.Extensions.Common.BooleanExtensions
{
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class WhenFalseTests
    {
        [Fact]
        public void WhenFalse_ParseFalseValue_ShouldReturnContent()
        {
            var input = false;
            var expected = "Hello Worlds!";
            var actual = input.WhenFalse(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenFalse_ParseTrueValue_ShouldReturnDefaultValueOfContent()
        {
            var input = true;
            var expected = default(string);
            var actual = input.WhenFalse(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenFalse_ParseFalseValue_ShouldExecuteAction()
        {
            var input = false;
            var expected = "Hello Worlds!";
            var actual = input.WhenFalse(() => "Hello Worlds!");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenFalse_ParseTrueValue_ShouldNotExecuteAction()
        {
            var input = true;
            var expected = default(string);
            var actual = input.WhenFalse(() => "Hello Worlds!");
            Assert.Equal(expected, actual);
        }
    }
}

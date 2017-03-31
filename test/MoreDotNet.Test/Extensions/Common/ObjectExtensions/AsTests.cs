namespace MoreDotNet.Test.Extensions.Common.ObjectExtensions
{
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class AsTests
    {
        [Fact]
        public void As_StringObjectAsString_ShouldReturnString()
        {
            object input = "Value";
            var result = input.As<string>();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void As_IntAsString_ShouldReturnNull()
        {
            object input = 3;
            var result = input.As<string>();
            Assert.Null(result);
        }
    }
}

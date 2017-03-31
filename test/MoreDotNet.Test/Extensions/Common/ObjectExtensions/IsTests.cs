namespace MoreDotNet.Test.Extensions.Common.ObjectExtensions
{
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class IsTests
    {
        [Fact]
        public void Is_AIsA_ShouldReturnTrue()
        {
            var input = new ExampleA();
            Assert.True(input.Is<ExampleA>());
        }

        [Fact]
        public void Is_AIsB_ShouldReturnFalse()
        {
            var input = new ExampleA();
            Assert.False(input.Is<ExampleB>());
        }

        private class ExampleA
        {
        }

        private class ExampleB
        {
        }
    }
}

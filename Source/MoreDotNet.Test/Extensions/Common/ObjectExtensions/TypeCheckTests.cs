namespace MoreDotNet.Tests.Extensions.Common.ObjectExtensions
{
    using System;
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class TypeCheckTests
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

        [Fact]
        public void IsNot_NullItem_ShouldThrowShouldThrowArgumentNullException()
        {
            ExampleA input = null;
            Assert.Throws<ArgumentNullException>(() => input.IsNot<ExampleB>());
        }

        [Fact]
        public void Is_BIsNotA_ShouldReturnTrue()
        {
            var input = new ExampleB();
            Assert.True(input.IsNot<ExampleA>());
        }

        [Fact]
        public void Is_BIsNotB_ShouldReturnFalse()
        {
            var input = new ExampleB();
            Assert.False(input.IsNot<ExampleB>());
        }

        private class ExampleA
        {
        }

        private class ExampleB
        {
        }
    }
}

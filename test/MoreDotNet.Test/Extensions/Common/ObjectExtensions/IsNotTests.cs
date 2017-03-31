namespace MoreDotNet.Test.Extensions.Common.ObjectExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class IsNotTests
    {
        [Fact]
        public void IsNot_NullItem_ShouldThrowShouldThrowArgumentNullException()
        {
            ExampleA input = null;
            Assert.Throws<ArgumentNullException>(() => input.IsNot<ExampleB>());
        }

        [Fact]
        public void IsNot_BIsNotA_ShouldReturnTrue()
        {
            var input = new ExampleB();
            Assert.True(input.IsNot<ExampleA>());
        }

        [Fact]
        public void IsNot_BIsNotB_ShouldReturnFalse()
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

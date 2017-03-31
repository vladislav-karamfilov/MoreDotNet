namespace MoreDotNet.Test.Extensions.Common.IntegerExtensions
{
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class RangeToTests
    {
        [Fact]
        public void RangeTo_ParseSimpleRange_ShouldReturnCorespondingEnumeration()
        {
            var expected = new List<int> { 2, 3, 4 };
            var input = 2;
            var actual = input.RangeTo(4);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RangeTo_ParseEndLowerThanStart_ShouldReturnEmptyRange()
        {
            var input = 2;
            var actual = input.RangeTo(0);
            Assert.Empty(actual);
        }

        [Fact]
        public void RangeTo_ParseEndSameAsStart_ShouldReturnOneElementRange()
        {
            var expected = new List<int> { 0 };
            var input = 0;
            var actual = input.RangeTo(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RangeTo_ParseNegativeEndAndStart_ShouldReturNegativeRange()
        {
            var expected = new List<int> { -8, -7, -6 };
            var input = -8;
            var actual = input.RangeTo(-6);
            Assert.Equal(expected, actual);
        }
    }
}

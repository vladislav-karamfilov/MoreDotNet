namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class OneOfTests
    {
        [Fact]
        public void OneOf_ShouldReturnOneOfIntArray()
        {
            var random = new Random();
            var numbers = new[] { 1, 2, 3, 4, 5, 6 };
            var number = random.OneOf<int>(numbers);

            Assert.True(numbers.Contains(number));
        }

        [Fact]
        public void OneOf_ShouldReturnOneOfIntCollection()
        {
            var random = new Random();
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var number = random.OneOf<int>(numbers);

            Assert.True(numbers.Contains(number));
        }
    }
}

namespace MoreDotNet.Test.Extensions.Collections.EnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class ForEachTests
    {
        [Fact]
        public void ForEach_NonEmptyEnumerableGiven_ShouldCallMapFunction()
        {
            var actual = new List<int>();
            var input = new[] { 1 };
            input.ForEach((_) => actual.Add(_));
            Assert.True(actual.Contains(input[0]));
        }

        [Fact]
        public void ForEach_NullEnumerableGiven_ShouldThrowArgumentNullException()
        {
            IEnumerable<int> emptyEnumerable = null;
            Assert.Throws<ArgumentNullException>(
                () => emptyEnumerable.ForEach(null));
        }

        [Fact]
        public void ForEach_NullMapFunctionGiven_ShouldThrowArgumentNullException()
        {
            var input = new[] { 1 };
            Assert.Throws<ArgumentNullException>(
                () => input.ForEach(null));
        }
    }
}
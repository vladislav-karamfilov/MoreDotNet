namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
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
            List<int> actual = new List<int>();
            int[] input = new[] { 1 };
            EnumerableExtensions.ForEach(input, (_) => actual.Add(_));
            Assert.True(actual.Contains(input[0]));
        }

        [Fact]
        public void ForEach_NullEnumerableGiven_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => EnumerableExtensions.ForEach<int>(null, null));
        }

        [Fact]
        public void ForEach_NullMapFunctionGiven_ShouldThrowArgumentNullException()
        {
            int[] input = new[] { 1 };
            Assert.Throws<ArgumentNullException>(
                () => EnumerableExtensions.ForEach(input, null));
        }
    }
}
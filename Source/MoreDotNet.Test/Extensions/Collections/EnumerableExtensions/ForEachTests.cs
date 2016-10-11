namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using MoreDotNet.Extensions.Collections;
    using Xunit;

    public class ForEachTests
    {
        [Fact]
        public void ForEach_ShouldAddToResultSet()
        {
            List<int> actual = new List<int>();
            int[] input = new[] { 1 };
            EnumerableExtensions.ForEach(input, (_) => actual.Add(_));
            Assert.True(actual.Contains(input[0]));
        }

        [Fact]
        public void ForEach_ShouldThrowOnNullItems()
        {
            Assert.Throws(
                typeof(ArgumentNullException),
                () => EnumerableExtensions.ForEach<int>(null, null));
        }

        [Fact]
        public void ForEach_ShouldThrowOnNullAction()
        {
            int[] input = new[] { 1 };
            Assert.Throws(
                typeof(ArgumentNullException),
                () => EnumerableExtensions.ForEach(input, null));
        }
    }
}
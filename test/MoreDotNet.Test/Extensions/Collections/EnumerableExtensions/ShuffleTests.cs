namespace MoreDotNet.Test.Extensions.Collections.EnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class ShuffleTests
    {
        [Fact]
        public void Shuffle_NonEmtpyEnumerableGiven_ShouldShuffle()
        {
            var input = Enumerable.Range(1, 100).ToArray();
            var actual = input.Shuffle();

            Assert.True(actual.Count() == input.Length);
            Assert.NotEqual(input, actual);

            foreach (var item in actual)
            {
                Assert.Contains(item, input);
            }

            foreach (var item in input)
            {
                Assert.Contains(item, actual);
            }
        }

        [Fact]
        public void Shuffle_GivenNullEnumerable_ShouldThrowException()
        {
            IEnumerable<int> nullEnumerable = null;
            Assert.Throws<ArgumentNullException>(() => nullEnumerable.Shuffle());
        }

        [Fact]
        public void Shuffle_GivenNullEnumerableAndCorrectRandomGenerator_ShouldThrowException()
        {
            IEnumerable<int> nullEnumerable = null;
            Assert.Throws<ArgumentNullException>(() => nullEnumerable.Shuffle(new Random()));
        }

        [Fact]
        public void Shuffle_GivenCorrectEnumerableAndNullRandomGenerator_ShouldThrowException()
        {
            IEnumerable<int> nullEnumerable = new[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => nullEnumerable.Shuffle(null));
        }
    }
}
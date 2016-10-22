namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class ToStringTests
    {
        [Fact]
        public void ToString_NullEnumerableGiven_ShouldThrowException()
        {
            IEnumerable<string> nullEnumerable = null;
            Assert.Throws<ArgumentNullException>(() => nullEnumerable.ToString(","));
        }

        [Fact]
        public void ToString_NullEnumerableAndCorrectTransformationFunctionGiven_ShouldThrowException()
        {
            IEnumerable<string> nullEnumerable = null;
            Assert.Throws<ArgumentNullException>(() => nullEnumerable.ToString(x => string.Empty, ","));
        }

        [Fact]
        public void ToString_NonEmptyEnumerableGiven_ShouldReturnStringsWithSeperator()
        {
            var input = new[] { "one", "two", "three" };

            var seperator = ",";
            var actual = input.ToString(seperator);
            Assert.Equal("one,two,three", actual);
        }

        [Fact]
        public void ToString_StringElementGiven_ShouldReturnStringsWithStringElement()
        {
            const string seperator = ",";
            var input = new[] { "one", "two", "three" };

            var actual = input.ToString((_) => _.ToUpperInvariant(), seperator);
            Assert.Equal("ONE,TWO,THREE", actual);
        }

        [Fact]
        public void ToString_NullStringArrayGiven_ShouldThrowArgumentNullException()
        {
            string[] input = null;
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var seperator = ",";
                    var result = input.ToString(seperator);
                });
        }

        [Fact]
        public void ToString_NullSeperatorGiven_ShouldThrowArgumentNullException()
        {
            var input = new[] { "one", "two", "three" };
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    string seperator = null;
                    var actual = input.ToString(seperator);
                });
        }

        [Fact]
        public void ToString_StringElementNullGiven_ShouldThrowArgumentNullException()
        {
            var input = new[] { "one", "two", "three" };
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var seperator = ",";
                    var actual = input.ToString(null, seperator);
                });
        }
    }
}
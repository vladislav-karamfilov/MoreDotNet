namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
{
    using System;
    using MoreDotNet.Extensions.Collections;
    using Xunit;

    public class ToStringTests
    {
        [Fact]
        public void ToString_NonEmptyEnumerableGiven_ShouldReturnStringsWithSeperator()
        {
            string[] input = new string[] { "one", "two", "three" };

            string seperator = ",";
            var actual = input.ToString(seperator);
            Assert.Equal("one,two,three", actual);
        }

        [Fact]
        public void ToString_StringElementGiven_ShouldReturnStringsWithStringElement()
        {
            string[] input = new string[] { "one", "two", "three" };

            string seperator = ",";
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
                    string seperator = ",";
                    var result = input.ToString(seperator);
                });
        }

        [Fact]
        public void ToString_NullSeperatorGiven_ShouldThrowArgumentNullException()
        {
            string[] input = new string[] { "one", "two", "three" };
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
            string[] input = new string[] { "one", "two", "three" };
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    string seperator = ",";
                    var actual = input.ToString(null, seperator);
                });
        }
    }
}
namespace MoreDotNet.Tests.Extensions.Collections.EnumerableExtensions
{
    using System;
    using MoreDotNet.Extensions.Collections;
    using Xunit;

    public class ToStringTests
    {
        [Fact]
        public void ToString_ShouldReturnStringsWithSeperator()
        {
            string[] input = new string[] { "one", "two", "three" };

            string seperator = ",";
            var actual = input.ToString(seperator);
            Assert.Equal("one,two,three", actual);
        }

        [Fact]
        public void ToString_ShouldReturnStringsWithStringElement()
        {
            string[] input = new string[] { "one", "two", "three" };

            string seperator = ",";
            var actual = input.ToString((_) => _.ToUpperInvariant(), seperator);
            Assert.Equal("ONE,TWO,THREE", actual);
        }

        [Fact]
        public void ToString_ShouldThrowArgumentNullExceptionWithItemNull()
        {
            string[] input = null;
            Assert.Throws(
                typeof(ArgumentNullException),
                () =>
                {
                    string seperator = ",";
                    var result = input.ToString(seperator);
                });
        }

        [Fact]
        public void ToString_ShouldThrowArgumentNullExceptionWithSeperatorNull()
        {
            string[] input = new string[] { "one", "two", "three" };
            Assert.Throws(
                typeof(ArgumentNullException),
                () =>
                {
                    string seperator = null;
                    var actual = input.ToString(seperator);
                });
        }

        [Fact]
        public void ToString_ShouldThrowArgumentNullExceptionWithStringElementNull()
        {
            string[] input = new string[] { "one", "two", "three" };
            Assert.Throws(
                typeof(ArgumentNullException),
                () =>
                {
                    string seperator = ",";
                    var actual = input.ToString(null, seperator);
                });
        }
    }
}
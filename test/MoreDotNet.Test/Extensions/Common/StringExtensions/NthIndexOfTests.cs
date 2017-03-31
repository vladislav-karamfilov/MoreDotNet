namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NthIndexOfTests
    {
        [Fact]
        public void NthIndexOf_ParseNullInput_ShouldThrowException()
        {
            string input = null;
            Assert.Throws<ArgumentNullException>(() => input.NthIndexOf("a", 2));
        }

        [Fact]
        public void NthIndexOf_ParseNullMatch_ShouldThrowException()
        {
            string input = "Sample text to search";
            Assert.Throws<ArgumentNullException>(() => input.NthIndexOf(null, 2));
        }

        [Fact]
        public void NthIndexOf_ParseNegativeOccurrence_ShouldThrowException()
        {
            string input = "Sample text to search";
            Assert.Throws<ArgumentException>(() => input.NthIndexOf("to", -123));
        }

        [Fact]
        public void NthIndexOf_ParseZeroOccurrence_ShouldThrowException()
        {
            string input = "Sample text to search";
            Assert.Throws<ArgumentException>(() => input.NthIndexOf("to", 0));
        }

        [Fact]
        public void NthIndexOf_MatchIsNotInString_ShouldReturnMinusOne()
        {
            var expected = -1;
            var input = "Sample text to search";
            var actual = input.NthIndexOf("drinking", 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NthIndexOf_MatchIsInStringButOccurrenceIsTooBig_ShouldReturnMinusOne()
        {
            var expected = -1;
            var input = "Sample text to search";
            var actual = input.NthIndexOf("text", 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NthIndexOf_MatchIsInString_ShouldReturnIndex()
        {
            var expected = 7;
            var input = "Sample text to search";
            var actual = input.NthIndexOf("text", 1);
            Assert.Equal(expected, actual);
        }
    }
}

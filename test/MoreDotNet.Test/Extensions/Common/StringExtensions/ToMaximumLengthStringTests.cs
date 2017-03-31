namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class ToMaximumLengthStringTests
    {
        [Fact]
        public void ToMaximumLengthString_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string input = string.Empty;
            string actual = input.ToMaximumLengthString(2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToMaximumLengthString_ParseNullString_ShouldThrowException()
        {
            string input = null;
            Assert.Throws<ArgumentNullException>(() => input.ToMaximumLengthString(2));
        }

        [Fact]
        public void ToMaximumLengthString_ParseNullPostFixString_ShouldThrowException()
        {
            string input = "Sample Text";
            Assert.Throws<ArgumentNullException>(() => input.ToMaximumLengthString(2, null));
        }

        [Fact]
        public void ToMaximumLengthString_MaxLengthIsBiggerThanStringSize_ShouldReturnSameString()
        {
            string input = "Sample Text";
            string expected = "Sample Text";
            string actual = input.ToMaximumLengthString(100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToMaximumLengthString_MaxLengthIsSmallerThanStringSize_ShouldReturnTrimmedString()
        {
            string input = "Sample Text More words.";
            string expected = "Sample...";
            string actual = input.ToMaximumLengthString(9);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToMaximumLengthString_MaxLengthIsSmallerThanStringSizeWithDifferetPostfixText_ShouldReturnTrimmedString()
        {
            string input = "Sample Text More words.";
            string expected = "SampleLOL";
            string actual = input.ToMaximumLengthString(9, "LOL");
            Assert.Equal(expected, actual);
        }
    }
}

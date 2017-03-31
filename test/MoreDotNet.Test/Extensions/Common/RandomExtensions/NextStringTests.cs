namespace MoreDotNet.Test.Extensions.Common.RandomExtensions
{
    using System;
    using System.Linq;

    using MoreDotNet.Extensions.Common;
    using MoreDotNet.Models;
    using MoreDotNet.Wrappers;

    using Xunit;

    public class NextStringTests
    {
        private const int StringLength = 100;
        private const int StringLengthLarge = 1000;

        [Fact]
        public void NextString_RandomIsNull_ShouldThrowArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextString(StringLength));
        }

        [Fact]
        public void NextString_ValidArgument_ShouldReturnExpectedLenght()
        {
            var random = new Random();
            var result = random.NextString(StringLength);

            Assert.Equal(StringLength, result.Length);
        }

        [Fact]
        public void NextString_ValidArguments_ShouldReturnStringOfAlphabeticChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, CharType.AlphabeticAny);
            var check = result.Select(x => x.IsLetter()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ValidArguments_ShouldReturnStringOfAlphabeticLowerChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, CharType.AlphabeticLower);
            var check = result.Select(x => x.IsLower()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ValidArguments_ShouldReturnStringOfAlphabeticUpperChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, CharType.AlphabeticUpper);
            var check = result.Select(x => x.IsUpper()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ValidArguments_ShouldReturnStringOfAlphanumericChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, CharType.AlphanumericAny);
            var check = result.Select(x => x.IsLetterOrDigit()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ValidArguments_ShouldReturnStringOfAlphanumericLowerChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, CharType.AlphanumericLower);
            var check = result.Select(this.IsAlphanumericLowerChar).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ValidArguments_ShouldReturnStringOfAlphanumericUpperChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, CharType.AlphanumericUpper);
            var check = result.Select(this.IsAlphanumericUpperChar).All(x => x);

            Assert.True(check);
        }

        [Fact(Skip = "//TODO: Needs further investigation")]
        public void NextString_LenghtMaxAllowedValue_ShouldThrowOutOfMemoryException()
        {
            var random = new Random();

            Assert.Throws<OutOfMemoryException>(() => random.NextString(int.MaxValue, CharType.AnyUnicode));
        }

        [Fact]
        public void NextString_ValidArguments_ShouldReturnStringOfNumericChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, CharType.Numeric);
            var check = result.Select(x => x.IsNumber()).All(x => x);

            Assert.True(check);
        }

        private bool IsAlphanumericLowerChar(char currentChar)
        {
            return currentChar.IsNumber() || currentChar.IsLower();
        }

        private bool IsAlphanumericUpperChar(char currentChar)
        {
            return currentChar.IsNumber() || currentChar.IsUpper();
        }
    }
}

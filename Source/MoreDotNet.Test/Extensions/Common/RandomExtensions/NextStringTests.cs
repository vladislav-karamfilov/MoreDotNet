namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;
    using System.Linq;

    using MoreDotNet.Extensions.Common;
    using MoreDotNet.Wrappers;
    using Xunit;

    public class NextStringTests
    {
        private const int Zero = 0;
        private const int StringLength = 100;
        private const int StringLengthLarge = 1000;

        [Fact]
        public void NextString_RandomIsNull_ShouldThrow_ArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextString(StringLength));
        }

        [Fact]
        public void NextString_ShouldReturn_ExpectedLenght()
        {
            var random = new Random();
            var result = random.NextString(StringLength);

            Assert.Equal(StringLength, result.Length);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphabeticChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, MoreDotNet.Models.CharType.AlphabeticAny);
            var check = result.Select(x => x.IsLetter()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphabeticLowerChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, MoreDotNet.Models.CharType.AlphabeticLower);
            var check = result.Select(x => x.IsLower()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphabeticUpperChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, MoreDotNet.Models.CharType.AlphabeticUpper);
            var check = result.Select(x => x.IsUpper()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphanumericChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, MoreDotNet.Models.CharType.AlphanumericAny);
            var check = result.Select(x => x.IsLetterOrDigit()).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphanumericLowerChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, MoreDotNet.Models.CharType.AlphanumericLower);
            var check = result.Select(x => this.IsAlphanumericLowerChar(x)).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphanumericUpperChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, MoreDotNet.Models.CharType.AlphanumericUpper);
            var check = result.Select(x => this.IsAlphanumericUpperChar(x)).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAnyUnicodeChars()
        {
            var random = new Random();
            var result = random.NextString(StringLengthLarge, MoreDotNet.Models.CharType.AnyUnicode);
            var check = result.Select(x => x.GetType() == typeof(char)).All(x => x);

            Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldThrow_OutOfMemoryException()
        {
            var random = new Random();
            Assert.Throws<OutOfMemoryException>(() => random.NextString(int.MaxValue, MoreDotNet.Models.CharType.AnyUnicode));
            //var check = result.Select(x => x.GetType() == typeof(char)).All(x => x);

            //Assert.True(check);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfNumericChars()
        {
            var random = new Random();
            var result = random.NextString(StringLength, MoreDotNet.Models.CharType.Numeric);
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

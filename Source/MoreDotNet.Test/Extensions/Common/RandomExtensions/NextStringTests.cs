namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextStringTests
    {
        private const int Zero = 0;
        private const int OneHundred = 100;

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnStringWithLenghtZero()
        {
            var random = new Random();
            var result = random.NextString(Zero);

            Assert.IsType<string>(result);
            Assert.Equal(Zero, result.Length);
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_WithLenght100Chars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfAlphabeticChars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.AlphabeticAny);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                Assert.True(char.IsLetter(result[i]));
            }
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfAlphabeticLowerChars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.AlphabeticLower);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                Assert.True(char.IsLower(result[i]));
            }
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfAlphabeticUpperChars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.AlphabeticUpper);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                Assert.True(char.IsUpper(result[i]));
            }
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfAlphanumericChars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.AlphanumericAny);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                Assert.True(char.IsLetterOrDigit(result[i]));
            }
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfAlphanumericLowerChars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.AlphanumericLower);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                var currentChar = result[i];
                Assert.True((currentChar >= 48 && currentChar < 58) || (currentChar >= 97 && currentChar < 123));
            }
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfAlphanumericUpperChars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.AlphanumericUpper);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                var currentChar = result[i];
                Assert.True((currentChar >= 48 && currentChar < 58) || (currentChar >= 65 && currentChar < 91));
            }
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfAnyUnicodeChars()
        {
           var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.AnyUnicode);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                Assert.True(result[i] >= 0 && result[i] < 65536);
            }
        }

        [Fact]
        [MemberData(nameof(Random))]
        public void NextString_ShouldReturnString_OfNumericChars()
        {
            var random = new Random();
            var result = random.NextString(OneHundred, MoreDotNet.Models.CharType.Numeric);

            Assert.IsType<string>(result);
            Assert.Equal(OneHundred, result.Length);
            for (int i = 0; i < OneHundred; i++)
            {
                Assert.True(char.IsNumber(result[i]));
            }
        }
    }
}

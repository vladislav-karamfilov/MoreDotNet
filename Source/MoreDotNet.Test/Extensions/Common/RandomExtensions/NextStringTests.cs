namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class NextStringTests
    {
        [Fact]
        public void NextString_ShouldReturnStringWithLenghtZero()
        {
            var zero = 0;
            var random = new Random();
            var result = random.NextString(zero);

            Assert.IsType<string>(result);
            Assert.Equal(zero, result.Length);
        }

        [Fact]
        public void NextString_ShouldReturnString_WithLenghtFiveChars()
        {
            var length = 5;

            var random = new Random();
            var result = random.NextString(length);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphabeticChars()
        {
            var length = 100;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.AlphabeticAny);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(char.IsLetter(result[i]));
            }
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphabeticLowerChars()
        {
            var length = 100;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.AlphabeticLower);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(char.IsLower(result[i]));
            }
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphabeticUpperChars()
        {
            var length = 100;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.AlphabeticUpper);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(char.IsUpper(result[i]));
            }
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphanumericChars()
        {
            var length = 100;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.AlphanumericAny);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(char.IsLetterOrDigit(result[i]));
            }
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphanumericLowerChars()
        {
            var length = 100;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.AlphanumericLower);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(char.IsLetterOrDigit(result[i]) && char.IsLower(result[i]));
            }
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAlphanumericUpperChars()
        {
            var length = 100;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.AlphanumericUpper);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(char.IsLetterOrDigit(result[i]) && char.IsUpper(result[i]));
            }
        }

        [Fact]
        public void NextString_ShouldReturnString_OfAnyUnicodeChars()
        {
            var length = 100;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.AnyUnicode);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(result[i] >= 0 && result[i] < 65536);
            }
        }

        [Fact]
        public void NextString_ShouldReturnString_OfNumericChars()
        {
            var length = 5;

            var random = new Random();
            var result = random.NextString(length, MoreDotNet.Models.CharType.Numeric);

            Assert.IsType<string>(result);
            Assert.Equal(length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.True(char.IsNumber(result[i]));
            }
        }
    }
}

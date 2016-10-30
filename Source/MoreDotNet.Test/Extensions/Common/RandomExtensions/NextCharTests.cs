namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using Moq;
    using MoreDotNet.Extensions.Common;
    using MoreDotNet.Models;
    using Xunit;

    public class NextCharTests
    {
        [Fact]
        public void NextChar_RandomIsNull_ShouldThrowArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextChar());
        }

        [Fact]
        public void NextChar_InvalidCharType_ShouldReturnAlphanumericChar()
        {
            Random random = new Random();
            var result = random.NextChar((CharType)(-1));

            Assert.True(char.IsLetterOrDigit(result));
        }

        [Theory]
        [InlineData('A', 0.168)]
        [InlineData('1', 0.15)]
        public void NextChar_ValidArguments_ShoudReturnAlphanumeriAny(char expectedResult, double returns)
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(returns);
            char actualResult = randomMock.Object.NextChar();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void NextChar_ValidArguments_ShoudReturnAnyUnicodeChar()
        {
            var expectedChar = '2';

            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedChar);
            char actualResult = randomMock.Object.NextChar(CharType.AnyUnicode);

            Assert.Equal(expectedChar, actualResult);
        }

        [Theory]
        [InlineData('a', 0.51, CharType.AlphabeticLower)]
        [InlineData('A', 0.49, CharType.AlphabeticUpper)]
        [InlineData('A', 0.49, CharType.AlphabeticAny)]
        [InlineData('a', 0.51, CharType.AlphanumericLower)]
        [InlineData('A', 0.49, CharType.AlphanumericUpper)]
        [InlineData('A', 0.49, CharType.AlphanumericAny)]
        [InlineData('2', 0.1, CharType.Numeric)]
        public void NextChar_ValidArguments_ShoudReturnExpectedCharType(char expectedResult, double returns, CharType charType)
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(returns);
            char actualResult = randomMock.Object.NextChar(charType);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}

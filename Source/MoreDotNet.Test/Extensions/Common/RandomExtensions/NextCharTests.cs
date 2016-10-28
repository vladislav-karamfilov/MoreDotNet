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
        public void NextChar_ShouldThrow_ArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.NextChar());
        }

        [Fact]
        public void NextChar_ShouldReturn_AlphanumericChar()
        {
            Random random = new Random();
            var result = random.NextChar((CharType)(-1));

            Assert.True(char.IsLetterOrDigit(result));
        }

        [Fact]
        public void NextChar_ShouldReturn_AlphanumericCharAny()
        {
            var random = new Random();
            var result = random.NextChar();

            Assert.IsType<char>(result);
        }

        [Theory]
        [InlineData('A', 0.168)]
        [InlineData('1', 0.15)]
        public void NextChar_ShoudReturnChar_CapitalLetter(char expectedResult, double returns)
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(returns);
            char actualResult = randomMock.Object.NextChar();

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData('2', CharType.AnyUnicode)]
        public void NextChar_ShoudReturnChar_AnyUnicode(char expectedResult, CharType charType)
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedResult);
            char actualResult = randomMock.Object.NextChar(charType);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData('a', 0.51, CharType.AlphabeticLower)]
        [InlineData('A', 0.49, CharType.AlphabeticUpper)]
        [InlineData('A', 0.49, CharType.AlphabeticAny)]
        [InlineData('a', 0.51, CharType.AlphanumericLower)]
        [InlineData('A', 0.49, CharType.AlphanumericUpper)]
        [InlineData('A', 0.49, CharType.AlphanumericAny)]
        [InlineData('2', 0.1, CharType.Numeric)]
        public void NextChar_ShoudReturn_ValidChar(char expectedResult, double returns, CharType charType)
        {
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(returns);
            char actualResult = randomMock.Object.NextChar(charType);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}

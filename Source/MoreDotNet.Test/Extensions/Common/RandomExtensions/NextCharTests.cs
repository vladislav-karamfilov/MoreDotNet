namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using Moq;
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextCharTests
    {
        [Fact]
        public void NextChar_ShouldReturnChar()
        {
            var random = new Random();
            var result = random.NextChar();

            Assert.IsType<char>(result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_CapitalLetter()
        {
            char mockedResult = 'A';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.168);
            char result = randomMock.Object.NextChar();

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_Number()
        {
            char mockedResult = '1';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.15);
            char result = randomMock.Object.NextChar();

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_AlphabeticLower()
        {
            char mockedResult = 'a';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.51);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.AlphabeticLower);

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_AlphabeticUpper()
        {
            char mockedResult = 'A';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.49);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.AlphabeticUpper);

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_AlphabeticAny()
        {
            char mockedResult = 'A';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.49);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.AlphabeticAny);

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_AlphanumericAny()
        {
            char mockedResult = 'A';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.49);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.AlphanumericAny);

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_AlphanumericLower()
        {
            char mockedResult = 'a';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.51);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.AlphanumericLower);

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_AlphanumericUpper()
        {
            char mockedResult = 'A';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.49);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.AlphanumericUpper);

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_Numeric()
        {
            char mockedResult = '2';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            randomMock.Setup(r => r.NextDouble()).Returns(0.1);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.Numeric);

            Assert.Equal((int)mockedResult, (int)result);
        }

        [Fact]
        public void NextChar_ShoudReturnChar_AnyUnicode()
        {
            char mockedResult = '2';
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)mockedResult);
            char result = randomMock.Object.NextChar(MoreDotNet.Models.CharType.AnyUnicode);

            Assert.Equal((int)mockedResult, (int)result);
        }
    }
}

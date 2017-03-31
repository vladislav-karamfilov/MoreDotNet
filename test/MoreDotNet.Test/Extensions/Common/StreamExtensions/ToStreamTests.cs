namespace MoreDotNet.Test.Extensions.Common.StreamExtensions
{
    using System;
    using System.IO;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class ToStreamTests
    {
        [Fact]
        public void ToStream_OnNullInput_ShouldThrowArgumentNullException()
        {
            byte[] input = null;
            Assert.Throws<ArgumentNullException>(() => input.ToStream());
        }

        [Theory]
        [InlineData(new byte[0])]
        [InlineData(new byte[] { 0, 1, 2, 3, 4, 5 })]
        [InlineData(new byte[] { 0, 255, 4, 123 })]
        [InlineData(new byte[] { 0, 1, 2, 3, 4, 5 })]
        public void ToStream_OnByteArray_ReturnsCorrectStream(byte[] inputByteArray)
        {
            var expectedStream = new MemoryStream(inputByteArray);
            var actualStream = inputByteArray.ToStream();

            var expectedBuffer = new byte[16];
            int expected;
            var actualBuffer = new byte[16];

            while ((expected = expectedStream.Read(expectedBuffer, 0, expectedBuffer.Length)) > 0)
            {
                var actual = actualStream.Read(actualBuffer, 0, actualBuffer.Length);
                Assert.Equal(expected, actual);
            }
        }
    }
}

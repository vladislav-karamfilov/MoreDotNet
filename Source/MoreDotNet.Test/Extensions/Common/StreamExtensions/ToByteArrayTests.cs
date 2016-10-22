namespace MoreDotNet.Tests.Extensions.Common.StreamExtensions
{
    using System;
    using System.IO;
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class ToByteArrayTests
    {
        [Fact]
        public void ToByteArray_ThrowsOnNull()
        {
            Stream input = null;
            Assert.Throws<ArgumentNullException>(() => input.ToByteArray());
        }

        [Theory]
        [InlineData(new byte[0])]
        [InlineData(new byte[] { 0, 1, 2, 3, 4, 5 })]
        [InlineData(new byte[] { 0, 255, 4, 123 })]
        [InlineData(new byte[] { 0, 1, 2, 3, 4, 5 })]
        public void ToByteArray_WorksOnInputStreams(byte[] expectedByteArray)
        {
            var stream = new MemoryStream(expectedByteArray);
            Assert.Equal(expectedByteArray, stream.ToByteArray());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        [InlineData(10000000)]
        public void ToByteArray_WorksOnVeryLongStreamsAsExpected(int length)
        {
            var array = new byte[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = (byte)(i % 256);
            }

            var stream = new MemoryStream(array);
            Assert.Equal(array, stream.ToByteArray());
        }
    }
}

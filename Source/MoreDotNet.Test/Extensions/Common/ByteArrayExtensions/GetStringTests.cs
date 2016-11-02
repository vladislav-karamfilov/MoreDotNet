using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MoreDotNet.Tests.Extensions.Common.ByteArrayExtensions
{
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class GetStringTests
    {
        [Fact]
        public void GetString_NullBuffer_ShouldReturnEmptyString()
        {
            byte[] buffer = null;
            var result = buffer.GetString();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetString_ZeroLengthBuffer_ShouldReturnEmptyString()
        {
            var buffer = new byte[] { };
            var result = buffer.GetString();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetString_UTF8_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(Encoding.UTF8, "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_Unicode_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(Encoding.Unicode, "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_BigEndianUnicode_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(Encoding.BigEndianUnicode, "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_UTF32_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(Encoding.UTF32, "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_UTF32BigEndian_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(new UTF32Encoding(true, true), "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_UTF7_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(Encoding.UTF7, "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_ANSI_Specified_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(Encoding.Default, "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_NoEncodingSpecified_ShouldReturnProperString()
        {
            var buffer = new byte[] { 77, 111, 114, 101, 32, 68, 111, 116, 32, 78, 101, 116 };
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_ASCII_ShouldReturnProperString()
        {
            var buffer = GetBytesWithPreamble(Encoding.ASCII, "More Dot Net");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        private static byte[] GetBytesWithPreamble(Encoding encoding, string data) => encoding.GetPreamble().Concat(encoding.GetBytes(data)).ToArray();
    }
}

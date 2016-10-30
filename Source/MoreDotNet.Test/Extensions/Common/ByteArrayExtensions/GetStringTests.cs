using System.IO;
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
            File.WriteAllText("temp.txt", "More Dot Net", Encoding.UTF8);
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_Unicode_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net", Encoding.Unicode);
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_BigEndianUnicode_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net", Encoding.BigEndianUnicode);
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_UTF32_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net", Encoding.UTF32);
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_UTF32BigEndian_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net", new UTF32Encoding(true, true));
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_UTF7_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net", Encoding.UTF7);
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_ANSI_Specified_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net", Encoding.Default);
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_NoEncodingSpecified_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net");
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }

        [Fact]
        public void GetString_ASCII_ShouldReturnProperString()
        {
            File.WriteAllText("temp.txt", "More Dot Net", Encoding.ASCII);
            var buffer = File.ReadAllBytes("temp.txt");
            var result = buffer.GetString();

            Assert.Equal(result, "More Dot Net");
        }
    }
}

namespace MoreDotNet.Extensions.Common
{
    using System.IO;
    using System.Text;

    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts a byte array to a string, using its byte order mark to convert it to the right encoding.
        /// Original article: http://www.west-wind.com/WebLog/posts/197245.aspx
        /// </summary>
        /// <param name="buffer">An array of bytes to convert.</param>
        /// <returns>The byte as a string.</returns>
        public static string GetString(this byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                return string.Empty;
            }

            // ANSI as default
            var encoding = Encoding.Default;

            /*
                EF BB BF UTF-8
                FF FE UTF-16 little endian
                FE FF UTF-16 big endian
                FF FE 00 00UTF-32, little endian
                00 00 FE FFUTF-32, big-endian
            */

            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
            {
                encoding = Encoding.UTF8;
            }

            // In addition to preamble check the length to help UTF-16 with leading zeros be recognized properly as UTF-32 is always 4 bytes fixed width and UTF-16 could be 2 or 4
            else if (buffer[0] == 0xff && buffer[1] == 0xfe && buffer[2] == 0 && buffer[3] == 0 && buffer.Length % 4 == 0)
            {
                encoding = Encoding.UTF32;
            }
            else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)
            {
                encoding = new UTF32Encoding(true, true);
            }
            else if (buffer[0] == 0xff && buffer[1] == 0xfe)
            {
                encoding = Encoding.Unicode;
            }
            else if (buffer[0] == 0xfe && buffer[1] == 0xff)
            {
                encoding = Encoding.BigEndianUnicode; // utf-16be
            }
            else if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)
            {
                encoding = Encoding.UTF7;
            }

            using (var stream = new MemoryStream())
            {
                stream.Write(buffer, 0, buffer.Length);
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

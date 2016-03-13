namespace MoreDotNet.Extentions.Common
{
    using System.IO;

    public static class StreamExtensions
    {
        /// <summary>
        /// Converts a <see cref="Stream"/> to a byte array.
        /// </summary>
        /// <param name="input">The <see cref="Stream"/> being converted.</param>
        /// <returns>A byte array representing a <see cref="Stream"/> contents.</returns>
        public static byte[] ToByteArray(this Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var memoryStream = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Converts a byte array to a <see cref="Stream"/>
        /// </summary>
        /// <param name="input">The byte array being converted.</param>
        /// <returns>A <see cref="Stream"/> representing the contents of a byte array.</returns>
        public static Stream ToStream(this byte[] input)
        {
            var fileStream = new MemoryStream(input) { Position = 0 };
            return fileStream;
        }
    }
}

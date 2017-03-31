namespace MoreDotNet.Extensions.Common
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// XML extensions.
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Serializes an object of type T in to an XML string
        /// </summary>
        /// <typeparam name="T">Any class type</typeparam>
        /// <param name="inputObject">Object to serialize</param>
        /// <returns>A string that represents XML, empty otherwise</returns>
        public static string XmlSerialize<T>(this T inputObject)
            where T : class, new()
        {
            if (inputObject == null)
            {
                throw new ArgumentNullException(nameof(inputObject));
            }

            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, inputObject);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Deserializes an XML string in to an object of Type T
        /// </summary>
        /// <typeparam name="T">Any class type</typeparam>
        /// <param name="inputXml">XML as string to deserialize from</param>
        /// <returns>A new object of type T is successful, null if failed</returns>
        public static T XmlDeserialize<T>(this string inputXml)
            where T : class, new()
        {
            if (inputXml == null)
            {
                throw new ArgumentNullException(nameof(inputXml));
            }

            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(inputXml))
            {
                try
                {
                    return (T)serializer.Deserialize(reader);
                }
                catch
                {
                    // Could not be deserialized to this type.
                    return null;
                }
            }
        }
    }
}

namespace MoreDotNet.Tests.Extensions.Common.XmlExtensions
{
    using System;

    using System.IO;

    using System.Xml;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class XmlExtensionsTests
    {
        [Fact]
        public void XmlSerialize_GivenNullArgument_ShouldThrowException()
        {
            object testObject = null;

            Assert.Throws<ArgumentNullException>(() => testObject.XmlSerialize());
        }

        [Fact]
        public void XmlSerialize_GivenNonNullArgument_ShouldReturnSerialized()
        {
            object testObject = new object();
            string modelSerialized = testObject.XmlSerialize();

            Assert.NotNull(modelSerialized);
            Assert.NotEqual(modelSerialized.Length, 0);

            using (var stringReader = new StringReader(modelSerialized))
            {
                using (var xmlReader = XmlReader.Create(stringReader))
                {
                    Assert.True(xmlReader.Read());
                }
            }
        }

        [Fact]
        public void XmlDeserialize_GivenNullArgument_ShouldThrowException()
        {
            string testSerializedObject = null;

            Assert.Throws<ArgumentNullException>(() => testSerializedObject.XmlDeserialize<object>());
        }

        [Fact]
        public void XmlDeserialize_GivenNonNullArgument_ShouldReturnDeserialized()
        {
            XmlSerializableModel model = new XmlSerializableModel("Hello World");
            string modelSerialized = model.XmlSerialize();

            XmlSerializableModel modelDeserialized = modelSerialized.XmlDeserialize<XmlSerializableModel>();

            Assert.NotNull(modelDeserialized);
            Assert.Equal(modelDeserialized, model);
        }
    }
}

namespace MoreDotNet.Tests.Extensions.Common.XmlExtensions
{
    using System;

    using System.IO;

    using System.Xml;

    using MoreDotNet.Extensions.Common;
    using MoreDotNet.Tests.Models;

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
            var testObject = new object();
            var modelSerialized = testObject.XmlSerialize();

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
            var model = new XmlSerializableModel("Hello World");
            var modelSerialized = model.XmlSerialize();

            var modelDeserialized = modelSerialized.XmlDeserialize<XmlSerializableModel>();

            Assert.NotNull(modelDeserialized);
            Assert.Equal(modelDeserialized, model);
        }

        [Fact]
        public void XmlDeserialize_GivenIncorrectDeserializationType_ShoudlReturnNul()
        {
            var model = new XmlSerializableModel("Hello World");
            var modelSerialized = model.XmlSerialize();

            var modelDeserialized = modelSerialized.XmlDeserialize<FakeSerializationClass>();

            Assert.Null(modelDeserialized);
        }
    }
}

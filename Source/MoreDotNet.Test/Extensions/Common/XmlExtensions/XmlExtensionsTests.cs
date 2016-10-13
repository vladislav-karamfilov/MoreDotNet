namespace MoreDotNet.Tests.Extensions.Common.XmlExtensions
{
    using System;

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

            Assert.NotNull(testObject.XmlSerialize());
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
            object testObject = new object();
            string testSerializedObject = testObject.XmlSerialize();

            Assert.NotNull(testSerializedObject.XmlDeserialize<object>());
        }
    }
}

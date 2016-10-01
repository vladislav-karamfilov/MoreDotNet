namespace MoreDotNet.Tests.Extentions.Collections.DictionaryExtensions
{
    using System.Collections.Generic;

    using MoreDotNet.Extentions.Collections;

    using Xunit;

    public class GetKeyIgnoringCaseTests
    {
        private readonly IDictionary<string, int> testDictionary;

        public GetKeyIgnoringCaseTests()
        {
            this.testDictionary = new Dictionary<string, int>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("             ")]
        [InlineData(null)]
        public void GetKeyIgnoringCase_InvalidKeyGiven_ShouldReturnEmptyString(string key)
        {
            Assert.Equal(string.Empty, this.testDictionary.GetKeyIgnoringCase(key));
        }

        [Fact]
        public void GetKeyIgnoringCase_ValidKeyGiven_ShouldReturnFirstKey()
        {
            this.testDictionary.Add("TestKey", 12);
            this.testDictionary.Add("testKey", 13);

            var expected = "TestKey";
            var actual = this.testDictionary.GetKeyIgnoringCase("testkey");

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetKeyIgnoringCase_NonExistingKeyGiven_ShouldReturnEmptyString()
        {
            var expected = string.Empty;
            var actual = this.testDictionary.GetKeyIgnoringCase("testkey");

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }
    }
}

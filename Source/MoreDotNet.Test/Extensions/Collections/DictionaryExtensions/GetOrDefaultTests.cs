namespace MoreDotNet.Tests.Extensions.Collections.DictionaryExtensions
{
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class GetOrDefaultTests
    {
        private readonly IDictionary<string, int> testDictionary;

        public GetOrDefaultTests()
        {
            this.testDictionary = new Dictionary<string, int>();
        }

        [Fact]
        public void GetOrDefault_ExistingKeyGiven_ShouldRetrunValue()
        {
            const string TestKeyName = "testKey";

            this.testDictionary.Add(TestKeyName, 99);
            var expected = 99;
            var actual = this.testDictionary.GetOrDefault(TestKeyName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetOrDefault_NonExistingKeyGiven_ShouldRetrunDefaultValueIfNothingElseIsSpecified()
        {
            var expected = default(int);
            var actual = this.testDictionary.GetOrDefault("FakeKey");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetOrDefault_NonExistingKeyGiven_ShouldRetrunSpecifiedValue()
        {
            var expected = 66;
            var actual = this.testDictionary.GetOrDefault("FakeKey", 66);

            Assert.Equal(expected, actual);
        }
    }
}

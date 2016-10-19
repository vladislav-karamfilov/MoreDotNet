namespace MoreDotNet.Tests.Extensions.Common.ObjectExtensions
{
    using System;
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class ToDictionaryTests
    {
        [Fact]
        public void ToDictionary_Null_ShouldThrowArgumentNullException()
        {
            Example input = null;
            Assert.Throws<ArgumentNullException>(() => input.ToDictionary());
        }

        [Fact]
        public void ToDictionary_ExampleA_ShouldReturnDictionaryWithKeysAndValues()
        {
            var input = new Example
            {
                One = "First",
                Two = "Second"
            };
            var result = input.ToDictionary();

            Assert.True(result.ContainsKey("One"));
            Assert.Equal("First", result["One"]);

            Assert.True(result.ContainsKey("Two"));
            Assert.Equal("Second", result["Two"]);
        }

        private class Example
        {
            public string One { get; set; }

            public string Two { get; set; }
        }
    }
}

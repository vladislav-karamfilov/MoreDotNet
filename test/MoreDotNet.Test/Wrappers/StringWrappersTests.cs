namespace MoreDotNet.Test.Wrappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Extensions.Common;
    using MoreDotNet.Wrappers;

    using Xunit;

    public class StringWrappersTests
    {
        public static IEnumerable<object[]> RandomString
        {
            get
            {
                var randomGenerator = new Random();
                var result =
                    Enumerable.Range(0, 10)
                        .Select(x => new object[] { randomGenerator.NextString(randomGenerator.Next(0, 100)) })
                        .ToList();

                return result;
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("             ")]
        [InlineData(null)]
        public void IsNullOrWhiteSpace_GivenSameInput_ShouldHaveSameBehavior(string input)
        {
            var expected = string.IsNullOrWhiteSpace(input);
            var actual = input.IsNullOrWhiteSpace();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomString))]
        public void IsNullOrWhiteSpace_GivenRandomInput_ShouldHaveSameBehavior(string input)
        {
            var expected = string.IsNullOrWhiteSpace(input);
            var actual = input.IsNullOrWhiteSpace();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("             ")]
        [InlineData(null)]
        public void IsNullOrEmpty_GivenSameInput_ShouldHaveSameBehavior(string input)
        {
            var expected = string.IsNullOrEmpty(input);
            var actual = input.IsNullOrEmpty();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomString))]
        public void IsNullOrEmpty_GivenRandomInput_ShouldHaveSameBehavior(string input)
        {
            var expected = string.IsNullOrEmpty(input);
            var actual = input.IsNullOrEmpty();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomString))]
        public void IsInterned_GivenRandomInput_ShouldHaveSameBehavior(string input)
        {
            var expected = string.IsInterned(input);
            var actual = input.IsInterned();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomString))]
        public void Intern_GivenRandomInput_ShouldHaveSameBehavior(string input)
        {
            var expected = string.Intern(input);
            var actual = input.Intern();
            Assert.Equal(expected, actual);
        }
    }
}

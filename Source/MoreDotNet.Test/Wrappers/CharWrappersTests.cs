namespace MoreDotNet.Tests.Wrappers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using MoreDotNet.Extentions.Common;
    using MoreDotNet.Models;
    using MoreDotNet.Wrappers;

    using Xunit;

    public class CharWrappersTests
    {
        public static IEnumerable<object[]> RandomChars
        {
            get
            {
                var randomGenerator = new Random();
                var result =
                    Enumerable.Range(0, 10)
                        .Select(x => new object[] { randomGenerator.NextChar(CharType.AnyUnicode) })
                        .ToList();

                return result;
            }
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void ToLower_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.ToLower(input);
            var actual = input.ToLower();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void ToLowerEncoding_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.ToLower(input, CultureInfo.InvariantCulture);
            var actual = input.ToLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void ToUpperEncoding_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.ToUpper(input, CultureInfo.InvariantCulture);
            var actual = input.ToUpper(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void ToLowerInvariant_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.ToLowerInvariant(input);
            var actual = input.ToLowerInvariant();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void ToUpper_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.ToUpper(input);
            var actual = input.ToUpper();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void ToUpperInvariant_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.ToUpperInvariant(input);
            var actual = input.ToUpperInvariant();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsControl_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsControl(input);
            var actual = input.IsControl();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsDigit_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsDigit(input);
            var actual = input.IsDigit();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsHighSurrogate_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsHighSurrogate(input);
            var actual = input.IsHighSurrogate();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsLetter_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsLetter(input);
            var actual = input.IsLetter();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsLetterOrDigit_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsLetterOrDigit(input);
            var actual = input.IsLetterOrDigit();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsLowSurrogatet_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsLowSurrogate(input);
            var actual = input.IsLowSurrogate();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsNumber_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsNumber(input);
            var actual = input.IsNumber();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsPunctuation_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsPunctuation(input);
            var actual = input.IsPunctuation();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsSeparator_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsSeparator(input);
            var actual = input.IsSeparator();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsSurrogate_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsSurrogate(input);
            var actual = input.IsSurrogate();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsSymbol_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsSymbol(input);
            var actual = input.IsSymbol();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsUpper_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsUpper(input);
            var actual = input.IsUpper();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsLower_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsLower(input);
            var actual = input.IsLower();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void IsWhiteSpace_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.IsWhiteSpace(input);
            var actual = input.IsWhiteSpace();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void GetNumericValue_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.GetNumericValue(input);
            var actual = input.GetNumericValue();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomChars))]
        public void GetUnicodeCategory_GivenRandomInput_ShouldHaveSameBehavior(char input)
        {
            var expected = char.GetUnicodeCategory(input);
            var actual = input.GetUnicodeCategory();
            Assert.Equal(expected, actual);
        }
    }
}

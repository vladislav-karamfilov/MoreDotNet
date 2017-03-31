namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class CaseToWordsTests
    {
        [Fact]
        public void CaseToWords_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string input = string.Empty;
            string actual = input.CaseToWords();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaseToWords_ParseNullString_ShouldReturnNullString()
        {
            string input = null;
            Assert.Throws<ArgumentNullException>(() => input.CaseToWords());
        }

        [Fact]
        public void CaseToWords_ParseParseCamelCaseWord_ShouldReturnSeparatedWords()
        {
            string expected = "sample Camel Case Word";
            string input = "sampleCamelCaseWord";
            string actual = input.CaseToWords();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaseToWords_ParsePascalCamelCaseWord_ShouldReturnSeparatedWords()
        {
            string expected = "Sample Camel Case Word";
            string input = "SampleCamelCaseWord";
            string actual = input.CaseToWords();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaseToWords_ParseAllUpperWord_ShouldSameString()
        {
            string expected = "SAMPLEWORDHERE";
            string input = "SAMPLEWORDHERE";
            string actual = input.CaseToWords();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaseToWords_ParseNumberString_ShouldSameString()
        {
            string expected = "999666333";
            string input = "999666333";
            string actual = input.CaseToWords();
            Assert.Equal(expected, actual);
        }
    }
}

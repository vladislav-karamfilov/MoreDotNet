namespace MoreDotNet.Test.Extensions.Common.StringExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class IsLikeTests
    {
        [Fact]
        public void IsLike_CompareBasicPatterns_ShouldPass()
        {
            Assert.True("F".IsLike("F"));
            Assert.False("F".IsLike("f"));
            Assert.False("F".IsLike("FFF"));
            Assert.True("aBBBa".IsLike("a*a"));
            Assert.True("F".IsLike("[A-Z]"));
            Assert.False("F".IsLike("[!A-Z]"));
            Assert.True("a2a".IsLike("a#a"));
            Assert.True("aM5b".IsLike("a[L-P]#[!c-e]"));
            Assert.True("BAT123khg".IsLike("B?T*"));
            Assert.False("CAT123khg".IsLike("B?T*"));
        }

        [Fact]
        public void IsLike_IfPatternIsNull_ShouldReturnFalse()
        {
            Assert.False("F".IsLike(null));
        }

        [Fact]
        public void IsLike_IfPatternIsEmptyString_ShouldReturnFalse()
        {
            Assert.False("F".IsLike(string.Empty));
        }

        [Fact]
        public void IsLike_IfPatternIsWhiteSpace_ShouldReturnFalse()
        {
            Assert.False("F".IsLike(new string(' ', 30)));
        }

        [Fact]
        public void IsLike_IfInputStringIsNull_ShouldReturnFalse()
        {
            string input = null;
            Assert.False(input.IsLike(new string(' ', 30)));
        }

        [Fact]
        public void IsLike_PatternIsInvalid_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => "F".IsLike("["));
        }
    }
}

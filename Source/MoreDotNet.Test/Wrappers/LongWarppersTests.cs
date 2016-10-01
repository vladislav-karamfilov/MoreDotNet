namespace MoreDotNet.Tests.Wrappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Wrappers;

    using Xunit;

    public class LongWarppersTests
    {
        public static IEnumerable<object[]> RandomLongs
        {
            get
            {
                var randomGenerator = new Random();
                var result =
                    Enumerable.Range(0, 10)
                        .Select(x => new object[] { randomGenerator.Next() })
                        .ToList();

                return result;
            }
        }

        [Theory]
        [MemberData(nameof(RandomLongs))]
        public void FromOaCurrency_GivenRandomInput_ShouldHaveSameBehavior(long input)
        {
            var expected = decimal.FromOACurrency(input);
            var actual = input.FromOaCurrency();
            Assert.Equal(expected, actual);
        }
    }
}

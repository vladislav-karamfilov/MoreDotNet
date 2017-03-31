namespace MoreDotNet.Test.Wrappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreDotNet.Wrappers;

    using Xunit;

    public class DecimalWrappersTests
    {
        public static IEnumerable<object[]> RandomDecimals
        {
            get
            {
                var randomGenerator = new Random();
                var result =
                    Enumerable.Range(0, 10)
                        .Select(x => new object[] { (decimal)randomGenerator.NextDouble() })
                        .ToList();

                return result;
            }
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void Ceiling_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Ceiling(input);
            var actual = input.Ceiling();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void Floor_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Floor(input);
            var actual = input.Floor();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToOaCurrency_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToOACurrency(input);
            var actual = input.ToOaCurrency();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToByte_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToByte(input);
            var actual = input.ToByte();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToSByte_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToSByte(input);
            var actual = input.ToSByte();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToShort_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToInt16(input);
            var actual = input.ToShort();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToUShort_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToUInt16(input);
            var actual = input.ToUShort();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToInt_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToInt32(input);
            var actual = input.ToInt();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToUInt_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToUInt32(input);
            var actual = input.ToUInt();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToLong_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToInt64(input);
            var actual = input.ToLong();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToULong_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToUInt64(input);
            var actual = input.ToULong();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToFloat_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToSingle(input);
            var actual = input.ToFloat();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void ToDouble_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.ToDouble(input);
            var actual = input.ToDouble();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void GetBits_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.GetBits(input);
            var actual = input.GetBits();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void Round_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Round(input);
            var actual = input.Round();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void RoundDecimals_GivenRandomInputAndMidpointAwayFromZero_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Round(input, 1, MidpointRounding.AwayFromZero);
            var actual = input.Round(MidpointRounding.AwayFromZero, 1);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void RoundDecimals_GivenRandomInputAndMidpointToEven_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Round(input, 1, MidpointRounding.ToEven);
            var actual = input.Round(MidpointRounding.ToEven, 1);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void Round_GivenRandomInputAndMidpointAwayFromZero_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Round(input, MidpointRounding.AwayFromZero);
            var actual = input.Round(MidpointRounding.AwayFromZero);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void Round_GivenRandomInputAndMidpointToEven_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Round(input, MidpointRounding.ToEven);
            var actual = input.Round(MidpointRounding.ToEven);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RandomDecimals))]
        public void Truncate_GivenRandomInput_ShouldHaveSameBehavior(decimal input)
        {
            var expected = decimal.Truncate(input);
            var actual = input.Truncate();
            Assert.Equal(expected, actual);
        }
    }
}

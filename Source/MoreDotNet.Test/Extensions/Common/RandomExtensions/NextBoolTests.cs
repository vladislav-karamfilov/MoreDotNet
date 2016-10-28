namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextBoolTests
    {
        [Fact]
        public void NextBool_ShouldHThrow_NullReferenceException()
        {
            Random random = null;

            Assert.Throws<NullReferenceException>(() => random.Next());
        }

        [Fact]
        public void NextBool_ShouldReturn_True()
        {
            var random = new Random();
            var result = random.NextBool(1);

            Assert.True(result);
        }

        [Fact]
        public void NextBool_ShouldReturnTrue_MoreThanOrEqualTo50Times()
        {
            var random = new Random();
            int returnedTrueAsResult = 0;
            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                if (random.NextBool())
                {
                    returnedTrueAsResult++;
                }
            }

            Assert.True(returnedTrueAsResult >= count / 2);
        }

        [Fact]
        public void NextBool_ShouldReturn_False()
        {
            var random = new Random();
            var result = random.NextBool(0);

            Assert.False(result);
        }
    }
}

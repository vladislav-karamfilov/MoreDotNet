namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextBoolTests
    {
        private const int Counter = 10;

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
        public void NextBool_ShouldReturn_TrueOrFalse_AtLeastOnce()
        {
            var random = new Random();
            int returnedTrueAsResult = 0;
            int returnedFalseAsResult = 0;
            for (int i = 0; i < Counter; i++)
            {
                if (random.NextBool())
                {
                    returnedTrueAsResult++;
                }
                else
                {
                    returnedFalseAsResult++;
                }
            }

            Assert.True(returnedTrueAsResult > 0);
            Assert.True(returnedFalseAsResult > 0);
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

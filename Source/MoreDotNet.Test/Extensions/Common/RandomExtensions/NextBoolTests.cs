namespace MoreDotNet.Tests.Extensions.Common.RandomExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextBoolTests
    {
        [Fact]
        public void NextBool_ShouldReturnTrue()
        {
            var random = new Random();
            var result = random.NextBool(1);

            Assert.True(result);
        }

        [Fact]
        public void NextBool_ShouldReturnTrue_MoreThanOrEqualTo50Times()
        {
            var random = new Random();
            int counter = 0;
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int currentCount = 100;
                int currentCounter = 0;
                var nextBools = new bool[currentCount];
                for (int j = 0; j < currentCount; j++)
                {
                    if (random.NextBool(0.5))
                    {
                        currentCounter++;
                    }
                }

                if (currentCount >= 50)
                {
                    counter++;
                }
            }

            Assert.True(counter >= count / 2);
        }

        [Fact]
        public void NextBool_ShouldReturnFalse()
        {
            var random = new Random();
            var result = random.NextBool(0);

            Assert.False(result);
        }
    }
}

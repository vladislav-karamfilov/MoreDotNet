namespace MoreDotNet.Tests.Extentions.Common.CollectionExtentions
{
    using System.Collections.Generic;

    using MoreDotNet.Extentions.Common;

    using Xunit;

    public class IsNullOrEmptyTests
    {
        [Fact]
        public void IsNullOrEmpty_NullCollectionGiven_ShouldReturnTrue()
        {
            ICollection<int> input = null;
            Assert.True(input.IsNullOrEmpty());
        }

        [Fact]
        public void IsNullOrEmpty_EmptyCollectionGiven_ShouldReturnTrue()
        {
            ICollection<int> input = new HashSet<int>();
            Assert.True(input.IsNullOrEmpty());
        }

        [Fact]
        public void IsNullOrEmpty_NonEmptyCollectionGiven_ShouldReturnFalse()
        {
            ICollection<int> input = new HashSet<int> { 1, 2, 3, 4, 5 };
            Assert.False(input.IsNullOrEmpty());
        }
    }
}

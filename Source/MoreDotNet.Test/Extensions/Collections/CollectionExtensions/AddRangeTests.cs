namespace MoreDotNet.Tests.Extensions.Collections.CollectionExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class AddRangeTests
    {
        [Fact]
        public void AddRange_ItemsAsParams_ShouldBeAddedToCollection()
        {
            ICollection<int> expected = new HashSet<int> { 1, 2, 3, 4, 5 };
            ICollection<int> input = new HashSet<int> { 1 };
            input.AddRange(2, 3, 4, 5);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddRange_ItemsAsIEnumerable_ShouldBeAddedToCollection()
        {
            ICollection<int> expected = new HashSet<int> { 1, 2, 3, 4, 5 };
            ICollection<int> input = new HashSet<int> { 1 };
            IEnumerable<int> itemsToAdd = new HashSet<int> { 2, 3, 4, 5 };
            input.AddRange(itemsToAdd);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddRange_NullItemsGiven_ShouldThrowException()
        {
            ICollection<int> input = new HashSet<int> { 1, 2, 3, 4, 5 };
            Assert.Throws<ArgumentNullException>(() => input.AddRange(null));
        }
    }
}

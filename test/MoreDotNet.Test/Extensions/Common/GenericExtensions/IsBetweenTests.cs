namespace MoreDotNet.Test.Extensions.Common.GenericExtensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Moq;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class IsBetweenTests
    {
        private const int IsBigger = 1;
        private const int IsEqual = 0;
        private const int IsSmaller = -1;
        private readonly Mock<IComparableWithSelf> actualMock = new Mock<IComparableWithSelf>();
        private readonly Mock<IComparableWithSelf> lowerBoundMock = new Mock<IComparableWithSelf>();
        private readonly Mock<IComparableWithSelf> upperBoundMock = new Mock<IComparableWithSelf>();

        public interface IComparableWithSelf : IComparable<IComparableWithSelf>
        {
        }

        [Fact]
        public void IsBetween_WhenInRange_ShouldReturnTrue()
        {
            this.actualMock.Setup(x => x.CompareTo(this.lowerBoundMock.Object)).Returns(IsBigger);
            this.actualMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);
            this.lowerBoundMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);

            var actual = this.actualMock.Object.IsBetween(this.lowerBoundMock.Object, this.upperBoundMock.Object);
            Assert.True(actual);
        }

        [Fact]
        public void IsBetween_WhenSmallerThanLowerBound_ShouldReturnFalse()
        {
            this.actualMock.Setup(x => x.CompareTo(this.lowerBoundMock.Object)).Returns(IsSmaller);
            this.actualMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);
            this.lowerBoundMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);

            var actual = this.actualMock.Object.IsBetween(this.lowerBoundMock.Object, this.upperBoundMock.Object);
            Assert.False(actual);
        }

        [Fact]
        public void IsBetween_WhenBiggerThanUpperBound_ShouldReturnFalse()
        {
            this.actualMock.Setup(x => x.CompareTo(this.lowerBoundMock.Object)).Returns(IsBigger);
            this.actualMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsBigger);
            this.lowerBoundMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);

            var actual = this.actualMock.Object.IsBetween(this.lowerBoundMock.Object, this.upperBoundMock.Object);
            Assert.False(actual);
        }

        [Fact]
        public void IsBetween_WhenExactlyUpperBound_ShouldReturnFalse()
        {
            this.actualMock.Setup(x => x.CompareTo(this.lowerBoundMock.Object)).Returns(IsBigger);
            this.actualMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsEqual);
            this.lowerBoundMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);

            var actual = this.actualMock.Object.IsBetween(this.lowerBoundMock.Object, this.upperBoundMock.Object);
            Assert.False(actual);
        }

        [Fact]
        public void IsBetween_WhenExactlyLowerBound_ShouldReturnTrue()
        {
            this.actualMock.Setup(x => x.CompareTo(this.lowerBoundMock.Object)).Returns(IsEqual);
            this.actualMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);
            this.lowerBoundMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);

            var actual = this.actualMock.Object.IsBetween(this.lowerBoundMock.Object, this.upperBoundMock.Object);
            Assert.True(actual);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ImplicitlyCapturedClosure", Justification = "Simple labmdas for testing.")]
        public void IsBetween_WhenLowerBoundIsGreaterThanUpper_ShouldThrowException()
        {
            this.actualMock.Setup(x => x.CompareTo(this.lowerBoundMock.Object)).Returns(IsEqual);
            this.actualMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsSmaller);
            this.lowerBoundMock.Setup(x => x.CompareTo(this.upperBoundMock.Object)).Returns(IsBigger);

            Assert.Throws<ArgumentException>(() => this.actualMock.Object.IsBetween(this.lowerBoundMock.Object, this.upperBoundMock.Object));
        }
    }
}

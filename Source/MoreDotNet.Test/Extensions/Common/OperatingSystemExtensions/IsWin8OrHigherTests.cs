namespace MoreDotNet.Tests.Extensions.Common.OperatingSystemExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class IsWin8OrHigherTests
    {
        [Fact]
        public void IsWin8OrHigher_VersionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OperatingSystem(PlatformID.Win32NT, null));
        }

        [Theory]
        [InlineData(-10, 5)]
        [InlineData(10, -5)]
        public void IsWin8OrHigher_IncorrectWin8Setup_ThrowsArugmentOutOfRange(int major, int minor)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Version(major, minor));
        }

        [Fact]
        public void IsWin8OrHigher_OperatingSystemIsNull_ShouldThrowArgumentNullException()
        {
            OperatingSystem operatingSystem = null;

            Assert.Throws<ArgumentNullException>(() => operatingSystem.IsWin8OrHigher());
        }

        [Theory]
        [InlineData(6, 2, PlatformID.Win32NT)]
        [InlineData(16, 11, PlatformID.Win32NT)]
        public void IsWin8OrHigher_CorrectWin8Setup_ShouldReturnTrue(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.True(operatingSystem.IsWin8OrHigher());
        }

        [Theory]
        [InlineData(5, 2, PlatformID.Win32NT)]
        [InlineData(6, 1, PlatformID.Win32NT)]
        [InlineData(6, 2, PlatformID.Win32S)]
        public void IsWin8OrHigher_IncorrectWin8Setup_ShouldReturnFalse(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.False(operatingSystem.IsWin8OrHigher());
        }
    }
}

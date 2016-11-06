namespace MoreDotNet.Tests.Extensions.Common.OperatingSystemExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class IsWin7OrHigherTests
    {
        [Fact]
        public void IsWin7OrHigher_OperatingSystemIsNull_ShouldThrowArgumentNullException()
        {
            OperatingSystem operatingSystem = null;

            Assert.Throws<ArgumentNullException>(() => operatingSystem.IsWin7OrHigher());
        }

        [Theory]
        [InlineData(6, 1, PlatformID.Win32NT)]
        [InlineData(16, 11, PlatformID.Win32NT)]
        public void IsWin7OrHigher_CorrectWin7Setup_ShouldReturnTrue(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.True(operatingSystem.IsWin7OrHigher());
        }

        [Theory]
        [InlineData(5, 1, PlatformID.Win32NT)]
        [InlineData(6, 0, PlatformID.Win32NT)]
        [InlineData(6, 1, PlatformID.Win32S)]
        public void IsWin7OrHigher_IncorrectWin7Setup_ShouldReturnFalse(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.False(operatingSystem.IsWin7OrHigher());
        }
    }
}

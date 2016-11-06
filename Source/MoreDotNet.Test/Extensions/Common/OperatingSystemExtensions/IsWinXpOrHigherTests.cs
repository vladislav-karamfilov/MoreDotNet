namespace MoreDotNet.Tests.Extensions.Common.OperatingSystemExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class IsWinXpOrHigherTests
    {
        [Fact]
        public void IsWinXpOrHigher_OperatingSystemIsNull_ShouldThrowArgumentNullException()
        {
            OperatingSystem operatingSystem = null;

            Assert.Throws<ArgumentNullException>(() => operatingSystem.IsWinXpOrHigher());
        }

        [Theory]
        [InlineData(5, 1, PlatformID.Win32NT)]
        [InlineData(5, 2, PlatformID.Win32NT)]
        [InlineData(6, 0, PlatformID.Win32NT)]
        [InlineData(10, 0, PlatformID.Win32NT)]
        public void IsWinXpOrHigher_CorrectWinXpSetup_ShouldReturnTrue(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.True(operatingSystem.IsWinXpOrHigher());
        }

        [Theory]
        [InlineData(5, 0, PlatformID.Win32NT)]
        [InlineData(4, 9, PlatformID.Win32NT)]
        [InlineData(3, 1, PlatformID.Win32NT)]
        public void IsWinXpOrHigher_IncorrectWinXpSetup_ShouldReturnFalse(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.False(operatingSystem.IsWinXpOrHigher());
        }
    }
}

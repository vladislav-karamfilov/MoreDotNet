namespace MoreDotNet.Tests.Extensions.Common.OperatingSystemExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class IsWinVistaOrHigherTests
    {
        [Fact]
        public void IsWinVistaOrHigher_OperatingSystemIsNull_ShouldThrowArgumentNullException()
        {
            OperatingSystem operatingSystem = null;

            Assert.Throws<ArgumentNullException>(() => operatingSystem.IsWinVistaOrHigher());
        }

        [Theory]
        [InlineData(6, 0, PlatformID.Win32NT)]
        [InlineData(6, 1, PlatformID.Win32NT)]
        [InlineData(10, 0, PlatformID.Win32NT)]
        public void IsWinVistaOrHigher_CorrectWinVistaSetup_ShouldReturnTrue(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.True(operatingSystem.IsWinVistaOrHigher());
        }

        [Theory]
        [InlineData(5, 2, PlatformID.Win32NT)]
        [InlineData(4, 0, PlatformID.Win32NT)]
        [InlineData(3, 5, PlatformID.Win32NT)]
        public void IsWinVistaOrHigher_IncorrectWinVistaSetup_ShouldReturnFalse(int major, int minor, PlatformID platformId)
        {
            var version = new Version(major, minor);
            var operatingSystem = new OperatingSystem(platformId, version);

            Assert.False(operatingSystem.IsWinVistaOrHigher());
        }
    }
}

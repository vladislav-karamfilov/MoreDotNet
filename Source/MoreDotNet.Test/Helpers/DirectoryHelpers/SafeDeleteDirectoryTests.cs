namespace MoreDotNet.Tests.Helpers.DirectoryHelpers
{
    using System.IO;

    using MoreDotNet.Helpers;

    using Xunit;

    public class SafeDeleteDirectoryTests
    {
        [Fact]
        public void SafeDeleteDirectory_ShouldSafeDeleteExistingDirectory()
        {
            var path = DirectoryHelpers.CreateTempDirectory();
            Assert.True(Directory.Exists(path));
            DirectoryHelpers.SafeDeleteDirectory(path);
            Assert.False(Directory.Exists(path));
        }

        [Fact]
        public void SafeDeleteDirectory_ShouldNotThrowOnNonExistingDirectory()
        {
            var path = DirectoryHelpers.CreateTempDirectory();
            var nonExistingPath = $"{path}000";
            Assert.False(Directory.Exists(nonExistingPath));
            DirectoryHelpers.SafeDeleteDirectory(nonExistingPath);
        }
    }
}

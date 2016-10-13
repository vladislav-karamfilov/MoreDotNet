namespace MoreDotNet.Tests.Helpers.DirectoryHelpers
{
    using System.IO;
    using MoreDotNet.Helpers;
    using Xunit;

    // TODO: Improve test by mocking the Directory object
    public class DirectoryHelpersTests
    {
        [Fact]
        public void CreateTempDirectory_ShouldCreateTempDirectory()
        {
            var path = DirectoryHelpers.CreateTempDirectory();
            Assert.True(Directory.Exists(path));
        }
    }
}

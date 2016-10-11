namespace MoreDotNet.Tests.Helpers.DirectoryHelpers
{
    using System.IO;
    using MoreDotNet.Helpers;
    using Xunit;

    public class DirectoryHelpersTests
    {
        [Fact]
        public void CreateTempDirectory_ShouldCreateTempDirectory()
        {
            string path = DirectoryHelpers.CreateTempDirectory();
            Assert.True(Directory.Exists(path));
        }
    }
}

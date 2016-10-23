namespace MoreDotNet.Tests.Helpers.DirectoryHelpers
{
    using System.IO;
    using System.IO.Abstractions.TestingHelpers;

    using MoreDotNet.Helpers;

    using Smocks;
    using Smocks.Matching;

    using Xunit;

    public class CreateTempDirectoryTests
    {
        [Fact]
        public void CreateTempDirectory_ShouldCreateTempDirectory()
        {
            Smock.Run(context =>
            {
                // Arrange
                var fileSystem = new MockFileSystem();
                context
                    .Setup(() => Directory.Exists(It.IsAny<string>()))
                    .Returns<string>(dirPath => fileSystem.Directory.Exists(dirPath));
                context
                    .Setup(() => Directory.CreateDirectory(It.IsAny<string>()))
                    .Callback<string>(dirPath => fileSystem.Directory.CreateDirectory(dirPath));

                // Act
                var path = DirectoryHelpers.CreateTempDirectory();

                // Assert
                Assert.NotNull(path);
                Assert.True(fileSystem.Directory.Exists(path));
            });
        }
    }
}

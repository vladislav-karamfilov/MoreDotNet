namespace MoreDotNet.Tests.Helpers.DirectoryHelpers
{
    using System.IO;

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
                var directoryCreated = false;
                context.Setup(() => Directory.Exists(It.IsAny<string>())).Returns(false);
                context.Setup(() => Directory.CreateDirectory(It.IsAny<string>())).Callback((string filePath) =>
                {
                    directoryCreated = true;
                });

                // Act
                var path = DirectoryHelpers.CreateTempDirectory();

                // Assert
                Assert.True(directoryCreated);
                Assert.NotNull(path);
                Assert.StartsWith(Path.GetTempPath(), path);
            });
        }
    }
}

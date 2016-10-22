namespace MoreDotNet.Tests.Helpers.DirectoryHelpers
{
    using System;
    using System.IO;
    using System.IO.Abstractions.TestingHelpers;
    using System.IO.Fakes;

    using Microsoft.QualityTools.Testing.Fakes;

    using MoreDotNet.Helpers;

    using Xunit;

    public class CreateTempDirectoryTests : IDisposable
    {
        private readonly MockFileSystem fileSystem;
        private readonly IDisposable shimsContext;

        public CreateTempDirectoryTests()
        {
            this.fileSystem = new MockFileSystem();
            this.shimsContext = ShimsContext.Create();
            this.PrepareFileSystemShims();
        }

        [Fact]
        public void CreateTempDirectory_ShouldCreateTempDirectory()
        {
            var path = DirectoryHelpers.CreateTempDirectory();
            Assert.True(Directory.Exists(path));
        }

        public void Dispose()
        {
            this.shimsContext.Dispose();
        }

        private void PrepareFileSystemShims()
        {
            ShimDirectory.ExistsString = dirPath => this.fileSystem.Directory.Exists(dirPath);
            ShimDirectory.CreateDirectoryString = dirPath =>
            {
                this.fileSystem.AddDirectory(dirPath);
                return new DirectoryInfo(dirPath);
            };
        }
    }
}

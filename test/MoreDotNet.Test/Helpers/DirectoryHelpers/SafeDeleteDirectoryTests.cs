namespace MoreDotNet.Test.Helpers.DirectoryHelpers
{
    using System.IO;
    using System.IO.Abstractions;
    using System.IO.Abstractions.TestingHelpers;
    using System.Linq;

    using MoreDotNet.Helpers;

    using Smocks;
    using Smocks.Matching;

    using Xunit;

    public class SafeDeleteDirectoryTests
    {
        [Fact]
        public void SafeDeleteDirectory_NonRecursive_ShouldSafeDeleteExistingEmptyDirectory()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\test";
                const bool Recursive = false;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);

                var directoriesCountBeforeDelete = fileSystem.AllDirectories.Count();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
                Assert.Equal(directoriesCountBeforeDelete - 1, fileSystem.AllDirectories.Count());
            });
        }

        [Fact]
        public void SafeDeleteDirectory_Recursive_ShouldSafeDeleteExistingEmptyDirectory()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\test";
                const bool Recursive = true;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);

                var directoriesCountBeforeDelete = fileSystem.AllDirectories.Count();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
                Assert.Equal(directoriesCountBeforeDelete - 1, fileSystem.AllDirectories.Count());
            });
        }

        [Fact]
        public void SafeDeleteDirectory_NonRecursive_ShouldThrowOnExistingNonEmptyDirectoryWithFilesOnly()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\existing-dir";
                const bool Recursive = false;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);
                fileSystem.AddFile(Path.Combine(DirPath, "text-file.txt"), new MockFileData("Text content"));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "binary-file.txt"),
                    new MockFileData(new byte[] { 0x22, 0x51, 0x32, 0x00 }));

                var filesCountBeforeDelete = fileSystem.AllFiles.Count();

                SetupFileSystemMocks(context, fileSystem);

                // Act and Assert (cannot Assert.Throws() because it doesn't work with Smocks)
                try
                {
                    DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);
                }
                catch (IOException)
                {
                    Assert.True(fileSystem.Directory.Exists(DirPath));
                    Assert.Equal(filesCountBeforeDelete, fileSystem.AllFiles.Count());
                }
            });
        }

        [Fact]
        public void SafeDeleteDirectory_Recursive_ShouldSafeDeleteExistingNonEmptyDirectoryWithFilesOnly()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\existing-dir";
                const bool Recursive = true;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);
                fileSystem.AddFile(Path.Combine(DirPath, "text-file.txt"), new MockFileData("Text content"));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "binary-file.txt"),
                    new MockFileData(new byte[] { 0x22, 0x51, 0x32, 0x00 }));

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
                Assert.False(fileSystem.AllFiles.Any());
            });
        }

        [Fact]
        public void SafeDeleteDirectory_NonRecursive_ShouldThrowOnExistingNonEmptyDirectoryWithSubDirectoriesOnly()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\existing-dir";
                const bool Recursive = false;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-1"));
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-2"));

                var directoriesCountBeforeDelete = fileSystem.AllDirectories.Count();

                SetupFileSystemMocks(context, fileSystem);

                // Act and Assert (cannot Assert.Throws() because it doesn't work with Smocks)
                try
                {
                    DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);
                }
                catch (IOException)
                {
                    Assert.True(fileSystem.Directory.Exists(DirPath));
                    Assert.Equal(directoriesCountBeforeDelete, fileSystem.AllDirectories.Count());
                }
            });
        }

        [Fact]
        public void SafeDeleteDirectory_Recursive_ShouldSafeDeleteExistingNonEmptyDirectoryWithSubDirectoriesOnly()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\existing-dir";
                const bool Recursive = true;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-1"));
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-2"));

                var directoriesCountBeforeDelete = fileSystem.AllDirectories.Count();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
                Assert.Equal(directoriesCountBeforeDelete - 3, fileSystem.AllDirectories.Count());
            });
        }

        [Fact]
        public void SafeDeleteDirectory_NonRecursive_ShouldThrowOnExistingNonEmptyDirectoryWithSubDirectoriesAndFiles()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\existing-dir";
                const bool Recursive = false;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-1"));
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-2"));
                fileSystem.AddFile(Path.Combine(DirPath, "text-file-1.txt"), new MockFileData("Text content"));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "binary-file-1.txt"),
                    new MockFileData(new byte[] { 0x22, 0x51, 0x32, 0x00 }));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "sub-directory-1", "text-file-2.txt"),
                    new MockFileData("Text content"));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "sub-directory-2", "binary-file-2.txt"),
                    new MockFileData(new byte[] { 0x22, 0x51, 0x32, 0x00 }));

                SetupFileSystemMocks(context, fileSystem);

                // Act and Assert (cannot Assert.Throws() because it doesn't work with Smocks)
                try
                {
                    DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);
                }
                catch (IOException)
                {
                    Assert.True(fileSystem.Directory.Exists(DirPath));
                }
            });
        }

        [Fact]
        public void SafeDeleteDirectory_Recursive_ShouldSafeDeleteExistingNonEmptyDirectoryWithSubDirectoriesAndFiles()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\existing-dir";
                const bool Recursive = true;

                var fileSystem = new MockFileSystem();
                fileSystem.AddDirectory(DirPath);
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-1"));
                fileSystem.AddDirectory(Path.Combine(DirPath, "sub-directory-2"));
                fileSystem.AddFile(Path.Combine(DirPath, "text-file-1.txt"), new MockFileData("Text content"));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "binary-file-1.txt"),
                    new MockFileData(new byte[] { 0x22, 0x51, 0x32, 0x00 }));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "sub-directory-1", "text-file-2.txt"),
                    new MockFileData("Text content"));
                fileSystem.AddFile(
                    Path.Combine(DirPath, "sub-directory-2", "binary-file-2.txt"),
                    new MockFileData(new byte[] { 0x22, 0x51, 0x32, 0x00 }));

                var directoriesCountBeforeDelete = fileSystem.AllDirectories.Count();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
                Assert.Equal(directoriesCountBeforeDelete - 3, fileSystem.AllDirectories.Count());
                Assert.Equal(0, fileSystem.AllFiles.Count());
            });
        }

        [Fact]
        public void SafeDeleteDirectory_NonRecursive_ShouldNotThrowOnNonExistingDirectory()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\non-existing-dir";
                const bool Recursive = false;

                var fileSystem = new MockFileSystem();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
            });
        }

        [Fact]
        public void SafeDeleteDirectory_Recursive_ShouldNotThrowOnNonExistingDirectory()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = @"C:\non-existing-dir";
                const bool Recursive = true;

                var fileSystem = new MockFileSystem();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
            });
        }

        [Fact]
        public void SafeDeleteDirectory_NonRecursive_ShouldNotThrowOnNullDirectory()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = null;
                const bool Recursive = false;

                var fileSystem = new MockFileSystem();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
            });
        }

        [Fact]
        public void SafeDeleteDirectory_Recursive_ShouldNotThrowOnNullDirectory()
        {
            Smock.Run(context =>
            {
                // Arrange
                const string DirPath = null;
                const bool Recursive = true;

                var fileSystem = new MockFileSystem();

                SetupFileSystemMocks(context, fileSystem);

                // Act
                DirectoryHelpers.SafeDeleteDirectory(DirPath, recursive: Recursive);

                // Assert
                Assert.False(fileSystem.Directory.Exists(DirPath));
            });
        }

        private static void SetupFileSystemMocks(ISmocksContext context, IFileSystem fileSystem)
        {
            context
                .Setup(() => Directory.Exists(It.IsAny<string>()))
                .Returns<string>(dirPath => fileSystem.Directory.Exists(dirPath));
            context
                .Setup(() => Directory.EnumerateFileSystemEntries(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<SearchOption>()))
                .Returns<string, string, SearchOption>((dirPath, searchPattern, searchOption) =>
                    fileSystem.Directory.EnumerateFileSystemEntries(dirPath, searchPattern, searchOption));
            context
                .Setup(() => File.SetAttributes(It.IsAny<string>(), It.IsAny<FileAttributes>()))
                .Callback<string, FileAttributes>((path, attributes) =>
                    fileSystem.File.SetAttributes(path, attributes));
            context
                .Setup(() => Directory.Delete(It.IsAny<string>(), It.IsAny<bool>()))
                .Callback<string, bool>((dirPath, recursive) => fileSystem.Directory.Delete(dirPath, recursive));
        }
    }
}

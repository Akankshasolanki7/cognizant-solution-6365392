using NUnit.Framework;
using Moq;
using MagicFilesLib;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _mockDirectoryExplorer;
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [SetUp]
        public void Setup()
        {
            _mockDirectoryExplorer = new Mock<IDirectoryExplorer>();
        }

        [TestCase]
        public void GetFiles_ShouldReturnMockedFiles_WhenPathIsProvided()
        {
            // Arrange
            var expectedFiles = new List<string> { _file1, _file2 };
            _mockDirectoryExplorer.Setup(x => x.GetFiles(It.IsAny<string>()))
                                  .Returns(expectedFiles);

            // Act
            var result = _mockDirectoryExplorer.Object.GetFiles("C:\\TestPath");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(_file1));
            Assert.IsTrue(result.Contains(_file2));
        }

        [TestCase]
        public void GetFiles_ShouldReturnCollectionWithCorrectCount_WhenMocked()
        {
            // Arrange
            var expectedFiles = new List<string> { _file1, _file2 };
            _mockDirectoryExplorer.Setup(x => x.GetFiles(It.IsAny<string>()))
                                  .Returns(expectedFiles);

            // Act
            var result = _mockDirectoryExplorer.Object.GetFiles("C:\\TestPath");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestCase]
        public void GetFiles_ShouldContainSpecificFile_WhenMocked()
        {
            // Arrange
            var expectedFiles = new List<string> { _file1, _file2 };
            _mockDirectoryExplorer.Setup(x => x.GetFiles(It.IsAny<string>()))
                                  .Returns(expectedFiles);

            // Act
            var result = _mockDirectoryExplorer.Object.GetFiles("C:\\TestPath");

            // Assert
            Assert.IsTrue(result.Contains(_file1));
            _mockDirectoryExplorer.Verify(x => x.GetFiles(It.IsAny<string>()), Times.Once);
        }
    }
}

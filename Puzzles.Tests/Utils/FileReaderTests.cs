using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using Xunit;

namespace Puzzles.Tests
{
    public class FileReaderTests
    {
        //Not sure if should test this kind of complexity
        [Theory]
        [InlineData("test1", FileExtensionEnum.TXT, "test1.txt")]
        [InlineData("test2", FileExtensionEnum.CSV, "test2.csv")]
        public void Should_AddExtensionToFileName(string fileName, FileExtensionEnum extension, string expected)
        {
            var fileNameWithExt = FileReader.AddExtensionToFileName(fileName, extension);
            Assert.Equal(fileNameWithExt, expected);
        }
        [Theory]
        [InlineData("Puzzles/Inputs", "_InputTest.txt", "Puzzles/Inputs/_InputTest.txt")]
        public void Should_GetPathToFile(string relativePath, string fileName, string expected)
        {
            var fileNameWithExt = FileReader.GetFullPath(relativePath, fileName);
            Assert.Equal(fileNameWithExt, expected);
        }
    }
}
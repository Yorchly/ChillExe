using NUnit.Framework;
using System;
using System.IO;

namespace ChillExe.Tests
{
    public class LoggerTest
    {
        private static readonly string testFileFullPath =
            Path.Join(AppContext.BaseDirectory, "test_logger.txt");

        [SetUp]
        public void SetUp()
        {
            Logger.Instance.FilenameFullPath = testFileFullPath;
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFileFullPath))
                File.Delete(testFileFullPath);
        }

        [Test]
        public void WriteLine_LineNotEmptyAndLogLevelIsDefault_ResultIsSavedInFile()
        {
            string testLine = "This is a test line";

            Logger.Instance.WriteLine(testLine);

            CheckIfContentFromFileIsCorrect(testLine, LogLevel.INFO);
        }

        [Test]
        public void WriteLine_LineNotEmptyAndLogLevelIsError_ResultIsSavedInFile()
        {
            string testLine = "This is a test line";
            var logLevel = LogLevel.ERROR;

            Logger.Instance.WriteLine(testLine, logLevel);

            CheckIfContentFromFileIsCorrect(testLine, logLevel);
        }

        [Test]
        public void WriteLine_LineNotEmptyAndLogLevelIsWarning_ResultIsSavedInFile()
        {
            string testLine = "This is a test line";
            var logLevel = LogLevel.WARNING;

            Logger.Instance.WriteLine(testLine, logLevel);

            CheckIfContentFromFileIsCorrect(testLine, logLevel);
        }

        private void CheckIfContentFromFileIsCorrect(string testLine, LogLevel logLevel)
        {
            using var streamReader = new StreamReader(testFileFullPath);
            string fileText = streamReader.ReadLine();

            Assert.IsTrue(fileText.Contains(testLine));
            Assert.IsTrue(fileText.Contains(logLevel.ToString()));
            Assert.IsTrue(fileText.Contains(DateTime.Now.ToString("dd/MM/yyyy HH:mm")));
        }

        [Test]
        public void WriteLine_LineIsEmptyAndLogLevelIsDefault_NoneIsSavedInFile()
        {
            string testLine = "";
            FileStream fileStream = File.Create(testFileFullPath);
            fileStream.Close();

            Logger.Instance.WriteLine(testLine);

            CheckIfFileHasNoContent();
        }

        [Test]
        public void WriteLine_LineIsNullAndLogLevelIsDefault_NoneIsSavedInFile()
        {
            string testLine = null;
            CreateTestFile();

            Logger.Instance.WriteLine(testLine);

            CheckIfFileHasNoContent();
        }

        private void CheckIfFileHasNoContent()
        {
            using var streamReader = new StreamReader(testFileFullPath);
            string fileText = streamReader.ReadLine();

            Assert.IsNull(fileText);
        }

        [Test]
        public void FlushLogFile_FilenameFullPathExists_ReturnsTrue()
        {
            CreateTestFile();

            bool result = Logger.Instance.FlushLogFile();

            Assert.IsTrue(result);
        }

        private void CreateTestFile()
        {
            FileStream fileStream = File.Create(testFileFullPath);
            fileStream.Close();
        }

        [Test]
        public void FlushLogFile_FilenameFullPathDoesNotExists_ReturnsFalse()
        {
            Logger.Instance.FilenameFullPath = "test_directory/test_file.txt";

            bool result = Logger.Instance.FlushLogFile();

            Assert.IsFalse(result);
        }

        [Test]
        public void WriteLine_FilenameFullPathIsEmpty_ThrowsArgumentException()
        {
            Logger.Instance.FilenameFullPath = "";

            Assert.Throws<ArgumentException>(() => Logger.Instance.WriteLine("Test line"));
        }

        [Test]
        public void WriteLine_FilenameIsInDirectoryThatDoesNotExists_ThrowsArgumentException()
        {
            Logger.Instance.FilenameFullPath = "test-directory/test_logger.txt";

            Assert.Throws<DirectoryNotFoundException>(() => Logger.Instance.WriteLine("Test line"));
        }
    }
}

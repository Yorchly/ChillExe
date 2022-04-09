using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChillExe.Tests.Services
{
    public class AppXmlServiceTest
    {
        private static readonly string testFilenameFullPath =
            Path.Combine(AppContext.BaseDirectory, "test_app.xml");
        private static readonly string testCopyFilenameFullPath =
            Path.Combine(AppContext.BaseDirectory, "test_copy_app.xml");
        private readonly Mock<ICustomLogger> customLogger = new Mock<ICustomLogger>();
        private AppXmlService xmlService;

        [SetUp]
        public void Setup()
        {
            xmlService = new AppXmlService(customLogger.Object);
            xmlService.FilenameFullPath =
                testFilenameFullPath;
            customLogger.Setup(x => x.WriteLine(It.IsAny<string>(), LogLevel.ERROR));
        }

        [TearDown]
        public void ClearXmls()
        {
            if (File.Exists(testCopyFilenameFullPath))
                File.Delete(testCopyFilenameFullPath);

            if (File.Exists(testFilenameFullPath))
                File.Delete(testFilenameFullPath);
        }

        [Test]
        public void Get_XmlIsEmpty_ReturnsDefault()
        {
            Apps apps = xmlService.Get();

            Assert.AreEqual(default, apps);
        }

        private List<App> GetAppList() => 
            xmlService.Get()?.AppList;

        [Test]
        public void Get_XmlIsInvalid_ReturnsEmptyList()
        {
            WriteInvalidXml();

            List<App> apps = GetAppList();

            Assert.AreEqual(default, apps);
        }

        private void WriteInvalidXml() =>
            WriteTextInXml(@"<not-valid-tag>Not valid text</not-valid-tag>", testFilenameFullPath);

        private void WriteTextInXml(string text, string filenameFullPath)
        {
            var writer = new StreamWriter(filenameFullPath);
            try
            {
                writer.WriteLine(text);
            }
            finally
            {
                writer.Close();
            }
        }

        [Test]
        public void Get_XmlIsValid_ReturnsListOfApps()
        {
            WriteValidXml();

            List<App> apps = GetAppList();

            Assert.AreEqual(apps.Count, 2);
            Assert.AreEqual(apps[0].Url, @"https://test.com");
            Assert.AreEqual(apps[0].Filename, "Test filename");
            Assert.AreEqual(apps[0].LastUpdate, @"08/03/2022 18:43:00");
            Assert.AreEqual(apps[1].Url, @"https://test2.com");
            Assert.AreEqual(apps[1].Filename, "Test filename 2");
            Assert.AreEqual(apps[1].LastUpdate, @"08/03/2022 19:43:00");
        }

        private void WriteValidXml()
        {
            string xmlValidText =
                @"<Apps>" +
                @"<App><Url>https://test.com</Url><LastUpdate>08/03/2022 18:43:00</LastUpdate><Filename>Test filename</Filename></App>" +
                @"<App><Url>https://test2.com</Url><LastUpdate>08/03/2022 19:43:00</LastUpdate><Filename>Test filename 2</Filename></App>" +
                @"</Apps>";

            WriteTextInXml(xmlValidText, testFilenameFullPath);
        }

        [Test]
        public void Get_FilenameInDirectoryThatDoesNotExists_ThrowsException()
        {
            xmlService.FilenameFullPath = "/fail_test_path/test.xml";

            Assert.Throws<DirectoryNotFoundException>(() => GetAppList());
        }

        [Test]
        public void Get_XsdFilenameInDirectoryThatDoesNotExists_ThrowsException()
        {
            xmlService.FilenameFullPath = "/fail_test_path/test.xsd";

            Assert.Throws<DirectoryNotFoundException>(() => GetAppList());
        }

        [Test]
        public void FilenameFullPathIsEmpty_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => xmlService.FilenameFullPath = "");

        [Test]
        public void Get_XsdFilenameFullPathIsEmpty_ReturnsNull()
        {
            xmlService.XsdFilenameFullPath = "";

            Apps result = xmlService.Get();

            Assert.AreEqual(default, result);
        }

        [Test]
        public void Save_EmptyList_ReturnsFalse()
        {
            var apps = new List<App>();

            bool isSaved = xmlService.Save(new Apps() { AppList = apps });

            Assert.IsFalse(isSaved);
        }

        [Test]
        public void Save_ElementInListIsNotValid_ReturnsFalse()
        {
            var apps = new List<App> { new App() };

            bool isSaved = xmlService.Save(new Apps() { AppList = apps });

            Assert.IsFalse(isSaved);
        }

        [Test]
        public void Save_FilenameInDirectoryThatDoesNotExists_ThrowsException()
        {
            xmlService.FilenameFullPath = "/fail_test_path/test.xml";
            var apps = GetValidAppList();

            Assert.Throws<DirectoryNotFoundException>(() => xmlService.Save(new Apps() { AppList = apps }));
        }


        [Test]
        public void Save_ListAppIsValid_ReturnsTrue()
        {
            List<App> apps = GetValidAppList();

            bool isSaved = xmlService.Save(new Apps() { AppList = apps });

            Assert.IsTrue(isSaved);
        }

        private List<App> GetValidAppList()
        {
            var apps = new List<App>();

            for (int i = 0; i < 3; i++)
                apps.Add(
                    new App
                    {
                        Filename = $"Test name {i}",
                        Url = $"https://test.url.com/{i}",
                        LastUpdate = $"09/03/2022 20:31:0{i}"
                    }
                );

            return apps;
        }
    }
}
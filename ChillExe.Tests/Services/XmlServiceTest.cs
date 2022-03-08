using ChillExe.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ChillExe.Tests
{
    public class XmlServiceTest
    {
        private static readonly string testFilenameFullPath = 
            Path.Combine(AppContext.BaseDirectory, "test_app.xml");
        private static readonly string testCopyFilenameFullPath =
            Path.Combine(AppContext.BaseDirectory, "test_copy_app.xml");

        [SetUp]
        public void Setup()
        {
            AppXmlService.Instance.FilenameFullPath =
                testFilenameFullPath;
            AppXmlService.Instance.FilenameCopyFullPath =
                testCopyFilenameFullPath;
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
        public void Get_XmlIsEmpty_ReturnsEmptyList()
        {
            List<App> apps = AppXmlService.Instance.Get();

            Assert.AreEqual(default, apps);
        }

        [Test]
        public void Get_XmlIsInvalid_ReturnsEmptyList()
        {
            WriteInvalidXml();

            List<App> apps = AppXmlService.Instance.Get();

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

            List<App> apps = AppXmlService.Instance.Get();

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
                @"<App><Url>https://test.com</Url><LastUpdate>08/03/2022 18:43:00</LastUpdate><Filename>Test filename</Filename></App>"+
                @"<App><Url>https://test2.com</Url><LastUpdate>08/03/2022 19:43:00</LastUpdate><Filename>Test filename 2</Filename></App>" +
                @"</Apps>";

            WriteTextInXml(xmlValidText, testFilenameFullPath);
        }
    }
}
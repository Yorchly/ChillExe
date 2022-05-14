using ChillExe.Helpers;
using ChillExe.Logger;
using ChillExe.Models.Xml;
using ChillExe.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Tests.Helpers
{
    public class TestXmlFile : IXmlFile
    {
        public string FilenameFullPath { get; } =
            Path.Combine(AppContext.BaseDirectory, "test.xml");

        public string XsdFilenameFullPath { get; } =
            Path.Combine(AppContext.BaseDirectory, "test.xsd");
    }

    public class TestXmlFileWrongFilenames : IXmlFile
    {
        public string FilenameFullPath { get; } =
            Path.Combine(AppContext.BaseDirectory, "wrong.xml");

        public string XsdFilenameFullPath { get; } =
            Path.Combine(AppContext.BaseDirectory, "wrong.xsd");
    }

    public class TestXmlFileNullFilenames : IXmlFile
    {
        public string FilenameFullPath { get; } = null;

        public string XsdFilenameFullPath { get; } = null;
    }

    public class TestXmlFileEmptyFilenames : IXmlFile
    {
        public string FilenameFullPath { get; } = "";

        public string XsdFilenameFullPath { get; } = "";
    }

    public class Test
    {
        public int TestInt { get; set; }
        public string TestString { get; set; }
    }

    public class XmlHelperTest
    {
        private readonly Mock<ICustomLogger> loggerMock =
            new Mock<ICustomLogger>();
        private readonly Mock<IXmlUtils> xmlUtilsMock =
            new Mock<IXmlUtils>();
        private TestXmlFile testXmlFile;
        private TestXmlFileNullFilenames testXmlFileNull;
        private TestXmlFileWrongFilenames testXmlFileWrong;
        private TestXmlFileEmptyFilenames testXmlFileEmpty;
        private XmlHelper<Test> xmlHelper;

        public XmlHelperTest()
        {
            loggerMock.Setup(
                logger => logger.WriteLine(It.IsAny<string>(), It.IsAny<LogLevel>())
            );
        }

        [SetUp]
        public void SetUp()
        {
            testXmlFile = new TestXmlFile();
            testXmlFileNull = new TestXmlFileNullFilenames();
            testXmlFileWrong = new TestXmlFileWrongFilenames();
            testXmlFileEmpty = new TestXmlFileEmptyFilenames();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testXmlFile.FilenameFullPath))
                File.Delete(testXmlFile.FilenameFullPath);

            if (File.Exists(testXmlFile.XsdFilenameFullPath))
                File.Delete(testXmlFile.XsdFilenameFullPath);
        }   

        [Test]
        public void XsdFilenameDoesntExists_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFileWrong, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void XsdFilenameIsNull_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFileNull, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void XsdFilenameIsEmpty_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFileEmpty, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void Get_XmlIsNotValid_ReturnsDefault()
        {
            SetXsdContentInFile();
            xmlUtilsMock.Setup(
                xmlUtils => xmlUtils.IsXmlValid(It.IsAny<string>(), It.IsAny<string>())
            ).Returns(false);
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFile, xmlUtilsMock.Object);

            Test test = xmlHelper.Get();

            Assert.AreEqual(default, test);
        }

        private void SetXsdContentInFile()
        {
            string xsdContent = @"<xs:schema xmlns:xs='http://www.w3.org/2001/XMLSchema'>" +
                @"<xs:element name='Test'>" +
                @"<xs:complexType>" +
                @"<xs:sequence>" +
                @"<xs:element name='TestInt' type='xs:int' minOccurs='1' maxOccurs='1'/>" +
                @"<xs:element name='TestString' type='xs:string' minOccurs='1' maxOccurs='1'/>" +
                @"</xs:sequence>" +
                @"</xs:complexType>" +
                @"</xs:element>" +
                @"</xs:schema>";

            using var writer = new StreamWriter(testXmlFile.XsdFilenameFullPath);

            writer.WriteLine(xsdContent);
        }

        [Test]
        public void Get_XmlIsValid_ReturnsTestInstance()
        {
            SetXsdContentInFile();
            SetXmlContentInFile();
            xmlUtilsMock.Setup(
                xmlUtils => xmlUtils.IsXmlValid(It.IsAny<string>(), It.IsAny<string>())
            ).Returns(true);
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFile, xmlUtilsMock.Object);

            Test test = xmlHelper.Get();

            Assert.IsNotNull(test);
            Assert.AreEqual(test.TestString, "Test");
            Assert.AreEqual(test.TestInt, 1);
        }

        private void SetXmlContentInFile()
        {
            string xmlContent = @"<?xml version='1.0' encoding='utf-8' ?>" + 
                "<Test>" + 
                "<TestInt>1</TestInt>" + 
                "<TestString>Test</TestString>" +
                "</Test>";

            using var writer = new StreamWriter(testXmlFile.FilenameFullPath);

            writer.WriteLine(xmlContent);
        }

        [Test]
        public void Save_TestInstanceIsValid_ReturnsTrue()
        {
            SetXsdContentInFile();
            xmlUtilsMock.Setup(
                xmlUtils => xmlUtils.IsXmlValid(It.IsAny<string>(), It.IsAny<string>())
            ).Returns(true);
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFile, xmlUtilsMock.Object);
            Test test = new Test() { TestInt = 1, TestString = "Test" };

            bool response = xmlHelper.Write(test);

            Assert.IsTrue(response);
        }

        [Test]
        public void Save_TestInstanceIsNull_ReturnsFalse()
        {
            SetXsdContentInFile();
            xmlUtilsMock.Setup(
                xmlUtils => xmlUtils.IsXmlValid(It.IsAny<string>(), It.IsAny<string>())
            ).Returns(false);
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFile, xmlUtilsMock.Object);
            Test test = null;

            bool response = xmlHelper.Write(test);

            Assert.IsFalse(response);
        }
    }
}

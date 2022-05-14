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
    public class TestXmlFilePath : IXmlFile
    {
        public string FilenameFullPath { get; set; } =
            Path.Combine(AppContext.BaseDirectory, "test.xml");

        public string XsdFilenameFullPath { get; set; } =
            Path.Combine(AppContext.BaseDirectory, "test.xsd");
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
        private IXmlFile testXmlFilePath;
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
            testXmlFilePath = new TestXmlFilePath();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testXmlFilePath.FilenameFullPath))
                File.Delete(testXmlFilePath.FilenameFullPath);

            if (File.Exists(testXmlFilePath.XsdFilenameFullPath))
                File.Delete(testXmlFilePath.XsdFilenameFullPath);
        }   

        [Test]
        public void XsdFilenameDoesntExists_ThrowsFileNotFoundException()
        {
            testXmlFilePath.XsdFilenameFullPath =
                Path.Combine(AppContext.BaseDirectory, "wrong.xsd");

            Assert.Throws<FileNotFoundException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void XsdFilenameIsNull_ThrowsArgumentException()
        {
            testXmlFilePath.XsdFilenameFullPath = null;

            Assert.Throws<ArgumentException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void XsdFilenameIsEmpty_ThrowsArgumentException()
        {
            testXmlFilePath.XsdFilenameFullPath = "";

            Assert.Throws<ArgumentException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void XmlFilenameIsEmpty_ThrowsArgumentException()
        {
            testXmlFilePath.FilenameFullPath = "";

            Assert.Throws<ArgumentException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void XmlFilenameIsNull_ThrowsArgumentException()
        {
            testXmlFilePath.FilenameFullPath = null;

            Assert.Throws<ArgumentException>(
                () => xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object)
            );
        }

        [Test]
        public void Get_XmlIsNotValid_ReturnsDefault()
        {
            SetXsdContentInFile();
            xmlUtilsMock.Setup(
                xmlUtils => xmlUtils.IsXmlValid(It.IsAny<string>(), It.IsAny<string>())
            ).Returns(false);
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object);

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

            using var writer = new StreamWriter(testXmlFilePath.XsdFilenameFullPath);

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
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object);

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

            using var writer = new StreamWriter(testXmlFilePath.FilenameFullPath);

            writer.WriteLine(xmlContent);
        }

        [Test]
        public void Save_TestInstanceIsValid_ReturnsTrue()
        {
            SetXsdContentInFile();
            xmlUtilsMock.Setup(
                xmlUtils => xmlUtils.IsXmlValid(It.IsAny<string>(), It.IsAny<string>())
            ).Returns(true);
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object);
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
            xmlHelper = new XmlHelper<Test>(loggerMock.Object, testXmlFilePath, xmlUtilsMock.Object);
            Test test = null;

            bool response = xmlHelper.Write(test);

            Assert.IsFalse(response);
        }
    }
}

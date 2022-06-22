using ChillExe.Factory;
using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Models.Xml;
using Moq;
using NUnit.Framework;
using System;

namespace ChillExe.Tests.Helpers
{
    public class XmlFileHelperTest
    {
        private Mock<IXmlFileFactory> xmlFileFactoryMock;
        private XmlFileHelper xmlFileHelper;

        [SetUp]
        public void SetUp()
        {
            xmlFileFactoryMock = new Mock<IXmlFileFactory>();
            xmlFileHelper = new XmlFileHelper(xmlFileFactoryMock.Object);
        }

        [Test]
        public void GetXmlFilePath_XmlFileTypeIsApp_ReturnsAppXmlFileFullPath() =>
            CheckFilenameFullPathByXmlFileType(XmlFileType.App);

        private void CheckFilenameFullPathByXmlFileType(XmlFileType xmlFileType)
        {
            IXmlFile xmlFile = GetXmlFileByXmlFileType(xmlFileType);
            SetUpXmlFileFactoryMock(xmlFileType, xmlFile);

            string result = xmlFileHelper.GetXmlFilePath(xmlFileType);
            Assert.AreEqual(xmlFile.FilenameFullPath, result);
        }

        private static IXmlFile GetXmlFileByXmlFileType(XmlFileType xmlFileType) => 
            xmlFileType switch
            {
                XmlFileType.App => new AppXmlFile(),
                XmlFileType.Configuration => new ConfigurationXmlFile(),
                XmlFileType.Localization => new LocalizationXmlFile(Language.Spanish),
                _ => throw new NotImplementedException()
            };

        private void SetUpXmlFileFactoryMock(XmlFileType xmlFileType, IXmlFile xmlFile) =>
            xmlFileFactoryMock.Setup(
                xmlFileFactory => xmlFileFactory.Create(xmlFileType)
            ).Returns(xmlFile);

        [Test]
        public void GetXmlFilePath_XmlFileTypeIsConfiguration_ReturnsConfigurationXmlFileFullPath() =>
            CheckFilenameFullPathByXmlFileType(XmlFileType.Configuration);

        [Test]
        public void GetXmlFilePath_XmlFileTypeIsLocalization_ReturnsLocalizationXmlFileFullPath() =>
            CheckFilenameFullPathByXmlFileType(XmlFileType.Localization);

        [Test]
        public void GetXsdFilePath_XmlFileTypeIsApp_ReturnsAppXmlFileXsdPath() =>
            CheckXsdFilenameFullPathByXmlFileType(XmlFileType.App);

        private void CheckXsdFilenameFullPathByXmlFileType(XmlFileType xmlFileType)
        {
            IXmlFile xmlFile = GetXmlFileByXmlFileType(xmlFileType);
            SetUpXmlFileFactoryMock(xmlFileType, xmlFile);

            string result = xmlFileHelper.GetXsdFilePath(xmlFileType);
            Assert.AreEqual(xmlFile.XsdFilenameFullPath, result);
        }

        [Test]
        public void GetXsdFilePath_XmlFileTypeIsConfiguration_ReturnsConfigurationXmlFileXsdPath() =>
            CheckXsdFilenameFullPathByXmlFileType(XmlFileType.Configuration);

        [Test]
        public void GetXsdFilePath_XmlFileTypeIsLocalization_ReturnsLocalizationXmlFileXsdPath() =>
            CheckXsdFilenameFullPathByXmlFileType(XmlFileType.App);
    }
}

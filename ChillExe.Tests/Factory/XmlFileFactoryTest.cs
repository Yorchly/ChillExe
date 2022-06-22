using ChillExe.Factory;
using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Models.Xml;
using Moq;
using NUnit.Framework;

namespace ChillExe.Tests.Factory
{
    public class XmlFileFactoryTest
    {
        Mock<IConfigurationHelper> configHelperMock =
            new Mock<IConfigurationHelper>();
        XmlFileFactory xmlFileFactory;

        [SetUp]
        public void SetUp() =>
            xmlFileFactory = new XmlFileFactory(configHelperMock.Object);

        [Test]
        public void Create_XmlFileTypeIsApp_ReturnsAppXmlFileInstance()
        {
            var appXmlFile = new AppXmlFile();

            IXmlFile result = xmlFileFactory.Create(XmlFileType.App);

            CheckFilenameAndXsd(appXmlFile, result);
        }

        private void CheckFilenameAndXsd(IXmlFile expectedXmlFile, IXmlFile actualXmlFile)
        {
            Assert.AreEqual(expectedXmlFile.FilenameFullPath, actualXmlFile.FilenameFullPath);
            Assert.AreEqual(expectedXmlFile.XsdFilenameFullPath, actualXmlFile.XsdFilenameFullPath);
        }

        [Test]
        public void Create_XmlFileTypeIsConfiguration_ReturnsConfigurationXmlFileInstance()
        {
            var configurationXmlFile = new ConfigurationXmlFile();

            IXmlFile result = xmlFileFactory.Create(XmlFileType.Configuration);

            CheckFilenameAndXsd(configurationXmlFile, result);
        }

        [Test]
        public void Create_XmlFileTypeIsLocalization_ReturnsLocalizationXmlFileInstance()
        {
            var currentLanguage = Language.Spanish;
            var localizationXmlFile = new LocalizationXmlFile(currentLanguage);
            configHelperMock.Setup(
                configHelper => configHelper.GetCurrentLanguage()
            ).Returns(currentLanguage);

            IXmlFile result = xmlFileFactory.Create(XmlFileType.Localization);

            CheckFilenameAndXsd(localizationXmlFile, result);
        }
    }
}

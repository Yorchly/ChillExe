using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Services.Xml;
using Moq;
using NUnit.Framework;

namespace ChillExe.Tests.Services.Xml
{
    public class ConfigurationServiceTest
    {
        private readonly Mock<IXmlHelper<Configuration>> xmlHelperMock =
            new Mock<IXmlHelper<Configuration>>();
        private ConfigurationService configurationService;

        [Test]
        public void Get_XmlHelperGetCorrectInformation_ReturnsConfigurationInstance()
        {
            Configuration configuration = GetCorrectConfiguration();
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Get()
            ).Returns(configuration);
            configurationService = new ConfigurationService(xmlHelperMock.Object);

            Configuration resultConfiguration = configurationService.Get();

            Assert.IsNotNull(resultConfiguration);
            Assert.AreEqual(configuration, resultConfiguration);
        }

        public Configuration GetCorrectConfiguration()
        {
            return new Configuration
            {
                Language = Language.Spanish,
                IsLanguageMessageBoxShown = true,
            };
        }

        [Test]
        public void Get_XmlHelperGetIncorrectInformation_ReturnsNull()
        {
            Configuration configuration = null;
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Get()
            ).Returns(configuration);
            configurationService = new ConfigurationService(xmlHelperMock.Object);

            Configuration resultConfiguration = configurationService.Get();

            Assert.IsNull(resultConfiguration);
        }

        [Test]
        public void Save_ConfigurationInstanceIsNull_ReturnsFalse()
        {
            Configuration configuration = null;
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Write(configuration)
            ).Returns(false);
            configurationService = new ConfigurationService(xmlHelperMock.Object);

            bool response = configurationService.Save(configuration);

            Assert.IsFalse(response);
        }

        [Test]
        public void Save_ConfigurationInstanceIsCorrect_ReturnsFalse()
        {
            Configuration configuration = GetCorrectConfiguration();
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Write(configuration)
            ).Returns(true);
            configurationService = new ConfigurationService(xmlHelperMock.Object);

            bool response = configurationService.Save(configuration);

            Assert.IsTrue(response);
        }
    }
}

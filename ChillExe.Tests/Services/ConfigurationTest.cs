using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services.Xml;
using Moq;
using NUnit.Framework;
using System;
using System.IO;

namespace ChillExe.Tests.Services
{
    public class ConfigurationTest
    {
        private Mock<ICustomLogger> loggerMock =
            new Mock<ICustomLogger>();
        private ConfigurationService configService;
        private static readonly string testFilenameFullPath =
            Path.Join(AppContext.BaseDirectory, "test-configuration.xml");

        [SetUp]
        public void SetUp()
        {
            configService = new ConfigurationService(loggerMock.Object);
            configService.FilenameFullPath = testFilenameFullPath;
            loggerMock.Setup(
                logger => logger.WriteLine(It.IsAny<string>(), It.IsAny<LogLevel>())
            );
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFilenameFullPath))
                File.Delete(testFilenameFullPath);
        }
        
        [Test]
        public void Get_XmlIsValidAndLanguageIsSpanish_ReturnsConfigurationInstanceWithSpanishLanguage()
        {
            SetValidXmlContentConfiguration((int)Language.Spanish);

            Configuration config = configService.Get();

            Assert.IsNotNull(config);
            Assert.AreEqual(config.Language, Language.Spanish);
        }

        private void SetValidXmlContentConfiguration(int lang)
        {
            string xmlContent = $"<Configuration><Language>{lang}</Language></Configuration>";
            using var streamWriter = new StreamWriter(testFilenameFullPath);

            streamWriter.WriteLine(xmlContent);
        }

        [Test]
        public void Get_XmlIsValidAndLanguageNotExists_ReturnsNull()
        {
            SetValidXmlContentConfiguration(1000);

            Configuration config = configService.Get();

            Assert.IsNull(config);
        }

        [Test]
        public void Get_XmlIsNotValid_ReturnsNull()
        {
            SetInvalidXml();

            Configuration config = configService.Get();

            Assert.IsNull(config);
        }

        private void SetInvalidXml()
        {
            string xmlContent = $"";
            using var streamWriter = new StreamWriter(testFilenameFullPath);

            streamWriter.WriteLine(xmlContent);
        }

        [Test]
        public void Save_ConfigurationIsValid_ReturnsTrue()
        {
            Configuration config = GetValidConfiguration();
            config.Language = Language.English;

            bool response = configService.Save(config);
            config = configService.Get();

            Assert.IsTrue(response);
            Assert.IsNotNull(config);
            Assert.AreEqual(config.Language, Language.English);
        }

        private Configuration GetValidConfiguration()
        {
            SetValidXmlContentConfiguration(0);

            return configService.Get();
        }

        [Test]
        public void Save_ConfigurationIsNull_ReturnsFalse()
        {
            Configuration config = null;

            bool response = configService.Save(config);

            Assert.IsFalse(response);
        }
    }
}

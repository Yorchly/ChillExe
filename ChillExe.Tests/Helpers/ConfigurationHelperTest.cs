using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System;

namespace ChillExe.Tests.Helpers
{
    public class ConfigurationHelperTest
    {
        private readonly Mock<IService<Configuration>> configurationServiceMock =
            new Mock<IService<Configuration>>();
        ConfigurationHelper configurationHelper;
        Configuration configuration;

        [SetUp]
        public void SetUp()
        {
            configurationHelper = new ConfigurationHelper(configurationServiceMock.Object);
        }

        [Test]
        public void GetConfiguration_ServiceObtainsCorrectConfiguration_ReturnsConfiguration()
        {
            configuration = new Configuration
            {
                Language = Language.Spanish,
                IsLanguageMessageBoxShown = true
            };
            configurationServiceMock.Setup(
                appService => appService.Get()
            ).Returns(configuration);

            Configuration resultConfiguration = configurationHelper.GetConfiguration();

            Assert.NotNull(resultConfiguration);
            Assert.AreEqual(configuration, resultConfiguration);
        }

        [Test]
        public void GetConfiguration_ServiceGetNullConfiguration_ReturnsNull()
        {
            configuration = null;
            configurationServiceMock.Setup(
                appService => appService.Get()
            ).Returns(configuration);

            Configuration resultConfiguration = configurationHelper.GetConfiguration();

            Assert.IsNull(resultConfiguration);
        }

        [Test]
        public void SaveConfiguration_ConfigurationAreSavedCorrectly_ReturnsTrue()
        {
            configuration = new Configuration
            {
                Language = Language.Spanish,
                IsLanguageMessageBoxShown = true
            };
            configurationServiceMock.Setup(
                appService => appService.Save(It.IsAny<Configuration>())
            ).Returns(true);

            bool result = configurationHelper.SaveConfiguration(configuration);

            Assert.IsTrue(result);
        }

        [Test]
        public void SaveConfiguration_ConfigurationAreNotSavedCorrectly_ReturnsFalse()
        {
            configuration = null;
            configurationServiceMock.Setup(
                appService => appService.Save(It.IsAny<Configuration>())
            ).Returns(false);

            bool result = configurationHelper.SaveConfiguration(null);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetCurrentLanguage_ConfigIsObtainedFromServiceCorrectly_ReturnsCurrentLanguage()
        {
            configuration = new Configuration
            {
                Language = Language.Spanish,
                IsLanguageMessageBoxShown = true
            };
            configurationServiceMock.Setup(
                appService => appService.Get()
            ).Returns(configuration);

            Language resultLanguage = configurationHelper.GetCurrentLanguage();

            Assert.AreEqual(Language.Spanish, resultLanguage);
        }

        [Test]
        public void GetCurrentLanguage_ConfigObtainedFromServiceIsNull_ThrowsNullReferenceException()
        {
            configuration = null;
            configurationServiceMock.Setup(
                appService => appService.Get()
            ).Returns(configuration);
            Language resultLanguage;

            Assert.Throws<NullReferenceException>(
                () => resultLanguage = configurationHelper.GetCurrentLanguage()
            );
        }
    }
}

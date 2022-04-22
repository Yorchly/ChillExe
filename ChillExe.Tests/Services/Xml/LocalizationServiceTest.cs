using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using ChillExe.Services.Xml;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChillExe.Tests.Services.Xml
{
    public class LocalizationServiceTest
    {
        private readonly string localizationFilenameFullPath = 
            Path.Combine(AppContext.BaseDirectory, "localization_test.xml");
        private readonly Mock<ICustomLogger> loggerMock =
            new Mock<ICustomLogger>();
        private readonly Mock<IService<Configuration>> configMock =
            new Mock<IService<Configuration>>();
        private LocalizationService localizationService;

        public LocalizationServiceTest()
        {
            loggerMock.Setup(
                logger => logger.WriteLine(It.IsAny<string>(), It.IsAny<LogLevel>())
            );

            Configuration config = new Configuration { Language = Language.Spanish };
            configMock.Setup(
                config => config.Get()
            ).Returns(config);
        }

        [SetUp]
        public void SetUp()
        {
            localizationService = new LocalizationService(loggerMock.Object, configMock.Object);
            localizationService.FilenameFullPath = localizationFilenameFullPath;
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(localizationFilenameFullPath))
                File.Delete(localizationFilenameFullPath);
        }

        [Test]
        public void Get_XmlIsValid_ReturnsListWithTranslations()
        {
            var translations = new List<Translation>
            {
                new Translation { Id = "IdTest1", Value = "Esto es una cadena de prueba 1"},
                new Translation { Id = "IdTest2", Value = "Esto es una cadena de prueba 2"},
            };
            SetXmlWithValidContent(translations);

            Translations translationsFromService = localizationService.Get();

            Assert.IsNotNull(translationsFromService);
            Assert.AreEqual(translationsFromService.TranslationList.Count, 2);
            Assert.AreEqual(translations[0].Id, translationsFromService.TranslationList[0].Id);
            Assert.AreEqual(translations[0].Value, translationsFromService.TranslationList[0].Value);
            Assert.AreEqual(translations[1].Id, translationsFromService.TranslationList[1].Id);
            Assert.AreEqual(translations[1].Value, translationsFromService.TranslationList[1].Value);
        }

        private void SetXmlWithValidContent(List<Translation> translations)
        {
            var stringBuilder = new StringBuilder("<Translations>");

            foreach(Translation translation in translations)
                stringBuilder.Append(
                    $"<Translation><Id>{translation.Id}</Id><Value>{translation.Value}</Value></Translation>"
                );
            stringBuilder.Append("</Translations>");

            WriteContentInXml(stringBuilder.ToString(), localizationFilenameFullPath);
        }

        private void WriteContentInXml(string content, string xmlFilenameFullPath)
        {
            using var streamWriter = new StreamWriter(xmlFilenameFullPath);
            streamWriter.WriteLine(content);
        }

        [Test]
        public void Get_XmlIsNotValid_ReturnsNull()
        {
            SetXmlWithInvalidContent();

            Translations translationsFromService = localizationService.Get();

            Assert.IsNull(translationsFromService);
        }

        private void SetXmlWithInvalidContent() =>
            WriteContentInXml("", localizationFilenameFullPath);

        [Test]
        public void Save_TranslationsIsValid_ReturnsTrue()
        {
            var translations = new Translations
            {
                TranslationList = new List<Translation>()
                {
                    new Translation { Id = "TestId1", Value = "Esto es una cadena de prueba"}
                }
            };

            bool response = localizationService.Save(translations);

            Assert.IsTrue(response);
        }

        [Test]
        public void Save_TranslationIsNotValid_ReturnsFalse()
        {
            Translations translations = null;

            bool response = localizationService.Save(translations);

            Assert.IsFalse(response);
        }
    }
}

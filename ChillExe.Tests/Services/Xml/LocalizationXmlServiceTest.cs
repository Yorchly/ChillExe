using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Services.Xml;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ChillExe.Tests.Services.Xml
{
    public class LocalizationServiceTest
    {
        private readonly Mock<IXmlHelper<Translations>> xmlHelperMock =
            new Mock<IXmlHelper<Translations>>();
        private LocalizationService localizationService;

        [Test]
        public void Get_XmlHelperGetCorrectInformation_ReturnsTranslationsInstance()
        {
            Translations translations = GetCorrectTranslations();
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Get()
            ).Returns(translations);
            localizationService = new LocalizationService(xmlHelperMock.Object);

            Translations resultTranslations = localizationService.Get();

            Assert.IsNotNull(resultTranslations);
            Assert.Greater(resultTranslations.TranslationList.Count, 0);
            Assert.AreEqual(translations.TranslationList[0], resultTranslations.TranslationList[0]);
            Assert.AreEqual(translations.TranslationList[1], resultTranslations.TranslationList[1]);
        }

        public Translations GetCorrectTranslations()
        {
            return new Translations
            {
                TranslationList = new List<Translation>
                {
                    new Translation { Id = "testId1", Value = "This is a test string" },
                    new Translation { Id = "testId2", Value = "This is a test string 2" }
                }
            };
        }

        [Test]
        public void Get_XmlHelperGetIncorrectInformation_ReturnsNull()
        {
            Translations translations = null;
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Get()
            ).Returns(translations);
            localizationService = new LocalizationService(xmlHelperMock.Object);

            Translations resultTranslations = localizationService.Get();

            Assert.IsNull(resultTranslations);
        }

        [Test]
        public void Save_TranslationsInstanceIsNull_ReturnsFalse()
        {
            Translations translations = null;
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Write(translations)
            ).Returns(false);
            localizationService = new LocalizationService(xmlHelperMock.Object);

            bool response = localizationService.Save(translations);

            Assert.IsFalse(response);
        }

        [Test]
        public void Save_TranslationsInstanceIsCorrect_ReturnsFalse()
        {
            Translations translations = GetCorrectTranslations();
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Write(translations)
            ).Returns(true);
            localizationService = new LocalizationService(xmlHelperMock.Object);

            bool response = localizationService.Save(translations);

            Assert.IsTrue(response);
        }
    }
}

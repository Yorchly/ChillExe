using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ChillExe.Tests.Helpers
{
    public class LocalizationHelperTest
    {
        private readonly Mock<IService<Translations>> localizationServiceMock =
            new Mock<IService<Translations>>();
        LocalizationHelper localizationHelper;
        Translations translations;

        [SetUp]
        public void SetUp()
        {
            localizationHelper = new LocalizationHelper(localizationServiceMock.Object);
        }

        [Test]
        public void GetTranslations_ServiceObtainsCorrectTranslations_ReturnsCorrectListOfTranslations()
        {
            translations = new Translations
            {
                TranslationList = GetTranslations(3)
            };
            localizationServiceMock.Setup(
                appService => appService.Get()
            ).Returns(translations);

            List<Translation> resultTranslations = localizationHelper.GetTranslations();

            Assert.NotNull(resultTranslations);
            Assert.Greater(resultTranslations.Count, 0);
            Assert.AreEqual(resultTranslations[0], translations.TranslationList[0]);
            Assert.AreEqual(resultTranslations[1], translations.TranslationList[1]);
            Assert.AreEqual(resultTranslations[2], translations.TranslationList[2]);
        }

        private List<Translation> GetTranslations(int count)
        {
            var translations = new List<Translation>();

            for (int i = 0; i < count; i++)
            {
                translations.Add(
                    new Translation
                    {
                        Id = $"Id{i}",
                        Value = $"Translation test {i}"
                    }
                );
            }

            return translations;
        }

        [Test]
        public void GetTranslations_ServiceGetNullTranslations_ReturnsNull()
        {
            translations = null;
            localizationServiceMock.Setup(
                appService => appService.Get()
            ).Returns(translations);

            List<Translation> resultTranslations = localizationHelper.GetTranslations();

            Assert.IsNull(resultTranslations);
        }
    }
}

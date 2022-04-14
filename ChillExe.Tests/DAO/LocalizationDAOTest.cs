using ChillExe.DAO;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.Tests.DAO
{
    class LocalizationDAOTest
    {
        private readonly Mock<IService<Translations>> localizationServiceMockup =
            new Mock<IService<Translations>>();
        private LocalizationDAO dao;
        private Translations testTranslations;

        [SetUp]
        public void SetUp()
        {
            testTranslations = new Translations
            {
                TranslationList = new List<Translation>
                {
                    new Translation {
                        Id = "TranslationTest1", Value = "This is a test translation 1"
                    },
                    new Translation {
                        Id = "TranslationTest2", Value = "This is a test translation 2"
                    }
                }
            };
            localizationServiceMockup.Setup(
                appServiceMock => appServiceMock.Get()
            ).Returns(testTranslations);

            dao = new LocalizationDAO(localizationServiceMockup.Object);
        }

        [Test]
        public void Get_ReturnsListOfApps()
        {
            List<Translation> translations = dao.Get();

            Assert.Greater(translations.Count, 0);
        }

        [Test]
        public void Save_ReturnsTrue()
        {
            localizationServiceMockup.Setup(
                xmlService => xmlService.Save(It.IsAny<Translations>())
            ).Returns(true);

            bool response = dao.Save();

            Assert.IsTrue(response);
        }
    }
}

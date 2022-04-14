using ChillExe.DAO;
using ChillExe.Localization;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChillExe.Tests.Localization
{
    public class StringLocalizerTest
    {
        private readonly Mock<ILocalizationDAO> localizationDAO =
            new Mock<ILocalizationDAO>();
        private List<Translation> translations;
        private IStringLocalizer stringLocalizer;

        [SetUp]
        public void SetUp()
        {
            translations = new List<Translation>
            {
                new Translation { Id = "testTranslationId1", Value = "This is a test string 1"},
                new Translation { Id = "testTranslationId2", Value = "This is a test string 2"}
            };

            localizationDAO.Setup(
                localization => localization.Get()
            ).Returns(translations);
            stringLocalizer = new StringLocalizer(localizationDAO.Object);
        }

        [Test]
        public void GetTranslation_CorrectId_ReturnsTranslationValue()
        {
            string translation = stringLocalizer.GetTranslation("testTranslationId1");

            Assert.AreEqual(translations[0].Value, translation);
        }

        [Test]
        public void GetTranslation_WrongId_ReturnsDefaultValue()
        {
            string defaultValue = "This is a test default value";

            string translation = stringLocalizer.GetTranslation("WrongId1", defaultValue);

            Assert.AreEqual(defaultValue, translation);
        }
    }
}

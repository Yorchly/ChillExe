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
                new Translation { Id = "testTranslationId2", Value = "This is a test string 2"},
                new Translation { Id = "testTranslationId3", Value = "This is a test string with arguments {0} and {1}" }
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
        public void GetTranslationWithArgs_CorrectIdAndArgs_ReturnsTranslationValue()
        {
            string translation = stringLocalizer.GetTranslation("testTranslationId3", "Default message", "argument 1", "argument 2");

            Assert.NotNull(translation);
            Assert.AreEqual(string.Format(translations[2].Value, "argument 1", "argument 2"), translation);
        }

        [Test]
        public void GetTranslation_WrongId_ReturnsDefaultValue()
        {
            string defaultValue = "This is a test default value";

            string translation = stringLocalizer.GetTranslation("WrongId1", defaultValue);

            Assert.AreEqual(defaultValue, translation);
        }

        [Test]
        public void GetTranslationWithArgs_CorrectIdButNullArgs_ThrowsNullReferenceException()
        {
            string translation;

            Assert.Throws<System.ArgumentNullException>(
                () => translation = stringLocalizer.GetTranslation("testTranslationId3", "Default message", null)
            );
        }

        [Test]
        public void GetTranslationWithArgs_WrongIdButCorrectArgs_ReturnsDefaultValue()
        {
            string defaultTranslation = "This is a default translation with arguments {0} and {1}";

            string translation = 
                stringLocalizer.GetTranslation("wrongId", defaultTranslation, "argument 1", "argument 2");

            Assert.AreEqual(string.Format(defaultTranslation, "argument 1", "argument 2"), translation);
        }

        [Test]
        public void GetTranslationWithArgs_WrongIdButCorrectArgsAndDefaultTranslationDoesNotAdmitArgs_ReturnsDefaultValueWithoutArgs()
        {
            string defaultTranslation = "This is a default translation";

            string translation =
                stringLocalizer.GetTranslation("wrongId", defaultTranslation, "argument 1", "argument 2");

            Assert.AreEqual(defaultTranslation, translation);
        }
    }
}

using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ChillExe.Localization
{
    public class StringLocalizer : IStringLocalizer
    {
        private readonly IService<Translations> localizationService;
        private Dictionary<string, string> translations;

        public StringLocalizer(IService<Translations> localizationService)
        {
            this.localizationService = localizationService;
            TransformListOfTranslationsIntoDictionary();
        }

        private void TransformListOfTranslationsIntoDictionary()
        {
            List<Translation> translationsList = GetTranslationsList();

            translations = translationsList.ToDictionary(
                translation => translation.Id, translation => translation.Value
            );
        }

        private List<Translation> GetTranslationsList()
        {
            Translations translations = localizationService.Get();

            return translations.TranslationList;
        }

        public string GetTranslation(string id, string defaultValue = "") =>
            translations.ContainsKey(id) ? translations[id] : defaultValue;
    }
}

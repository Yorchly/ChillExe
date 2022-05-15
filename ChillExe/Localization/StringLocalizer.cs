using ChillExe.Helpers;
using ChillExe.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChillExe.Localization
{
    public class StringLocalizer : IStringLocalizer
    {
        private Dictionary<string, string> translations;

        public StringLocalizer(ILocalizationHelper localizationHelper) =>
            TransformListOfTranslationsIntoDictionary(localizationHelper.GetTranslations());

        private void TransformListOfTranslationsIntoDictionary(List<Translation> translationList) =>
            translations = translationList.ToDictionary(
                translation => translation.Id, translation => translation.Value
            );

        public string GetTranslation(string id, string defaultValue = "") =>
            translations.ContainsKey(id) ? translations[id] : defaultValue;

        public string GetTranslation(string id, string defaultValue = "", params string[] args) =>
            translations.ContainsKey(id) ? string.Format(translations[id], args) : string.Format(defaultValue, args);
    }
}

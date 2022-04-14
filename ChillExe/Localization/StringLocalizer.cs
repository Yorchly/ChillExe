using ChillExe.DAO;
using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ChillExe.Localization
{
    public class StringLocalizer : IStringLocalizer
    {
        private readonly ILocalizationDAO localizationDAO;
        private Dictionary<string, string> translations;

        public StringLocalizer(ILocalizationDAO localizationDAO)
        {
            this.localizationDAO = localizationDAO;
            TransformListOfTranslationsIntoDictionary();
        }

        private void TransformListOfTranslationsIntoDictionary()
        {
            List<Translation> translationsList = localizationDAO.Get();

            translations = translationsList.ToDictionary(
                translation => translation.Id, translation => translation.Value
            );
        }

        public string GetTranslation(string id, string defaultValue = "") =>
            translations.ContainsKey(id) ? translations[id] : defaultValue;
    }
}

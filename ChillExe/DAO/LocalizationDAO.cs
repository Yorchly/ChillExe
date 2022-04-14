using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public class LocalizationDAO : ILocalizationDAO
    {
        private readonly List<Translation> translations;
        private readonly IService<Translations> localizationService;

        public LocalizationDAO(IService<Translations> localizationService)
        {
            this.localizationService = localizationService;
            translations = this.localizationService.Get().TranslationList;
        }

        public List<Translation> Get() => translations;
        public bool Save() => localizationService.Save(new Translations() { TranslationList = translations });
    }
}

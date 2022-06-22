using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Helpers
{
    public class LocalizationHelper : ILocalizationHelper
    {
        private readonly IService<Translations> localizationService;

        public LocalizationHelper(IService<Translations> localizationService) =>
            this.localizationService = localizationService;

        public List<Translation> GetTranslations() =>
            localizationService.Get()?.TranslationList;
    }
}

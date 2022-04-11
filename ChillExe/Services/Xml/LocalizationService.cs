using ChillExe.Logger;
using ChillExe.Models;
using System;
using System.IO;

namespace ChillExe.Services.Xml
{
    public class LocalizationService: CommonXmlService<Translations>
    {
        private readonly string xsdFilenameFullPath =
            Path.Join(AppContext.BaseDirectory, "Localization\\Xml\\translations.xsd");
        private readonly IService<Configuration> config;

        public LocalizationService(ICustomLogger customLogger, IService<Configuration> config) : base(customLogger)
        {
            this.config = config;

            FilenameFullPath = GetTranslationsFilenameFullPathByLanguage();
            XsdFilenameFullPath = xsdFilenameFullPath;
        }

        private string GetTranslationsFilenameFullPathByLanguage()
        {
            Language language = config.Get().Language;

            return Path.Join(
                AppContext.BaseDirectory, 
                $"Localization\\Xml\\translations_{language.ToString().ToLower()}.xml"
            );
        }
    }
}

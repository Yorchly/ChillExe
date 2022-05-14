using ChillExe.DAO;
using System;
using System.IO;

namespace ChillExe.Models.Xml
{
    public class LocalizationXmlFile : IXmlFile
    {
        public string FilenameFullPath { get; set; }

        public string XsdFilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "Localization\\Xml\\translations.xsd");

        private IConfigurationDAO configurationDAO;

        public LocalizationXmlFile(IConfigurationDAO configurationDAO)
        {
            this.configurationDAO = configurationDAO;
            FilenameFullPath = GetTranslationsFilenameFullPathByLanguage();
        }

        private string GetTranslationsFilenameFullPathByLanguage()
        {
            Language language = configurationDAO.Configuration.Language;

            return Path.Join(
                AppContext.BaseDirectory,
                $"Localization\\Xml\\translations_{language.ToString().ToLower()}.xml"
            );
        }
    }
}

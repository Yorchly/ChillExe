using System;
using System.IO;

namespace ChillExe.Models.Xml
{
    public class LocalizationXmlFile : IXmlFile
    {
        public string FilenameFullPath { get; private set; }

        public string XsdFilenameFullPath { get; } =
            Path.Join(AppContext.BaseDirectory, "Localization\\Xml\\translations.xsd");

        public LocalizationXmlFile(Language language) =>
            FilenameFullPath = GetTranslationsFilenameFullPathByLanguage(language);

        private static string GetTranslationsFilenameFullPathByLanguage(Language language) =>
            Path.Join(
                AppContext.BaseDirectory,
                $"Localization\\Xml\\translations_{language.ToString().ToLower()}.xml"
            );
    }
}

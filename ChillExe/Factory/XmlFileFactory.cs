using ChillExe.DAO;
using ChillExe.Helpers;
using ChillExe.Models.Xml;
using System;

namespace ChillExe.Factory
{
    public class XmlFileFactory : IXmlFileFactory
    {
        private readonly IConfigurationHelper configHelper;

        public XmlFileFactory(IConfigurationHelper configHelper) =>
            this.configHelper = configHelper;

        public IXmlFile Create(XmlFileType xmlFileType) => xmlFileType switch
        {
            XmlFileType.App => new AppXmlFile(),
            XmlFileType.Configuration => new ConfigurationXmlFile(),
            XmlFileType.Localization => new LocalizationXmlFile(configHelper.GetCurrentLanguage()),
            _ => throw new NotImplementedException()
        };
    }
}

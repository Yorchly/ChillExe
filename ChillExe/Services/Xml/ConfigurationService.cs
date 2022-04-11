using ChillExe.Logger;
using ChillExe.Models;
using System;
using System.IO;

namespace ChillExe.Services.Xml
{
    public class ConfigurationService : CommonXmlService<Configuration>
    {
        private readonly string filenameFullPath =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xml");
        private readonly string xsdFilenameFullPath =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xsd");

        public ConfigurationService(ICustomLogger customLogger) : base(customLogger)
        {
            FilenameFullPath = filenameFullPath;
            XsdFilenameFullPath = xsdFilenameFullPath;
        }
    }
}

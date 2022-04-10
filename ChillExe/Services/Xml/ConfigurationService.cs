using ChillExe.Logger;
using ChillExe.Models;
using System;
using System.IO;

namespace ChillExe.Services.Xml
{
    public class ConfigurationService : CommonXmlService<Configuration>
    {
        private string filenameFullPath =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xml");
        private string xsdFilenameFullPath =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xsd");

        public string FilenameFullPath
        {
            get => filenameFullPath;
            set
            {
                filenameFullPath = value;
                SetXmlAndXsdFilenamePath(filenameFullPath, xsdFilenameFullPath);
            }
        }

        public string XsdFilenameFullPath
        {
            get => xsdFilenameFullPath;
            set
            {
                xsdFilenameFullPath = value;
                SetXmlAndXsdFilenamePath(filenameFullPath, xsdFilenameFullPath);
            }
        }

        public ConfigurationService(ICustomLogger customLogger) : base(customLogger) =>
            SetXmlAndXsdFilenamePath(FilenameFullPath, XsdFilenameFullPath);
    }
}

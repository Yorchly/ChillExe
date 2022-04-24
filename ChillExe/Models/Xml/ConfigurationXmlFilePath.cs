using System;
using System.IO;

namespace ChillExe.Models.Xml
{
    public class ConfigurationXmlFilePath : IXmlFilePath
    {
        public string FilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xml");

        public string XsdFilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xsd");
    }
}

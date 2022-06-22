using System;
using System.IO;

namespace ChillExe.Models.Xml
{
    public class ConfigurationXmlFile : IXmlFile
    {
        public string FilenameFullPath { get; } =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xml");

        public string XsdFilenameFullPath { get; } =
            Path.Join(AppContext.BaseDirectory, "Configuration\\Xml\\configuration.xsd");
    }
}

using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Models.Xml;
using System.Collections.Generic;
using System.Linq;

namespace ChillExe.Services.Xml
{
    public class ConfigurationService : CommonXmlService<Configuration>
    {
        public ConfigurationService(ICustomLogger customLogger, List<IXmlFilePath> xmlFilePaths) : 
            base(customLogger, xmlFilePaths.OfType<ConfigurationXmlFilePath>().First()) { }
    }
}

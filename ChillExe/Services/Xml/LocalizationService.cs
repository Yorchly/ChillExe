using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Models.Xml;
using System.Collections.Generic;
using System.Linq;

namespace ChillExe.Services.Xml
{
    public class LocalizationService: CommonXmlService<Translations>
    {

        public LocalizationService(ICustomLogger customLogger, List<IXmlFilePath> xmlFilePaths) : 
            base(customLogger, xmlFilePaths.OfType<LocalizationXmlFilePath>().First()) { }
    }
}

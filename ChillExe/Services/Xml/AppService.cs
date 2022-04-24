using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Models.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChillExe.Services.Xml
{
    public class AppService : CommonXmlService<Apps>
    {
        public AppService(ICustomLogger customLogger, List<IXmlFilePath> xmlFilePaths) : 
            base(customLogger, xmlFilePaths.OfType<AppXmlFilePath>().First()) { }
    }
}

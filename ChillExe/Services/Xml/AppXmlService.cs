using ChillExe.Logger;
using ChillExe.Models;
using System;
using System.IO;

namespace ChillExe.Services.Xml
{
    public class AppXmlService : CommonXmlService<Apps>
    {
        private readonly string filenameFullPath =
            Path.Join(AppContext.BaseDirectory, "apps.xml");
        private readonly string xsdFilenameFullPath =
            Path.Join(AppContext.BaseDirectory, "Services\\Xml\\Xsd\\app.xsd");

        public AppXmlService(ICustomLogger customLogger) : base(customLogger)
        {
            FilenameFullPath = filenameFullPath;
            XsdFilenameFullPath = xsdFilenameFullPath;
        }
    }
}

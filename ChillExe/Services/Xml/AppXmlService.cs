using ChillExe.Logger;
using ChillExe.Models;
using System;
using System.IO;

namespace ChillExe.Services.Xml
{
    public class AppXmlService : CommonXmlService<Apps>
    {
        private string filenameFullPath =
            Path.Join(AppContext.BaseDirectory, "apps.xml");
        private string xsdFilenameFullPath =
            Path.Join(AppContext.BaseDirectory, "Services\\Xml\\Xsd\\app.xsd");

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

        public AppXmlService(ICustomLogger customLogger) : base(customLogger) =>
            SetXmlAndXsdFilenamePath(FilenameFullPath, XsdFilenameFullPath);
    }
}

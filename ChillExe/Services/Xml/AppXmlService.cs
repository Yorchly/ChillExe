using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using ChillExe.Services.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChillExe.Services
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

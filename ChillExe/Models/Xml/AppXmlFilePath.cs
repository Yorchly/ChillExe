using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Models.Xml
{
    public class AppXmlFilePath : IXmlFilePath
    {
        public string FilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "apps.xml");

        public string XsdFilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "Services\\Xml\\Xsd\\app.xsd");
    }
}

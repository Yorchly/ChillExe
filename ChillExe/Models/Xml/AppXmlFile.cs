using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Models.Xml
{
    public class AppXmlFile : IXmlFile
    {
        public string FilenameFullPath { get; } =
            Path.Join(AppContext.BaseDirectory, "apps.xml");

        public string XsdFilenameFullPath { get; } =
            Path.Join(AppContext.BaseDirectory, "Services\\Xml\\Xsd\\app.xsd");
    }
}

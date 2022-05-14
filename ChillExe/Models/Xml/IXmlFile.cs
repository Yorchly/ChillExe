using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Models.Xml
{
    public interface IXmlFile
    {
        public string FilenameFullPath { get; set; }
        public string XsdFilenameFullPath { get; set; }
    }
}

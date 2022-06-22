using ChillExe.Models.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Helpers
{
    public interface IXmlFileHelper
    {
        public string GetXmlFilePath(XmlFileType xmlFileType);
        public string GetXsdFilePath(XmlFileType xmlFileType);
    }
}

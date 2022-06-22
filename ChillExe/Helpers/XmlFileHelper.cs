using ChillExe.Factory;
using ChillExe.Models.Xml;

namespace ChillExe.Helpers
{
    public class XmlFileHelper : IXmlFileHelper
    {
        private IXmlFileFactory xmlFileFactory;

        public XmlFileHelper(IXmlFileFactory xmlFileFactory) =>
            this.xmlFileFactory = xmlFileFactory;

        public string GetXmlFilePath(XmlFileType xmlFileType)
        {
            IXmlFile xmlFile = xmlFileFactory.Create(xmlFileType);

            return xmlFile.FilenameFullPath;
        }

        public string GetXsdFilePath(XmlFileType xmlFileType)
        {
            IXmlFile xmlFile = xmlFileFactory.Create(xmlFileType);

            return xmlFile.XsdFilenameFullPath;
        }
    }
}

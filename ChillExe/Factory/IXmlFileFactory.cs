using ChillExe.Models.Xml;

namespace ChillExe.Factory
{
    public interface IXmlFileFactory
    {
        public IXmlFile Create(XmlFileType xmlFileType);
    }
}

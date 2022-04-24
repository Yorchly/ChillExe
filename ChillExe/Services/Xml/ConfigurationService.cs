using ChillExe.Helpers;
using ChillExe.Models;

namespace ChillExe.Services.Xml
{
    public class ConfigurationService : CommonXmlService<Configuration>
    {
        public ConfigurationService(IXmlHelper<Configuration> configurationXmlHelper) : base(configurationXmlHelper) { }
    }
}

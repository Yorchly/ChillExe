using ChillExe.Helpers;
using ChillExe.Models;

namespace ChillExe.Services.Xml
{
    public class LocalizationService: CommonXmlService<Translations>
    {

        public LocalizationService(IXmlHelper<Translations> translationsXmlHelper) : base(translationsXmlHelper) { }
    }
}

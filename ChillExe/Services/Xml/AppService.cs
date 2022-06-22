using ChillExe.Helpers;
using ChillExe.Models;

namespace ChillExe.Services.Xml
{
    public class AppService : CommonXmlService<Apps>
    {
        public AppService(IXmlHelper<Apps> appXmlHelper) : base(appXmlHelper) { }
    }
}

using ChillExe.Services;
using System;

namespace ChillExe.DAO
{
    public class AppXmlDAO : CommonDAO
    {
        public AppXmlDAO(IAppService xmlService): base(xmlService){ }
    }
}

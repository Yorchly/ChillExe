using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;

namespace ChillExe.Helpers
{
    public class AppHelper : IAppHelper
    {
        private readonly IService<Apps> appService;

        public AppHelper(IService<Apps> appService)
        {
            this.appService = appService;
        }

        public List<App> GetApps() =>
            appService.Get().AppList;

        public bool SaveApps(List<App> apps) =>
            appService.Save(new Apps { AppList = apps });
    }
}

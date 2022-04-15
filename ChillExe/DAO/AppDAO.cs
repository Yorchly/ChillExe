using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;

namespace ChillExe.DAO
{
    public class AppDAO : IAppDAO
    {
        private List<App> apps;
        private readonly IService<Apps> appService;

        public AppDAO(IService<Apps> appService)
        {
            this.appService = appService;
            apps = this.appService.Get()?.AppList;
        }

        public List<App> Get() => apps;

        public bool Save() => appService.Save(new Apps() { AppList = apps });
    }
}

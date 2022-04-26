using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;

namespace ChillExe.DAO
{
    public class AppDAO : IAppDAO
    {
        public List<App> Apps { get; set; }

        private readonly IService<Apps> appService;

        public AppDAO(IService<Apps> appService)
        {
            this.appService = appService;
            Apps = this.appService.Get()?.AppList;
        }

        public bool Save() => appService.Save(new Apps() { AppList = Apps });

        public void Refresh() =>
            Apps = appService.Get()?.AppList;
    }
}

using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;

namespace ChillExe.DAO
{
    public class AppDAO
    {
        private List<App> apps;
        private readonly IAppService appService;

        public AppDAO(IAppService appService)
        {
            this.appService = appService;
            apps = this.appService.Get();
        }

        public List<App> Get() => apps;

        public List<App> Set(App app)
        {
            if (app != null)
                apps.Add(app);

            return apps;
        }

        public List<App> Set(List<App> apps, bool overwrite = false)
        {
            if (apps == null)
                return this.apps;

            if (overwrite)
                this.apps = apps;
            else
                this.apps.AddRange(apps);

            return this.apps;
        }

        public bool Clear() 
        {
            apps.Clear();

            return true;
        } 

        public bool Save() => appService.Save(apps);
    }
}

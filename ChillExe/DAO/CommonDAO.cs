using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;

namespace ChillExe.DAO
{
    public abstract class CommonDAO : IDAO
    {
        private List<App> apps;
        private readonly IAppService appService;

        public CommonDAO(IAppService appService)
        {
            this.appService = appService;
            apps = this.appService.Get();
        }

        public virtual List<App> Get() => apps;

        public virtual List<App> Set(App app)
        {
            if (app != null)
                apps.Add(app);

            return apps;
        }

        public virtual List<App> Set(List<App> apps, bool overwrite = false)
        {
            if (apps == null)
                return this.apps;

            if (overwrite)
                this.apps = apps;
            else
                this.apps.AddRange(apps);

            return this.apps;
        }

        public virtual bool Clear() 
        {
            apps.Clear();

            return true;
        } 

        public virtual bool Save() => appService.Save(apps);
    }
}

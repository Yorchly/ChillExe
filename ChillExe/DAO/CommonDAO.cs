using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;

namespace ChillExe.DAO
{
    public abstract class CommonDAO : IDAO
    {
        private List<App> apps;
        private IAppService appService;

        public virtual void Init(IAppService appService)
        {
            this.appService = appService;
            apps = this.appService.Get();
        }

        public virtual List<App> Get() => apps;

        public virtual void Set(App app) => apps.Add(app);

        public virtual void Set(List<App> apps, bool overwrite = false)
        {
            if (overwrite)
                this.apps = apps;
            else
                this.apps.AddRange(apps);
        }

        public virtual void Clear() => apps.Clear();

        public virtual bool Save() => appService.Save(apps);
    }
}

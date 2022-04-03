using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public interface IDAO
    {
        public void Init(IAppService appService);

        public List<App> Get();

        public void Set(App app);

        public void Set(List<App> apps, bool overwrite = false);

        public void Clear();

        public bool Save();
    }
}

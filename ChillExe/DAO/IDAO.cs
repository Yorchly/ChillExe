using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public interface IDAO
    {
        public List<App> Get();

        public List<App> Set(App app);

        public List<App> Set(List<App> apps, bool overwrite = false);

        public bool Clear();

        public bool Save();
    }
}

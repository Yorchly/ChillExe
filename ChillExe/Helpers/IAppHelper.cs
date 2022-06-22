using ChillExe.Models;
using System.Collections.Generic;

namespace ChillExe.Helpers
{
    public interface IAppHelper
    {
        public List<App> GetApps();
        public bool SaveApps(List<App> apps);
    }
}

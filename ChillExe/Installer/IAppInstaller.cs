using ChillExe.Models;
using System.Collections.Generic;

namespace ChillExe.Installer
{
    public interface IAppInstaller
    {
        /// <summary>
        /// Install all the apps in the list, using App.DownloadedPath property. 
        /// If installation is correct, App.IsInstalled property will be set to true.
        /// </summary>
        /// <param name="apps"></param>
        public void Install(List<App> apps);
    }
}

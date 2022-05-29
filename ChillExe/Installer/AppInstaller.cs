using ChillExe.Models;
using ChillExe.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace ChillExe.Installer
{
    public class AppInstaller : IAppInstaller
    {
        private readonly IProcessWrapper processWrapper;

        public AppInstaller(IProcessWrapper processWrapper) =>
            this.processWrapper = processWrapper;

        public void Install(List<App> apps)
        {
            if (apps == null)
                return;

            foreach(App app in apps.Where(app => app.IsDownloaded && !string.IsNullOrEmpty(app.DownloadedPath)))
                app.IsInstalled = processWrapper.Install(app.DownloadedPath);
        }
    }
}

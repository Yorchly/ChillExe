using ChillExe.Models;
using System.Collections.Generic;

namespace ChillExe.Downloader
{
    public interface IAppDownloader
    {
        public List<string> Download(List<App> apps);
    }
}

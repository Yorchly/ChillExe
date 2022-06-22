using ChillExe.Models;
using System.Collections.Generic;

namespace ChillExe.Downloader
{
    public interface IAppDownloader
    {
        /// <summary>
        /// Try to download on temp directory all the applications specified in the list.
        /// If download is succesfull, App.IsDownloaded will be set to true and
        /// App.DownloadedPath will be set with the path of the downloaded application.
        /// </summary>
        /// <param name="apps"></param>
        public void Download(List<App> apps);
    }
}

using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChillExe.Downloader
{
    public class AppDownloader : IAppDownloader
    {
        private readonly string destinationPath = Path.GetTempPath();
        private readonly ICustomLogger logger;
        private readonly IHttpClientWrapper httpClientWrapper;

        public AppDownloader(ICustomLogger logger, IHttpClientWrapper httpClientWrapper)
        {
            this.logger = logger;
            this.httpClientWrapper = httpClientWrapper;
        }

        public void Download(List<App> apps)
        {
            if (apps == null)
                return;

            foreach (App app in apps)
                if (Download(app).Result)
                {
                    app.DownloadedPath = Path.Combine(destinationPath, app.Filename);
                    app.IsDownloaded = true;
                }
        }

        private async Task<bool> Download(App app)
        {
            try
            {
                HttpResponseMessage response = await httpClientWrapper.GetAsync(app.Url);

                if (response.IsSuccessStatusCode)
                {
                    using var fileStream = new FileStream(
                        Path.Combine(destinationPath, app.Filename),
                        FileMode.Create
                    );
                    await response.Content.CopyToAsync(fileStream);

                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLine(
                    $"Error in AppDownloader.Download -> {ex.Message}",
                    LogLevel.ERROR
                );

                return false;
            }
        }
    }
}

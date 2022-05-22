using ChillExe.Downloader;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Wrappers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace ChillExe.Tests.Downloader
{
    public class AppDownloaderTest
    {
        private readonly Mock<ICustomLogger> loggerMock =
            new Mock<ICustomLogger>();
        private readonly Mock<IHttpClientWrapper> httpClientWrapperMock =
            new Mock<IHttpClientWrapper>();
        AppDownloader appDownloader;
        List<App> apps;

        [SetUp]
        public void SetUp()
        {
            appDownloader = new AppDownloader(loggerMock.Object, httpClientWrapperMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            if (apps != null)
                foreach (string path in apps.Select(app => app.DownloadedPath).Where(downloadedPath => !string.IsNullOrEmpty(downloadedPath)))
                    File.Delete(path);
        }

        [Test]
        public void Download_CorrectListOfApps_ReturnsListOfDownloadedAppsPath()
        {
            apps = GetApps(2);
            HttpResponseMessage httpResponseMessage =
                GetOkHttpResponseMessage();
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(It.IsAny<string>())
            ).ReturnsAsync(httpResponseMessage);

            appDownloader.Download(apps);

            foreach(App app in apps)
                CheckIfAppIsDownloadedCorrectly(app);
        }

        private List<App> GetApps(int count = 1)
        {
            apps = new List<App>();
            for (int i = 0; i < count; i++)
                apps.Add(
                    new App
                    {
                        Filename = $"test{i}.txt",
                        LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        Url = $"http://test{i}-url.com/test1.txt"
                    }
                );

            return apps;
        }

        private static HttpResponseMessage GetOkHttpResponseMessage()
        {
            var httpResponseMessage =
                new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent("test");

            return httpResponseMessage;
        }

        private static void CheckIfAppIsDownloadedCorrectly(App app)
        {
            Assert.IsTrue(app.IsDownloaded);
            Assert.IsNotNull(app.DownloadedPath);
            Assert.IsNotEmpty(app.DownloadedPath);
            Assert.IsTrue(File.Exists(app.DownloadedPath));   
        }

        [Test]
        public void Download_ListOfAppsIsNull_NoChangesAreDoneToNullList()
        {
            apps = null;

            appDownloader.Download(apps);

            Assert.IsNull(apps);
        }

        [Test]
        public void Download_UrlInAppReturnsBadRequest_AppDownloadedPathIsNullAndIsInstalledPropertyIsFalse()
        {
            apps = GetApps();
            var badHttpResponseMessage =
                new HttpResponseMessage(HttpStatusCode.BadRequest);
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(It.IsAny<string>())
            ).ReturnsAsync(badHttpResponseMessage);

            appDownloader.Download(apps);

            CheckIfAppIsNotDownloaded(apps[0]);
        }

        private static void CheckIfAppIsNotDownloaded(App app)
        {
            Assert.IsNull(app.DownloadedPath);
            Assert.IsFalse(app.IsDownloaded);
        }

        [Test]
        public void Download_AppTriggersAnException_AppDownloadedPathIsNullAndIsInstalledPropertyIsFalse()
        {
            apps = GetApps();
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(It.IsAny<string>())
            ).ThrowsAsync(new Exception());

            appDownloader.Download(apps);

            CheckIfAppIsNotDownloaded(apps[0]);
        }
    }
}

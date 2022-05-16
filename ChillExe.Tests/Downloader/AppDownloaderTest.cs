using ChillExe.Downloader;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Wrappers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
        List<string> downloadedAppsPath;

        [SetUp]
        public void SetUp()
        {
            appDownloader = new AppDownloader(loggerMock.Object, httpClientWrapperMock.Object);
            downloadedAppsPath = new List<string>();
        }

        [TearDown]
        public void TearDown()
        {
            if (downloadedAppsPath != null && downloadedAppsPath.Count > 0)
                foreach (string path in downloadedAppsPath)
                    File.Delete(path);
        }

        [Test]
        public void Download_CorrectListOfApps_ReturnsListOfDownloadedAppsPath()
        {
            List<App> apps = GetApps();
            HttpResponseMessage httpResponseMessage =
                GetOkHttpResponseMessage();
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(It.IsAny<string>())
            ).ReturnsAsync(httpResponseMessage);

            downloadedAppsPath = appDownloader.Download(apps);

            Assert.Greater(downloadedAppsPath.Count, 0);
            CheckIfDownloadedAppsExists();
        }

        private static List<App> GetApps() =>
            new List<App>
            {
                new App { 
                    Filename="test1.txt", 
                    LastUpdate=DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Url="http://test1-url.com/test1.txt"
                },
                new App {
                    Filename="test2.txt",
                    LastUpdate=DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Url="http://test2-url.com/test2.txt"
                }
            };

        private static HttpResponseMessage GetOkHttpResponseMessage()
        {
            var httpResponseMessage =
                new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent("test");

            return httpResponseMessage;
        }

        private void CheckIfDownloadedAppsExists()
        {
            foreach (string path in downloadedAppsPath)
                Assert.IsTrue(File.Exists(path));
        }

        [Test]
        public void Download_WrongListOfApps_ReturnsEmptyDownloadedAppsPathList()
        {
            downloadedAppsPath = appDownloader.Download(null);

            Assert.AreEqual(downloadedAppsPath.Count, 0);
        }

        [Test]
        public void Download_OneOfTheURLInAppReturnsABadRequest_ReturnsDownloadedAppsPathWithoutTheWrongOne()
        {
            List<App> apps = GetApps();
            apps.Add(
                new App
                {
                    Filename = "wrongFile.txt",
                    LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Url = "https://wrong-url.com/wrongFile.txt"
                }
            );
            var badHttpResponseMessage =
                new HttpResponseMessage(HttpStatusCode.BadRequest);
            var okHttpResponseMessage =
                GetOkHttpResponseMessage();
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(apps[0].Url)
            ).ReturnsAsync(okHttpResponseMessage);
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(apps[1].Url)
            ).ReturnsAsync(okHttpResponseMessage);
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(apps[2].Url)
            ).ReturnsAsync(badHttpResponseMessage);

            downloadedAppsPath = appDownloader.Download(apps);

            Assert.AreEqual(downloadedAppsPath.Count, 2);
            CheckIfDownloadedAppsExists();
        }

        [Test]
        public void Download_ThrowsAnException_ReturnsEmptyDownloadedAppsPath()
        {
            var apps = new List<App>
            {
                new App
                {
                    Filename = "wrongFile.txt",
                    LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Url = "https://wrong-url.com/wrongFile.txt"
                }
            };
            httpClientWrapperMock.Setup(
                httpClientWrapper => httpClientWrapper.GetAsync(It.IsAny<string>())
            ).ThrowsAsync(new Exception());

            downloadedAppsPath = appDownloader.Download(apps);

            Assert.AreEqual(downloadedAppsPath.Count, 0);
        }
    }
}

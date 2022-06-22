using ChillExe.Installer;
using ChillExe.Models;
using ChillExe.Wrappers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChillExe.Tests.Installer
{
    public class AppInstallerTest
    {
        private readonly Mock<IProcessWrapper> processWrapperMock = new();
        private AppInstaller appInstaller;
        private List<App> apps;

        [SetUp]
        public void SetUp()
        {
            appInstaller = new AppInstaller(processWrapperMock.Object);
            apps = null;
        }

        [Test]
        public void Install_ListOfAppsIsOk_IsInstalledPropertyOfAppsIsSetToTrue()
        {
            apps = GetAppsWithDownloadedProperties(2);
            processWrapperMock.Setup(
                processWrapper => processWrapper.Install(It.IsAny<string>())
            ).Returns(true);

            appInstaller.Install(apps);

            foreach (var app in apps)
                Assert.IsTrue(app.IsInstalled);
        }

        private static List<App> GetAppsWithDownloadedProperties(int count = 1)
        {
            var apps = GetApps(count);

            for (int i = 0; i < count; i++)
            {
                apps[i].IsDownloaded = true;
                apps[i].DownloadedPath = Path.Combine(Path.GetTempPath(), $"test{i}.txt");
            }

            return apps;
        }

        private static List<App> GetApps(int count = 1)
        {
            var apps = new List<App>();

            for (int i = 0; i < count; i++)
                apps.Add(
                    new App
                    {
                        Filename = $"test{i}.txt",
                        LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        Url = $"http://test{i}-url.com/test{i}.txt"
                    }
                );

            return apps;
        }

        [Test]
        public void Install_AppsIsNull_NoChangeAreDoneInApps()
        {
            apps = null;

            appInstaller.Install(apps);

            Assert.IsNull(apps);
        }

        [Test]
        public void Install_AppsAreNotDownloaded_AppsAreNotInstalled()
        {
            apps = GetApps(2);

            appInstaller.Install(apps);

            foreach (App app in apps)
                Assert.IsFalse(app.IsInstalled);
        }
    }
}

using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ChillExe.Tests.Helpers
{
    public class AppHelperTest
    {
        private readonly Mock<IService<Apps>> appServiceMock =
            new Mock<IService<Apps>>();
        AppHelper appHelper;
        Apps apps;

        [SetUp]
        public void SetUp()
        { 
            appHelper = new AppHelper(appServiceMock.Object);
        }

        [Test]
        public void GetApps_ServiceObtainsCorrectApps_ReturnsCorrectListOfApps()
        {
            apps = new Apps
            {
                AppList = GetApps(3)
            };
            appServiceMock.Setup(
                appService => appService.Get()
            ).Returns(apps);

            List<App> resultApps = appHelper.GetApps();

            Assert.NotNull(resultApps);
            Assert.Greater(resultApps.Count, 0);
            Assert.AreEqual(resultApps[0], apps.AppList[0]);
            Assert.AreEqual(resultApps[1], apps.AppList[1]);
            Assert.AreEqual(resultApps[2], apps.AppList[2]);
        }

        private List<App> GetApps(int count)
        {
            var apps = new List<App>();

            for (int i = 0; i < count; i++)
            {
                apps.Add(
                    new App
                    {
                        Filename = $"test-{i}",
                        LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        Url = $"http://test-url-{i}.com/ejemplo{i}.exe"
                    }
                );
            }

            return apps;
        }

        [Test]
        public void GetApps_ServiceGetNullApps_ReturnsNull()
        {
            apps = null;
            appServiceMock.Setup(
                appService => appService.Get()
            ).Returns(apps);

            List<App> resultApps = appHelper.GetApps();

            Assert.IsNull(resultApps);
        }

        [Test]
        public void SaveApps_AppsAreSavedCorrectly_ReturnsTrue()
        {
            apps = new Apps
            {
                AppList = GetApps(3)
            };
            appServiceMock.Setup(
                appService => appService.Save(It.IsAny<Apps>())
            ).Returns(true);

            bool result = appHelper.SaveApps(apps.AppList);

            Assert.IsTrue(result);
        }

        [Test]
        public void SaveApps_AppsAreNotSavedCorrectly_ReturnsFalse()
        {
            apps = null;
            appServiceMock.Setup(
                appService => appService.Save(It.IsAny<Apps>())
            ).Returns(false);

            bool result = appHelper.SaveApps(null);

            Assert.IsFalse(result);
        }
    }
}

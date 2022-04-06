using ChillExe.DAO;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChillExe.Tests.DAO
{
    public class AppXmlDAOTest
    {
        private readonly Mock<IAppService> appXmlServiceMockup = 
            new Mock<IAppService>();
        private AppXmlDAO xmlDAO; 
        private List<App> testApps = new List<App>
        {
            new App { 
                Filename = "Test1", LastUpdate = DateTime.Now.ToString(), 
                Url = "https://test-url.com"
            },
            new App { 
                Filename = "Test2", LastUpdate = DateTime.Now.ToString(), 
                Url = "https://test2-url.com"
            },
        };

        [SetUp]
        public void SetUp()
        {
            appXmlServiceMockup.Setup(
                appServiceMock => appServiceMock.Get()
            ).Returns(new List<App>(testApps));

            xmlDAO = new AppXmlDAO(appXmlServiceMockup.Object);
        }

        [Test]
        public void Get_ReturnsListOfApps()
        {
            List<App> apps = xmlDAO.Get();

            Assert.Greater(apps.Count, 0);
            Assert.AreEqual(testApps[0], apps[0]);
            Assert.AreEqual(testApps[1], apps[1]);
        }

        [Test]
        public void Set_AppIsValid_ReturnsAppListUpdated()
        {
            App app = GetAppList(1).First();

            List<App> apps = xmlDAO.Set(app);

            Assert.AreEqual(apps.Count, 3);
            Assert.AreEqual(apps[2], app);
        }

        private List<App> GetAppList(int length)
        {
            var apps = new List<App>();
            for (int i = 0; i < length; i++)
                apps.Add(new App { Filename = $"Test {i + 1}", LastUpdate = DateTime.Now.ToString(), Url = $"https://test-url-{i}.com" });

            return apps;
        }

        [Test]
        public void Set_AppIsNotValid_ReturnsAppListWithNoUpdates()
        {
            App app = null;

            List<App> apps = xmlDAO.Set(app);

            Assert.AreEqual(apps.Count, 2);
            Assert.AreEqual(apps[0], testApps[0]);
            Assert.AreEqual(apps[1], testApps[1]);
        }

        [Test]
        public void Set_AppsAreValid_ReturnsAppListUpdated()
        {
            List<App> apps = GetAppList(2);

            List<App> appsFromDAO = xmlDAO.Set(apps);

            Assert.AreEqual(appsFromDAO.Count, 4);
            Assert.AreEqual(appsFromDAO[2], apps[0]);
            Assert.AreEqual(appsFromDAO[3], apps[1]);
        }

        [Test]
        public void Set_AppsAreValidAndOverwriteIsTrue_ReturnsAppListOnlyWithNewApps()
        {
            List<App> apps = GetAppList(2);

            List<App> appsBeforeOverwrite = xmlDAO.Get();
            List<App> appsAfterOverwrite =  xmlDAO.Set(apps, overwrite: true);

            Assert.AreEqual(appsAfterOverwrite.Count, 2);
            Assert.AreNotEqual(appsBeforeOverwrite[0], appsAfterOverwrite[0]);
            Assert.AreNotEqual(appsBeforeOverwrite[1], appsAfterOverwrite[1]);
        }

        [Test]
        public void Set_AppsAreNotValid_ReturnsAppListWithNoUpdates()
        {
            List<App> apps = null;

            List<App> appsFromDAO = xmlDAO.Set(apps);

            Assert.AreEqual(appsFromDAO.Count, 2);
            Assert.AreEqual(appsFromDAO[0], testApps[0]);
            Assert.AreEqual(appsFromDAO[1], testApps[1]);
        }

        [Test]
        public void Clear_ReturnsTrue()
        {
            bool response = xmlDAO.Clear();
            List<App> apps = xmlDAO.Get();

            Assert.IsTrue(response);
            Assert.AreEqual(apps.Count, 0);
        }

        [Test]
        public void Save_ReturnsTrue()
        {
            appXmlServiceMockup.Setup(
                xmlService => xmlService.Save(testApps)
            ).Returns(true);

            bool response = xmlDAO.Save();

            Assert.IsTrue(response);
        }
    }
}

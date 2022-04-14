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
    public class AppDAOTest
    {
        private readonly Mock<IService<Apps>> appServiceMockup = 
            new Mock<IService<Apps>>();
        private AppDAO dao;
        private Apps testApps;

        [SetUp]
        public void SetUp()
        {
            testApps = new Apps
            {
                AppList = new List<App>
                {
                    new App {
                        Filename = "Test1", LastUpdate = DateTime.Now.ToString(),
                        Url = "https://test-url.com"
                    },
                    new App {
                        Filename = "Test2", LastUpdate = DateTime.Now.ToString(),
                        Url = "https://test2-url.com"
                    },
                }
            };
            appServiceMockup.Setup(
                appServiceMock => appServiceMock.Get()
            ).Returns(testApps);

            dao = new AppDAO(appServiceMockup.Object);
        }

        [Test]
        public void Get_ReturnsListOfApps()
        {
            List<App> apps = dao.Get();

            Assert.Greater(apps.Count, 0);
        }

        [Test]
        public void Save_ReturnsTrue()
        {
            appServiceMockup.Setup(
                xmlService => xmlService.Save(It.IsAny<Apps>())
            ).Returns(true);

            bool response = dao.Save();

            Assert.IsTrue(response);
        }
    }
}

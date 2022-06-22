using ChillExe.Helpers;
using ChillExe.Models;
using ChillExe.Services.Xml;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ChillExe.Tests.Services.Xml
{
    public class AppServiceTest
    {
        private readonly Mock<IXmlHelper<Apps>> xmlHelperMock = 
            new Mock<IXmlHelper<Apps>>();
        private AppService appService;

        [Test]
        public void Get_XmlHelperGetCorrectInformation_ReturnsAppsInstance()
        {
            Apps apps = GetCorrectApps();
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Get()
            ).Returns(apps);
            appService = new AppService(xmlHelperMock.Object);

            Apps resultApps = appService.Get();

            Assert.IsNotNull(resultApps);
            Assert.Greater(resultApps.AppList.Count, 0);
            Assert.AreEqual(apps.AppList[0], resultApps.AppList[0]);
            Assert.AreEqual(apps.AppList[1], resultApps.AppList[1]);
        }

        public Apps GetCorrectApps()
        {
            return new Apps
            {
                AppList = new List<App>
                {
                    new App { Filename = "test", LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm"), Url = @"http:\\test.com\test.exe"},
                    new App { Filename = "test2", LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm"), Url = @"http:\\test2.com\test.exe"}
                }
            };
        }

        [Test]
        public void Get_XmlHelperGetIncorrectInformation_ReturnsNull()
        {
            Apps apps = null;
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Get()
            ).Returns(apps);
            appService = new AppService(xmlHelperMock.Object);

            Apps resultApps = appService.Get();

            Assert.IsNull(resultApps);
        }

        [Test]
        public void Save_AppsInstanceIsNull_ReturnsFalse()
        {
            Apps apps = null;
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Write(apps)
            ).Returns(false);
            appService = new AppService(xmlHelperMock.Object);

            bool response = appService.Save(apps);

            Assert.IsFalse(response);
        }

        [Test]
        public void Save_AppsInstanceIsCorrect_ReturnsFalse()
        {
            Apps apps = GetCorrectApps();
            xmlHelperMock.Setup(
                xmlHelper => xmlHelper.Write(apps)
            ).Returns(true);
            appService = new AppService(xmlHelperMock.Object);

            bool response = appService.Save(apps);

            Assert.IsTrue(response);
        }
    }
}

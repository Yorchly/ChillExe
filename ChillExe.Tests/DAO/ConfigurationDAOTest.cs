using ChillExe.DAO;
using ChillExe.Models;
using ChillExe.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.Tests.DAO
{
    public class ConfigurationDAOTest
    {
        private readonly Mock<IService<Configuration>> configServiceMockup =
            new Mock<IService<Configuration>>();
        private ConfigurationDAO dao;
        private Configuration testConfig;

        [SetUp]
        public void SetUp()
        {
            testConfig = new Configuration
            {
                Language = Language.Spanish
            };

            configServiceMockup.Setup(
                configServiceMock => configServiceMock.Get()
            ).Returns(testConfig);

            dao = new ConfigurationDAO(configServiceMockup.Object);
        }

        [Test]
        public void GetConfigurationFromDAO()
        {
            Configuration config = dao.Configuration;

            Assert.IsNotNull(config);
        }

        [Test]
        public void Save_ReturnsTrue()
        {
            configServiceMockup.Setup(
                xmlService => xmlService.Save(It.IsAny<Configuration>())
            ).Returns(true);

            bool response = dao.Save();

            Assert.IsTrue(response);
        }
    }
}

using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public class ConfigurationDAO : IConfigurationDAO
    {
        private readonly Configuration config;
        private readonly IService<Configuration> configService;

        public ConfigurationDAO(IService<Configuration> configService)
        {
            this.configService = configService;
            config = this.configService.Get();
        }

        public Configuration Get() => config;
        public bool Save() => configService.Save(config);
    }
}

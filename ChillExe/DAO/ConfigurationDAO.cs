using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public class ConfigurationDAO : IConfigurationDAO
    {
        public Configuration Configuration { get; set; }

        private readonly IService<Configuration> configService;

        public ConfigurationDAO(IService<Configuration> configService)
        {
            this.configService = configService;
            Configuration = this.configService.Get();
        }

        public bool Save() => configService.Save(Configuration);
    }
}

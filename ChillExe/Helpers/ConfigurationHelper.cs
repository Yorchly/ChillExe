using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Helpers
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private readonly IService<Configuration> configService;
        private readonly Configuration config;

        public ConfigurationHelper(IService<Configuration> configService)
        {
            this.configService = configService;
            config = this.configService.Get();
        }

        public Language GetCurrentLanguage() => config.Language;
    }
}

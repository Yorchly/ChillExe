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

        public ConfigurationHelper(IService<Configuration> configService)
        {
            this.configService = configService;
        }

        public Language GetCurrentLanguage() => configService.Get().Language;

        public Configuration GetConfiguration() =>
            configService.Get();

        public bool SaveConfiguration(Configuration config) =>
            configService.Save(config);
    }
}

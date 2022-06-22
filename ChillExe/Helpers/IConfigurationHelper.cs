using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Helpers
{
    public interface IConfigurationHelper
    {
        public Language GetCurrentLanguage();
        public Configuration GetConfiguration();
        public bool SaveConfiguration(Configuration configuration);
    }
}

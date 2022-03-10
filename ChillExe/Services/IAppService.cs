using ChillExe.Models;
using System.Collections.Generic;

namespace ChillExe.Services
{
    public interface IAppService
    {
        public string FilenameFullPath { get; set; }

        public List<App> Get();

        public bool Save(List<App> apps);
    }
}

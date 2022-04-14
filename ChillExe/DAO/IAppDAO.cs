using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public interface IAppDAO
    {
        public List<App> Get();

        public bool Save();
    }
}

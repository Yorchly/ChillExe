using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public interface IConfigurationDAO
    {
        public Configuration Get();

        public bool Save();
    }
}

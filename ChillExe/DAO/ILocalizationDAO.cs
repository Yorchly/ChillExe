using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public interface ILocalizationDAO
    {
        public List<Translation> Get();

        public bool Save();
    }
}
